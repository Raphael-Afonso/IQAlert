using IQAlert.CustomEventArgs;
using IQAlert.Enums;
using IQAlert.Model;
using System.Media;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace IQAlert.Biz
{
    internal class IQBiz
    {
        private event EventHandler<UpdateSignalListArgs> UpdatedSignalList;
        private List<Signal> SignalList;

        internal IQBiz()
        {
            SignalList = LoadSignalList();
            
            UpdatedSignalList += OnUpdateSignalList!;
        }

        internal void SaveSignalList(string[] signalList)
        {
            var DeserializetedSignalList = DeserializeSignalList(signalList);

            Properties.Settings.Default["SignalList"] = JsonSerializer.Serialize(DeserializetedSignalList);

            Properties.Settings.Default.Save();

            UpdatedSignalList.Invoke(this, new() { SignalList = DeserializetedSignalList });
        }

        internal Signals GetSignals()
        {
            var DateNow = DateTime.Now;
            TimeOnly Now = new(DateNow.Hour, DateNow.Minute);

            Signals Signals = new();

            foreach (var item in SignalList)
            {
                if (Now >= item.GetStartTime && Now <= item.GetStartTime.AddMinutes(15))
                {
                    Signals.CurrentSignal = item;
                    break;
                }
            }

            foreach (var item in SignalList)
            {
                if (Signals.CurrentSignal != null)
                {
                    if (item.GetStartTime > Now &&
                    item.GetStartTime > Signals.CurrentSignal.GetStartTime.AddMinutes(15))
                    {
                        Signals.NextSignal = item;
                        break;
                    }
                }
                else
                {
                    if (item.GetStartTime > Now)
                    {
                        Signals.NextSignal = item;
                        break;
                    }
                }
            }

            if (Signals.NextSignal != null)
            {
                if (Signals.NextSignal.GetStartTime.AddMinutes(-1) == Now &&
                !Signals.NextSignal.IsNotified)
                {
                    PlayNotifySound();
                    SignalList[SignalList.IndexOf(Signals.NextSignal)]
                        .IsNotified = true;
                }
            }

            return Signals;
        }

        private static List<Signal> DeserializeSignalList(string[] signalList)
        {
            var SignalList = new List<Signal>();

            ValitedSignalLines(signalList);

            foreach (var line in signalList)
            {
                //Ignore empty lines
                if (!string.IsNullOrEmpty(line))
                {
                    string[] SeparedSignal = line.Split(" ");
                    string[] Sides = new string[] { "CALL", "PUT" };

                    Side Side = Sides.FirstOrDefault(c => SeparedSignal[2].ToUpper().Contains(c)) switch
                    {
                        "CALL" => Side.Call,
                        "PUT" => Side.Put,
                        _ => throw new ArgumentException("Problema na leitura da lista!"),
                    };

                    Signal NewSignal = new(
                        SeparedSignal[1], SeparedSignal[0], Side);
                    SignalList.Add(NewSignal);
                }
            }
            return SignalList;
        }

        private static void ValitedSignalLines(string[] lines)
        {
            foreach (var line in lines)
            {
                string[] SeparedLine = line.Split(" ");

                if (!Regex.IsMatch(SeparedLine[0], @"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$"))
                    throw new FormatException("Formato da lista desconhecido!");
                if(!SeparedLine[2].Contains("CALL") && !SeparedLine[2].Contains("PUT"))
                    throw new FormatException("Formato da lista desconhecido!");
            }
        }

        private static List<Signal> LoadSignalList()
        {
            string StoredSignalList = Properties.Settings.Default.SignalList;
            if (StoredSignalList != null)
            {
                try
                {
                    return JsonSerializer.Deserialize<List<Signal>>(StoredSignalList)!;
                }
                catch (Exception)
                { }
            }
            return new List<Signal>();
        }

        private void OnUpdateSignalList(object sender, UpdateSignalListArgs e)
        {
            SignalList = e.SignalList;
        }

        private static void PlayNotifySound()
        {
            try
            {
                System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
                Stream s = a.GetManifestResourceStream("IQAlert.Notify.mp3")!;
                if (s != null)
                {
                    using SoundPlayer NotifySound = new(s);
                    NotifySound.Play();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}

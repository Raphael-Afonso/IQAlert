using IQAlert.CustomEventArgs;
using IQAlert.Enums;
using IQAlert.Extensions;
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
            var DeserializetedSignalList = DeserializeSignalList(signalList)
                .OrderBy(c => c.GetStartTime)
                .ToList();

            Properties.Settings.Default["SignalList"] = JsonSerializer.Serialize(DeserializetedSignalList);

            Properties.Settings.Default.Save();

            UpdatedSignalList.Invoke(this, new() { SignalList = DeserializetedSignalList });
        }

        internal Signals GetSignals()
        {
            TimeOnly Now = DateTime.Now.ToTimeOnly();

            Signals Signals = new();

            Signals.CurrentSignal = SignalList
                .FirstOrDefault(c => Now >= c.GetStartTime && Now <= c.GetStartTime.AddMinutes(15));

            if (Signals.CurrentSignal != null)            
                Signals.NextSignal = SignalList[SignalList.IndexOf(Signals.CurrentSignal) + 1];
            else
                Signals.NextSignal = SignalList.FirstOrDefault(c => c.GetStartTime >= Now);


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
                if (!SeparedLine[2].Contains("CALL") && !SeparedLine[2].Contains("PUT"))
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

        public static void PlayNotifySound()
        {
            try
            {
                using SoundPlayer NotifySound = new(Properties.Resources.Notify);
                NotifySound.Play();
            }
            catch (Exception)
            { }
        }
    }
}

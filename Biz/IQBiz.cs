using IQAlert.Enums;
using IQAlert.Model;
using System.Media;
using System.Text.Json;

namespace IQAlert.Biz
{
    internal static class IQBiz
    {
        public static List<Signal> GetSavedSignalList()
        {
            string StoredSignalList = Properties.Settings.Default.SignalList;
            if (StoredSignalList is not null)
            {
                try
                {
                    return JsonSerializer.Deserialize<List<Signal>>(StoredSignalList);
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }
        public static void SaveSignalList(string[] signalList)
        {
            Properties.Settings.Default["SignalList"] = JsonSerializer.Serialize(
                SerializeSignalList(signalList));

            Properties.Settings.Default.Save();

        }
        private static List<Signal> SerializeSignalList(string[] signalList)
        {
            var SignalList = new List<Signal>();

            foreach (var signal in signalList)
            {
                string[] SeparedSignal = signal.Split(" ");
                string[] Sides = new string[] { "CALL", "PUT" };
                
                Side Side = Sides.FirstOrDefault(c=>SeparedSignal[2].Contains(c)) switch
                {
                    "CALL" => Side.Call,
                    "PUT" => Side.Put,
                    _ => throw new ArgumentException("Problema na leitura da lista!"),
                };

                Signal NewSignal = new()
                {
                    StartTime = SeparedSignal[0],
                    Side = Side,
                    Exchange = SeparedSignal[1]
                };
                SignalList.Add(NewSignal);
            }
            return SignalList;
        }
        public static void PlayNotifySound()
        {
            try
            {
                System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
                Stream s = a.GetManifestResourceStream("IQAlert.Notify.mp3");
                using SoundPlayer NotifySound = new(s);
                NotifySound.Play();
            }
            catch (Exception)
            {
            }
        }
    }
}

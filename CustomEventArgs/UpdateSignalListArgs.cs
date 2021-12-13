using IQAlert.Model;

namespace IQAlert.CustomEventArgs
{
    internal class UpdateSignalListArgs : EventArgs
    {
        internal List<Signal> SignalList { get; set; } = null!;
    }
}

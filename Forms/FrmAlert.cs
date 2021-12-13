using IQAlert.Biz;

namespace IQAlert.Forms
{
    public partial class FrmAlert : Form
    {
        private readonly IQBiz IQBiz;
        public FrmAlert()
        {
            InitializeComponent();
            IQBiz = new();
        }

        private void FrmAlert_Load(object sender, EventArgs e)
        {
            SetPosition();
            SignalTimer.Start();
        }

        private void SetPosition()
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);
        }

        private void SignalTimer_Tick(object sender, EventArgs e)
        {
            var Signals = IQBiz.GetSignals();

            if (Signals.NextSignal != null)
            {
                LbSignalAfter.Text = $"Ativo: {Signals.NextSignal.Exchange}";
                LbTimeAfter.Text = $"Hora: {Signals.NextSignal.GetStartTime}";

                PicSignalAfter.Image = Signals.NextSignal.Side switch
                {
                    Enums.Side.Call => Properties.Resources.Call,
                    Enums.Side.Put => Properties.Resources.Put,
                    _ => null
                };
            }
            else
            {
                ResetNextSignalComponents();
            }

            if (Signals.CurrentSignal != null)
            {
                LbSignalNow.Text = $"Ativo: {Signals.CurrentSignal.Exchange}";
                LbTimeNow.Text = $"Hora: {Signals.CurrentSignal.GetStartTime}";

                PicSignalNow.Image = Signals.CurrentSignal.Side switch
                {
                    Enums.Side.Call => Properties.Resources.Call,
                    Enums.Side.Put => Properties.Resources.Put,
                    _ => null
                };
            }
            else
            {
                ResetCurrentSignalComponents();
            }
        }

        private void ResetCurrentSignalComponents()
        {
            LbSignalNow.Text = "Ativo:";
            LbTimeNow.Text = "Hora:";
            PicSignalNow.Image = null;
        }

        private void ResetNextSignalComponents()
        {
            LbSignalAfter.Text = "Ativo:";
            LbTimeAfter.Text = "Hora:";
            PicSignalAfter.Image = null;
        }

        private void BtnConfig_Click(object sender, EventArgs e)
        {
            FrmSignalList FrmSignalList = new(IQBiz);
            FrmSignalList.ShowDialog();
        }
    }
}

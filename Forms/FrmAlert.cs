using IQAlert.Biz;

namespace IQAlert.Forms
{
    public partial class FrmAlert : Form
    {
        private readonly IQBiz IQBiz;
        private Point MousePoint;
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

        private void FrmAlert_MouseDown(object sender, MouseEventArgs e)
        {
            MousePoint = e.Location;
        }

        private void FrmAlert_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int dx = e.Location.X - MousePoint.X;
                int dy = e.Location.Y - MousePoint.Y;
                Location = new Point(Location.X + dx, Location.Y + dy);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

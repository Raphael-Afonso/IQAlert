using IQAlert.Biz;
using IQAlert.Model;

namespace IQAlert.Forms
{
    public partial class FrmAlert : Form
    {
        private List<Signal>? SignalList;
        public FrmAlert()
        {
            InitializeComponent();
        }

        private void FrmAlert_Load(object sender, EventArgs e)
        {
            SetPosition();
            LoadSignalList();
            SignalTimer.Start();
        }

        private void SetPosition()
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);
        }

        private void LoadSignalList()
        {
            SignalList = IQBiz.GetSavedSignalList();
        }
        private void UpdateSignalObjects()
        {
            var DateNow = DateTime.Now;
            TimeOnly Now = new(DateNow.Hour, DateNow.Minute);
            Signal SignalNow = null;
            Signal SignalAfter = null;

            foreach (var item in SignalList)
            {
                if (Now >= item.GetStartTime && Now <= item.GetStartTime.AddMinutes(15))
                {
                    SignalNow = item;
                    break;
                }
            }

            foreach (var item in SignalList)
            {
                if (SignalNow != null)
                {
                    if (item.GetStartTime > Now &&
                    item.GetStartTime > SignalNow.GetStartTime.AddMinutes(15))
                    {
                        SignalAfter = item;
                        break;
                    }
                }
                else
                {
                    if (item.GetStartTime > Now)
                    {
                        SignalAfter = item;
                        break;
                    }
                }
            }

            if (SignalNow != null)
            {
                LbSignalNow.Text = $"Ativo: {SignalNow.Exchange}";
                LbTimeNow.Text = $"Hora: {SignalNow.StartTime}";

                switch (SignalNow.Side)
                {
                    case Enums.Side.Call:
                        PicSignalNow.Image = Properties.Resources.Call;
                        break;
                    case Enums.Side.Put:
                        PicSignalNow.Image = Properties.Resources.Put;
                        break;
                }
            }
            else
            {
                LbSignalNow.Text = "Ativo:";
                LbTimeNow.Text = "Hora:";
                PicSignalNow.Image = null;
            }

            if (SignalAfter != null)
            {
                LbSignalAfter.Text = $"Ativo: {SignalAfter.Exchange}";
                LbTimeAfter.Text = $"Hora: {SignalAfter.StartTime}";

                switch (SignalAfter.Side)
                {
                    case Enums.Side.Call:
                        PicSignalAfter.Image = Properties.Resources.Call;
                        break;
                    case Enums.Side.Put:
                        PicSignalAfter.Image = Properties.Resources.Put;
                        break;
                }

                if (SignalAfter.GetStartTime.AddMinutes(-1) == Now &&
                    !SignalAfter.AlreadyNotified)
                {
                    IQBiz.PlayNotifySound();
                    SignalList[SignalList.IndexOf(SignalAfter)]
                        .AlreadyNotified = true;
                }
            }
            else
            {
                LbSignalAfter.Text = "Ativo:";
                LbTimeAfter.Text = "Hora:";
                PicSignalAfter.Image = null;
            }
        }

        private void SignalTimer_Tick(object sender, EventArgs e)
        {
            UpdateSignalObjects();
        }

        private void BtnConfig_Click(object sender, EventArgs e)
        {
            SignalTimer.Stop();

            FrmSignalList FrmSignalList = new();
            FrmSignalList.ShowDialog();
            if (FrmSignalList.HasReload)
                LoadSignalList();

            SignalTimer.Start();
        }
    }
}

using IQAlert.Biz;

namespace IQAlert.Forms
{
    public partial class FrmSignalList : Form
    {
        public bool HasReload { get; set; } = false;
        public FrmSignalList()
        {
            InitializeComponent();
        }

        private void Gravar(object sender, EventArgs e)
        {
            try
            {
                IQBiz.SaveSignalList(SignalListTextBox.Lines);
                MessageBox.Show("Lista gravada!");
                HasReload = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao gravar lista!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SignalListTextBox.ResetText();
                SignalListTextBox.Focus();
            }
        }
    }
}

using IQAlert.Biz;

namespace IQAlert.Forms
{
    public partial class FrmSignalList : Form
    {
        internal readonly IQBiz _biz;
        internal FrmSignalList(IQBiz biz)
        {
            InitializeComponent();
            _biz = biz;
        }

        private void Gravar(object sender, EventArgs e)
        {
            try
            {
                _biz.SaveSignalList(SignalListTextBox.Lines);
                MessageBox.Show("Lista gravada!");
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

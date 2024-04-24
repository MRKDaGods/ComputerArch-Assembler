namespace MRK
{
    public partial class InputStringForm : Form
    {
        private Action<string> _callback;

        public InputStringForm(string? oldPath, Action<string> callback)
        {
            InitializeComponent();

            bGenerate.Click += OnGenerate;

            if (oldPath != null)
            {
                tbPath.Text = oldPath;
            }

            _callback = callback;
        }

        private void OnGenerate(object? sender, EventArgs e)
        {
            _callback(tbPath.Text);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCreate form = new FormCreate();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormDelete form = new FormDelete();
            form.Show();

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            FormRead form = new FormRead();
            form.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FormUpdate form = new FormUpdate();
            form.Show();
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            FormJoin form = new FormJoin();
            form.Show();
        }
    }
}

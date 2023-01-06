namespace JogoDaVelha
{
    public partial class Form1 : Form
    {
        private bool xis;

        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            b11.Click += new EventHandler(BClick);
            b12.Click += new EventHandler(BClick);
            b13.Click += new EventHandler(BClick);
            b21.Click += new EventHandler(BClick);
            b22.Click += new EventHandler(BClick);
            b23.Click += new EventHandler(BClick);
            b31.Click += new EventHandler(BClick);
            b32.Click += new EventHandler(BClick);
            b33.Click += new EventHandler(BClick);

            foreach (Control item in this.Controls)
            {
                if (item is Button)
                {
                    item.TabStop = false;
                }
            }
        }

        private void BClick(object sender, EventArgs e)
        {
            ((Button)sender).Text = this.xis ? "X" : "O";
            ((Button)sender).Enabled = false;

            VerificarGanhador();

            xis = !xis;

            label1.Text = String.Format("{0}, é a sua vez", this.xis ? "X" : "O");
        }

        private void VerificarGanhador()
        {
            if (
                    b11.Text != String.Empty && b11.Text == b12.Text && b12.Text == b13.Text ||
                    b21.Text != String.Empty && b21.Text == b22.Text && b22.Text == b23.Text ||
                    b31.Text != String.Empty && b31.Text == b32.Text && b32.Text == b33.Text ||

                    b11.Text != String.Empty && b11.Text == b21.Text && b21.Text == b31.Text ||
                    b12.Text != String.Empty && b12.Text == b22.Text && b22.Text == b32.Text ||
                    b13.Text != String.Empty && b13.Text == b23.Text && b23.Text == b33.Text ||

                    b11.Text != String.Empty && b11.Text == b22.Text && b22.Text == b33.Text ||
                    b13.Text != String.Empty && b13.Text == b22.Text && b22.Text == b31.Text
                )
            {
                MessageBox.Show(String.Format("O Ganhador é o {0}", xis ? "X" : "O"), "Temos um vitorioso",
MessageBoxButtons.OK, MessageBoxIcon.Information);

                Reiniciar();
            }
            else
            {
                VerificarEmpate();
            }
        }

        private void VerificarEmpate()
        {
            bool todosDesabilitados = true;

            foreach (Control item in this.Controls)
            {
                if (item is Button && item.Enabled)
                {
                    todosDesabilitados = false;
                    break;
                }
            }
            if (todosDesabilitados)
            {
                MessageBox.Show(String.Format("Deu Empate"), "Ops!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Reiniciar();
            }
        }

        private void Reiniciar()
        {
            foreach (Control item in this.Controls)
            {
                if (item is Button)
                {
                    item.Enabled = true;
                    item.Text = String.Empty;
                }
            }
        }


    }
}
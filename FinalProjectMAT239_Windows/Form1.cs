namespace FinalProjectMAT239_Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Prisoners_Dilemma dilemma = new Prisoners_Dilemma();
            dilemma.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game_Of_Bridge bridge = new Game_Of_Bridge();
            bridge.Show();
        }
    }
}
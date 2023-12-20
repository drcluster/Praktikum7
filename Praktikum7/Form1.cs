namespace Praktikum7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] studentAnswers = File.ReadAllLines(openFileDialog.FileName);
                GradeExam(studentAnswers);
            }
        }

        private void GradeExam(string[] studentAnswers)
        {
            string[] correctAnswers = { "B", "D", "A", "A", "C", "A", "B", "A", "C", "D", "B", "C", "D", "A", "D", "C", "C", "B", "D", "A" };
            int correctCount = 0;
            int incorrectCount = 0;
            listBox1.Items.Clear();

            for (int i = 0; i < correctAnswers.Length; i++)
            {
                if (i < studentAnswers.Length && studentAnswers[i].Trim().Equals(correctAnswers[i].Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    correctCount++;
                }
                else
                {
                    incorrectCount++;
                    listBox1.Items.Add("Question " + (i + 1));
                }
            }

            string resultMessage = correctCount >= 15 ? "Passed" : "Failed";
            label1.Text = $"Result: {resultMessage}. Correct Answers: {correctCount}. Incorrect Answers: {incorrectCount}";
        }

    }
}

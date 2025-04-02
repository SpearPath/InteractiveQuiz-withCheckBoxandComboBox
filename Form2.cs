using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InteractiveQuiz
{
    public partial class fr_bosh : Form
    {
        public static fr_bosh instance;
        public Label lab1;
        private Random rnd = new Random();

        public fr_bosh()
        {
            InitializeComponent();
            lab1 = label1;
            instance = this;
        }


        string[] questions = { /*1*/ "Why is it important to follow safety rules at work?",
                               /*2*/  "What should you do first if a fire breaks out at work?",
                               /*3*/  "Which of the following is a common workplace hazard",
                               /*4*/  "What should you wear to protect your eyes when working with chemicals?",
                               /*5*/  "If you see someone injured at work, what is the first thing you should do?",
                               /*6*/  "What does PPE stand for?",
                               /*7*/  "Why is it important to take breaks during work?",
                               /*8*/  "What should you do if you spill a liquid on the floor at work?",
                               /*9*/  "If you hear an emergency alarm at work, what should you do?",
                               /*10*/ "What is the safest way to lift a heavy object?",
                               };
    

        // options: 10 questions, 3 options each, last item is the correct answer
        string[,] options = new string[10, 4] { 
        { "To avoid getting bored", "To prevent accidents and injuries", "To finish work faster", "To prevent accidents and injuries" },
        { "Run and hide", "Try to put it out yourself", "Alert others and follow the evacuation plan", "Alert others and follow the evacuation plan" },
        { "Clean floor", "Loose wires on the floor", "Proper lighting", "Loose wires on the floor" },
        { "Gloves", "Goggles", "Helmet", "Goggles" },
        { "Walk away", "Offer medical help if trained or call for assistance", "Take a picture", "Offer medical help if trained or call for assistance" },
        { "Personal Property Equipment", "Protective Personal Equipment", "Personal Protective Equipment", "Personal Protective Equipment" },
        { "To avoid getting caught sleeping", "To improve focus and prevent fatigue", "To reduce working hours", "To avoid getting caught sleeping" },
        { "Leave it for the cleaning staff", "Clean it up or report it immediately", "Step over it and keep working", "Clean it up or report it immediately" },
        { "Continue working", "Follow the evacuation plan", "Turn off the alarm", "Follow the evacuation plan" },
        { "Use your back and lift quickly", "Bend your knees and lift with your legs", "Twist your body while lifting", "Bend your knees and lift with your legs" } };

        // New ComboBox Questions
        string[] comboBoxQuestions = {
            "What is the purpose of an emergency exit?",
            "Which of the following is a common cause of workplace accidents?",
            "Why should electrical cords not run across walkways?",
            "What is the correct way to store hazardous materials?",
            "What should you do if you feel dizzy while working?"
        };

        string[,] comboBoxOptions = new string[5, 4] {
            { "For decoration", "To provide a quick escape during emergencies", "To store equipment", "To provide a quick escape during emergencies" },
            { "Proper lighting", "Slippery floors", "Wearing PPE", "Slippery floors" },
            { "They look untidy", "They can cause tripping hazards", "They increase internet speed", "They can cause tripping hazards" },
            { "Leave them open", "Store them in designated areas with proper labels", "Keep them in any available space", "Store them in designated areas with proper labels" },
            { "Ignore it", "Take a break and inform your supervisor if necessary", "Continue working", "Take a break and inform your supervisor if necessary" }
        };

        int index = 0, correct = 0;
        bool isComboBoxQuestion = false;

        //check if the user has selected the correct answer
        public void checkAnswer(RadioButton rbt)
        {

            if (rbt.Text.Equals(options[index, 3]))
            {
                correct++;
                //rbt.BackColor = Color.Green;
            }
            else
            {
                //rbt.BackColor = Color.Red;
            }

            index++;
            // disable radiobuttons
            setEnable(true);
        }

        // create a function to uncheck radiobuttons
        public void uncheck()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }

        // change radiobuttons backcolor and color
        public void resetRadio()
        {
            // the color change automatically when disabled
            foreach (Control c in this.Controls)
            {
                if (c is RadioButton)
                {
                    RadioButton rdb = (RadioButton)c;
                    rdb.BackColor = Color.White;
                }
            }
        }

        // enable/disable radiobuttons
        public void setEnable(Boolean yn)
        {
            radioButton1.Enabled = yn;
            radioButton2.Enabled = yn;
            radioButton3.Enabled = yn;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            // call the button click even
            button1.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // questions
            float percent = 0;
            resetRadio();

            if (button1.Text.Equals("Back to Main Menu"))
            {
                InteractiveQuiz fr1 = new InteractiveQuiz();
                fr1.Show();
                this.Close();
                index = 0;
                correct = 0;
                richTextBox1.BackColor = Color.White;
                richTextBox1.ForeColor = Color.Black;
                button1.Text = "Back to Main Menu";
            }

            if (index == questions.Length + comboBoxQuestions.Length)
            {

                percent = ((float)correct / (questions.Length + comboBoxQuestions.Length)) * 100;
                richTextBox1.Text = $"Your Score: {correct} / {questions.Length + comboBoxQuestions.Length} ---> {percent:F2}%";
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                comboBox1.Visible = false;
                btnSubmit.Visible = false;




                if (percent >= 75)
                {
                    richTextBox1.BackColor = Color.Green;
                    richTextBox1.ForeColor = Color.White;
                    lab1.Text = "CONGRATULATIONS! YOU PASSED!";
                }
                else
                {
                    richTextBox1.BackColor = Color.Red;
                    richTextBox1.ForeColor = Color.White;
                    lab1.Text = "SORRY, BETTER LUCK NEXT TIME!";
                }

                button1.Text = "Back to Main Menu";

            }

            else
            {
                label1.Text = " ";

                if (index < questions.Length)
                {
                    isComboBoxQuestion = false;
                    setEnable(true);
                    uncheck();
                    richTextBox1.Text = questions[index];

                    List<string> choices = new List<string>
                    {
                        options[index, 0],
                        options[index, 1],
                        options[index, 2],
                        options[index, 3]
                    };

                    choices = choices.Distinct().OrderBy(x => rnd.Next()).ToList();
                    choices = choices.Take(3).ToList();

                    radioButton1.Text = choices[0];
                    radioButton2.Text = choices[1];
                    radioButton3.Text = choices[2];

                    radioButton1.Visible = true;
                    radioButton2.Visible = true;
                    radioButton3.Visible = true;
                    comboBox1.Visible = false;
                    btnSubmit.Visible = false;
                }
                else
                {
                    isComboBoxQuestion = true;
                    int comboIndex = index - questions.Length;

                    richTextBox1.Text = comboBoxQuestions[comboIndex];
                    comboBox1.Items.Clear();
                    for (int i = 0; i < 3; i++)
                    {
                        comboBox1.Items.Add(comboBoxOptions[comboIndex, i]);
                    }

                    radioButton1.Visible = false;
                    radioButton2.Visible = false;
                    radioButton3.Visible = false;
                    comboBox1.Visible = true;
                    btnSubmit.Visible = true;
                }

                if (index == questions.Length + comboBoxQuestions.Length - 1)
                {
                    button1.Text = "Finish Quiz";
                }
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            checkAnswer(radioButton1);
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            checkAnswer(radioButton2);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void radioButton3_Click(object sender, EventArgs e)
        {
            checkAnswer(radioButton3);
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (isComboBoxQuestion && comboBox1.SelectedItem != null)
            {
                int comboIndex = index - questions.Length;
                if (comboIndex >= 0 && comboIndex < comboBoxOptions.GetLength(0))
                {
                    if (comboBox1.SelectedItem.ToString() == comboBoxOptions[comboIndex, 3])
                    {
                        correct++;
                    }
                }
                comboBox1.SelectedIndex = -1;
                index++;
                button1.PerformClick();
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                int textLength = comboBox1.SelectedItem.ToString().Length;
                float newSize = Math.Max(8, 20 - (textLength / 2)); // Adjust scaling as needed
                comboBox1.Font = new Font(comboBox1.Font.FontFamily, newSize, FontStyle.Regular);
            }
        }


    }
}

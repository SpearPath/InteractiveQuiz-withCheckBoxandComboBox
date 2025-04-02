using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace InteractiveQuiz
{
    public partial class fr_cisco : Form
    {
        public static fr_cisco instance;
        public Label lab1;
        private Random rnd = new Random();
        private List<CheckBox> currentCheckboxes = new List<CheckBox>();

        public fr_cisco()
        {
            InitializeComponent();
            instance = this;
            lab1 = label1;
        }

        string[] questions = { 
            /*1*/ "What does the term \"IP\" stand for in networking?",
            /*2*/ "Which device is used to connect different networks together?",
            /*3*/ "What is the function of a switch in a network?",
            /*4*/ "What is the purpose of a subnet mask?",
            /*5*/ "Which protocol is used to assign IP addresses automatically to devices on a network?",
            /*6*/ "What command is used to check the connection between two devices?",
            /*7*/ "What is the default subnet mask for a Class C IP address?",
            /*8*/ "Which layer of the OSI model is responsible for routing?",
            /*9*/ "Which Cisco command is used to enter privileged EXEC mode?",
            /*10*/ "What is the purpose of VLAN (Virtual Local Area Network)?",
            /*11*/ "What does a router do in a network?",
            /*12*/ "What is the function of the ARP protocol?",
            /*13*/ "Which protocol is used for secure communication over the internet?",
            /*14*/ "What is a MAC address?",
            /*15*/ "What is the role of a DNS server in a network?"
        };

        // options: questions with 3 options each, last item is the correct answer
        string[,] options = new string[15, 4] {
            { "Internet Process", "Internal Protocol", "Internet Protocol", "Internet Protocol" },
            { "Switch", "Router", "Hub", "Router" },
            { "Connects devices within the same network", "Provides internet access", "Converts data to signals", "Connects devices within the same network" },
            { "To identify a network device", "To divide IP addresses into network and host portions", "To send data packets", "To divide IP addresses into network and host portions" },
            { "HTTP", "DHCP", "FTP", "DHCP" },
            { "ipconfig", "ping", "tracert", "ping" },
            { "255.0.0.0", "255.255.255.0", "255.255.0.0", "255.255.255.0" },
            { "Transport layer", "Network layer", "Data link layer", "Network layer" },
            { "enable", "config", "run", "enable" },
            { "To create multiple networks within a single switch", "To increase internet speed", "To connect to the internet", "To create multiple networks within a single switch" },
            { "Forwards packets between devices", "Stores data packets", "Encrypts traffic", "Forwards packets between devices" },
            { "Maps IP addresses to MAC addresses", "Transmits video data", "Provides DNS service", "Maps IP addresses to MAC addresses" },
            { "TLS", "UDP", "HTTP", "TLS" },
            { "Unique identifier for network interfaces", "Broadcast address", "IP address", "Unique identifier for network interfaces" },
            { "Translates domain names to IP addresses", "Provides security", "Serves web content", "Translates domain names to IP addresses" }
        };

        string[][] allCorrectAnswers = new string[15][] {
            new string[] { "Internet Protocol" },                                   
            new string[] { "Router" },                                              
            new string[] { "Connects devices within the same network" },            
            new string[] { "To divide IP addresses into network and host portions" },
            new string[] { "DHCP" },                                                
            new string[] { "ping" },                                                
            new string[] { "255.255.255.0" },                                       
            new string[] { "Network layer" },                                       
            new string[] { "enable" },                                              
            new string[] { "To create multiple networks within a single switch" },   
            new string[] { "Forwards packets between devices" },                    
            new string[] { "Maps IP addresses to MAC addresses" },                  
            new string[] { "TLS", "HTTP" },                                         
            new string[] { "Unique identifier for network interfaces" },            
            new string[] { "Translates domain names to IP addresses" }              
        };

        int index = 0, correct = 0;

        //check if the user has selected the correct answer with radio buttons
        public void checkAnswer(RadioButton rbt)
        {
            if (allCorrectAnswers[index].Contains(rbt.Text))
            {
                correct++;
            }
            index++;
            setEnable(true);
        }

        //check if the user has selected the correct answers with checkboxes
        public void checkAnswerWithCheckBox()
        {
            var selectedItems = new List<string>();

            foreach (CheckBox cb in currentCheckboxes)
            {
                if (cb.Checked)
                {
                    selectedItems.Add(cb.Text);
                }
            }

            // For questions with multiple correct answers, check if user selected all required answers
            bool allCorrect = true;

            // Check if all required answers are selected
            foreach (string correctAnswer in allCorrectAnswers[index])
            {
                if (!selectedItems.Contains(correctAnswer))
                {
                    allCorrect = false;
                    break;
                }
            }

            // Check if no incorrect answers are selected
            foreach (string selectedItem in selectedItems)
            {
                if (!allCorrectAnswers[index].Contains(selectedItem))
                {
                    allCorrect = false;
                    break;
                }
            }

            if (allCorrect)
            {
                correct++;
            }

            index++;
            setEnable(true);
        }

        // create a function to uncheck radiobuttons and checkboxes
        public void uncheck()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;

            foreach (CheckBox cb in currentCheckboxes)
            {
                cb.Checked = false;
            }
        }

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

        // clear all current checkboxes from form
        private void clearCheckboxes()
        {
            foreach (CheckBox cb in currentCheckboxes)
            {
                this.Controls.Remove(cb);
            }
            currentCheckboxes.Clear();
        }

        // enable/disable radiobuttons and checkboxes
        public void setEnable(Boolean yn)
        {
            if (index < 10)  // First 10 questions use RadioButtons
            {
                radioButton1.Enabled = yn;
                radioButton2.Enabled = yn;
                radioButton3.Enabled = yn;
            }
            else  // Questions 11-15 use CheckBoxes
            {
                foreach (CheckBox cb in currentCheckboxes)
                {
                    cb.Enabled = yn;
                }
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            // call the button click event
            button1.PerformClick();
            UpdateButtonHandler();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

            if (index == questions.Length)
            {
                percent = ((float)correct / (float)questions.Length) * 100;
                // Format percentage to 2 decimal places
                string formattedPercent = percent.ToString("F2");
                richTextBox1.Text = "Your Score:" + correct + " / " + questions.Length + " ---> " + formattedPercent + "%";
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                clearCheckboxes();

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
                setEnable(true);
                uncheck();

                richTextBox1.Text = questions[index];

                if (index < 10)  // RadioButton-based questions
                {
                    clearCheckboxes();

                    radioButton1.Visible = true;
                    radioButton2.Visible = true;
                    radioButton3.Visible = true;

                    HashSet<string> uniqueChoices = new HashSet<string>
                          {
                                     options[index, 0],
                                     options[index, 1],
                                     options[index, 2]
                          };

                    uniqueChoices.Add(options[index, 3]);

                    // Convert to list and randomize
                    List<string> choices = uniqueChoices.ToList();
                    choices = choices.OrderBy(x => rnd.Next()).ToList();

                    // Assign to radio buttons
                    radioButton1.Text = choices[0];
                    radioButton2.Text = choices[1];
                    radioButton3.Text = choices[2];
                }
                else  // CheckBox-based questions (Questions 11-15)
                {
                    // Hide radio buttons
                    radioButton1.Visible = false;
                    radioButton2.Visible = false;
                    radioButton3.Visible = false;

                    // Clear previous checkboxes
                    clearCheckboxes();

                    // Create a set of unique options
                    HashSet<string> uniqueChoices = new HashSet<string>
            {
                options[index, 0],
                options[index, 1],
                options[index, 2]
            };

                    // Ensure the correct answers are included
                    foreach (string correctAnswer in allCorrectAnswers[index])
                    {
                        uniqueChoices.Add(correctAnswer);
                    }


                    List<string> choices = uniqueChoices.ToList();
                    choices = choices.OrderBy(x => rnd.Next()).ToList();


                    int topPosition = radioButton1.Location.Y;
                    int leftPosition = radioButton1.Location.X;


                    foreach (string choice in choices)
                    {
                        CheckBox cb = new CheckBox
                        {
                            Text = choice,
                            Location = new Point(leftPosition, topPosition),
                            AutoSize = true
                        };

                        topPosition += 25;
                        this.Controls.Add(cb);
                        currentCheckboxes.Add(cb);
                    }

                    button1.Text = "N3xt";
                }

                if (index == questions.Length - 1)
                {
                    button1.Text = "Finish Quiz";
                }
                else if (index < 10)
                {
                    button1.Text = "Next";
                }
            }
        }
        private void evaluateCurrentQuestion()
        {
            if (index < questions.Length)
            {
                if (index < 10) // Radio button questions
                {
                }
                else // Checkbox questions
                {
                    checkAnswerWithCheckBox();
                }
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (index >= 10 && index < questions.Length &&
         (button1.Text == "N3xt" || button1.Text == "Finish Quiz"))
            {
                // Check if any checkbox is selected
                bool anyChecked = false;
                foreach (CheckBox cb in currentCheckboxes)
                {
                    if (cb.Checked)
                    {
                        anyChecked = true;
                        break;
                    }
                }

                // If no checkboxes are selected, show a message and return
                if (!anyChecked)
                {
                    MessageBox.Show("Please select at least one answer before submitting.",
                        "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; // Don't proceed to the next question
                }

                // If checkboxes are selected, evaluate and continue
                evaluateCurrentQuestion();
            }

            // Then proceed with the standard button1_Click functionality
            button1_Click(sender, e);
        }
        public void UpdateButtonHandler()
        {
            // Remove existing click handler if needed
            button1.Click -= button1_Click;

            // Add the new click handler
            button1.Click += nextButton_Click;
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            checkAnswer(radioButton1);
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            checkAnswer(radioButton2);
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            checkAnswer(radioButton3);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // Keep this empty event handler
        }
    }
}
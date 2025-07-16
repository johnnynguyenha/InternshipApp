using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Utilities;

namespace InternshipApp
{
    public partial class Script : Form
    {

        // dictionaries containing commands and their options 
        Dictionary<string, List<string>> settings = new Dictionary<string, List<string>>
        {
            { "HOME", new List<string> { "ALL", "R", "Z", "T" } },
            { "MOVE", new List<string> { "R", "T", "Z", } },
            { "GOTO", new List<string> { "N", "Z", "R"} }
        };
        // dictionary contains second set of options if applicable
        Dictionary<string, List<string>> settings2 = new Dictionary<string, List<string>>
        {
            { "HOME", new List<string> {  } },
            { "MOVE", new List<string> { "REL", "ABS" } },
            { "GOTO", new List<string> { "ARM" } }
        };

        public event EventHandler RunScriptClicked;
        private static readonly log4net.ILog log = LogHelper.GetLogger();
        public bool _isLooping;
        public System.Windows.Forms.Button RunScriptButton => runScriptButton;
        public Script()
        {
            InitializeComponent();
            try
            {
                commandBox.Items.AddRange(settings.Keys.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred when trying to load commands");
                log.Error("Error loading commands from Dictionary", ex);
            }
        }

        // return values from scriptTextBox
        public Array ScriptText
        {
            get { return scriptTextBox.Lines.ToArray<string>(); }
        }

        // return how many loops to do
        public int LoopText
        {
            get { if (int.TryParse(loopTextBox.Text, out int amount)) { return amount; }; return 0; }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        // when selecting a command, populate the panels with options
        private void commandBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear old checkboxes
            panel1.Controls.Clear();
            panel2.Controls.Clear();

            string selectedItem = commandBox.SelectedItem.ToString();
            if (!settings.ContainsKey(selectedItem)) return;

            List<string> options = settings[selectedItem];
            List<string> options2 = settings2[selectedItem];
            int y = 10;

            try
            {
                foreach (string option in options)
                {
                    CheckBox cb = new CheckBox();
                    cb.Text = option;
                    cb.Location = new Point(10, y);
                    cb.AutoSize = true;

                    cb.CheckedChanged += (s, evt) =>
                    {
                        if (cb.Checked)
                        {
                            foreach (Control ctrl in panel1.Controls)
                            {
                                if (ctrl is CheckBox otherCb && otherCb != cb)
                                {
                                    otherCb.Checked = false;
                                }
                            }
                        }
                    };

                    panel1.Controls.Add(cb);
                    y += 30;
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Error occurred when trying to load options");
                log.Error("Error populating first panel with checkboxes", ex);
                return;
            }
            y = 10;
            try {
                foreach (string option2 in options2)
                {
                    CheckBox cb2 = new CheckBox();
                    cb2.Text = option2;
                    cb2.Location = new Point(10, y);
                    cb2.AutoSize = true;

                    cb2.CheckedChanged += (s, evt) =>
                    {
                        if (cb2.Checked)
                        {
                            foreach (Control ctrl in panel2.Controls)
                            {
                                if (ctrl is CheckBox otherCb && otherCb != cb2)
                                {
                                    otherCb.Checked = false;
                                }
                            }
                        }
                    };

                    panel2.Controls.Add(cb2);
                    y += 30;
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Error occurred when trying to load options");
                log.Error("Error populating second panel with checkboxes", ex);
                return;
            }
        }

        // function to add command to the script
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (commandBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select a command first.");
                    return;
                }
                // Find the checked checkbox from panel1
                CheckBox selectedCb1 = panel1.Controls.OfType<CheckBox>().FirstOrDefault(cb => cb.Checked);
                if (selectedCb1 == null)
                {
                    MessageBox.Show("Please select an option from the first group.");
                    return;
                }
                if (selectedCb1.Text != "ALL")
                {
                    if (string.IsNullOrEmpty(amountTextBox.Text))
                    {
                        MessageBox.Show("Please enter an amount.");
                        return;
                    }
                    if (!int.TryParse(amountTextBox.Text, out int amount) || amount < 0)
                    {
                        MessageBox.Show("Please enter a valid non-negative integer for the amount.");
                        return;
                    }
                    scriptTextBox.AppendText(commandBox.SelectedItem.ToString() + " " + selectedCb1.Text + " " + amountTextBox.Text);


                }
                else
                {
                    scriptTextBox.AppendText(commandBox.SelectedItem.ToString() + " " + selectedCb1.Text);
                }
                // Optionally add rel/abs if selected
                int currentLine = scriptTextBox.GetLineFromCharIndex(scriptTextBox.SelectionStart);

                // additional line remover logic to remove line if requirements not met
                List<string> lines = scriptTextBox.Lines.ToList();
                CheckBox selectedCb2 = panel2.Controls.OfType<CheckBox>().FirstOrDefault(cb => cb.Checked);

                if (selectedCb2 != null)
                {
                    if (commandBox.SelectedItem == "GOTO" && string.IsNullOrEmpty(amount2TextBox.Text))
                    {
                        MessageBox.Show("Please enter an amount from the second group,");
                        if (currentLine >= 0 && currentLine < lines.Count)
                        {
                            lines.RemoveAt(currentLine);
                            scriptTextBox.Lines = lines.ToArray();
                            if (lines.Count > 0) // only append a new line if we're not at the beginning
                            {
                                scriptTextBox.AppendText(Environment.NewLine); // Add newline
                            }
                        }
                        return;
                    }
                    else if (commandBox.SelectedItem == "GOTO" && !string.IsNullOrEmpty(amount2TextBox.Text))
                    {
                        scriptTextBox.AppendText(" " + selectedCb2.Text + " " + amount2TextBox.Text);
                    }
                    else
                    {
                        scriptTextBox.AppendText(" " + selectedCb2.Text);
                    }
                }
                scriptTextBox.AppendText(Environment.NewLine); // Add newline
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred when adding the command");
                log.Error("Error adding command to script", ex);
            }
        }
        private void Script_Load_1(object sender, EventArgs e)
        {

        }

        // function to save script to a txt file
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(scriptTextBox.Text))
            {
                MessageBox.Show("Please enter a script to save.");
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                Title = "Save Script"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllText(saveFileDialog.FileName, scriptTextBox.Text);
                    MessageBox.Show("Script saved successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred when saving the script");
                    log.Error("Error saving script to file", ex);
                }
            }
        }

        // function to run current script
        private void runScriptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(scriptTextBox.Text))
                {
                    MessageBox.Show("Please enter a script to run.");
                    return;
                }
                if (loopTextBox.Text == string.Empty)
                {
                    MessageBox.Show("Please enter the number of loops to run.");
                    return;
                }
                if (!int.TryParse(loopTextBox.Text, out int loops) || loops <= 0)
                {
                    MessageBox.Show("Please enter a valid number of loops greater than 0.");
                    return;
                }

                runScriptButton.Enabled = false;
                RunScriptClicked?.Invoke(this, EventArgs.Empty);
            } catch (Exception ex)
            {
                MessageBox.Show("Error occurred when attempting to run the script");
                log.Error("Error running script", ex);
            }
        }

        // function to load script from txt file
        private void loadScriptButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                Title = "Load Script"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    scriptTextBox.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
                    MessageBox.Show("Script loaded successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred when trying to load the script from file");
                    log.Error("Error loading script from file", ex);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                scriptTextBox.ReadOnly = false;
            } else
            {
                scriptTextBox.ReadOnly = true;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var lines = scriptTextBox.Lines.ToList();

            // Remove any trailing empty lines
            while (lines.Count > 0 && string.IsNullOrWhiteSpace(lines.Last()))
            {
                lines.RemoveAt(lines.Count - 1);
            }

            if (lines.Count > 0)
            {
                lines.RemoveAt(lines.Count - 1);
                scriptTextBox.Lines = lines.ToArray();
                if (lines.Count > 0) // ensure that a newline is only created if there is still a line left.
                {
                    scriptTextBox.AppendText(Environment.NewLine); // Add newline
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            scriptTextBox.Text = "";
        }
    }
}

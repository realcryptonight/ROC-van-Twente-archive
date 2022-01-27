using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MDI
{
    public partial class opgave1 : Form
    {
        public opgave1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// This will fill the left and right listbox with randonm numbers.
        /// </summary>
        private void fill_random_Click(object sender, EventArgs e)
        {
            int[] leftnumbers = new int[8];
            int[] rightnumbers = new int[8];
            leftlistbox.Items.Clear();
            rightlistbox.Items.Clear();
            leftlistbox.BeginUpdate();
            rightlistbox.BeginUpdate();
            Random random = new Random();
            for (int i = 0; i < 2; i++)
            {
                for (int n = 0; n < 8; n++)
                {
                    int num = random.Next(0, 19);
                    if (i == 0)
                    {
                        bool isallowed = true;
                        foreach (int number in leftnumbers)
                        {
                            if (number == num) { isallowed = false; }
                        }
                        if (isallowed)
                        {
                            leftnumbers[n] = num;
                            leftlistbox.Items.Add(num);
                        }
                        else
                        {
                            n--;
                        }
                    }
                    else
                    {
                        bool isallowed = true;
                        foreach (int number in rightnumbers)
                        {
                            if (number == num) { isallowed = false; }
                        }
                        if (isallowed)
                        {
                            rightnumbers[n] = num;
                            rightlistbox.Items.Add(num);
                        }
                        else
                        {
                            n--;
                        }
                    }
                }
            }
            leftlistbox.EndUpdate();
            rightlistbox.EndUpdate();
        }

        /// <summary>
        /// Sends an message box with some info of what it should do.
        /// </summary>
        private void explain_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Zorg ervoor dat beide listboxen gevuld worden met 8 ongelijke random getallen onder de 20" + Environment.NewLine + Environment.NewLine + "Als de knop '>' drukt moet je het item van links naar rechts verplaatsen mits het rechts NIET voorkomt. Als het item rechts wel voorkomt moet je het enkel links verwijderen." + Environment.NewLine + "Voor knop '<' hetzelfde maar dan andersom" + Environment.NewLine + Environment.NewLine + "Knopje '<<' en '>>' moeten hetzelfde gedrag geautomatiseerd vertonen.");
        }

        /// <summary>
        /// Add the 2 selected values from the left and right listbox together.
        /// Then output the result on the output_textbox.
        /// </summary>
        private void sum_selected_Click(object sender, EventArgs e)
        {
            if (leftlistbox.SelectedItem != null && rightlistbox.SelectedItem != null)
            {
                int sum = int.Parse(leftlistbox.GetItemText(leftlistbox.SelectedItem)) + int.Parse(rightlistbox.GetItemText(rightlistbox.SelectedItem));
                output_textbox.Text = sum.ToString();
            }
        }

        /// <summary>
        /// This will remove the selected numbers from the left and/or right listbox.
        /// </summary>
        private void del_selected_Click(object sender, EventArgs e)
        {
            if (leftlistbox.SelectedItem != null)
            {
                leftlistbox.BeginUpdate();
                leftlistbox.Items.RemoveAt(leftlistbox.SelectedIndex);
                leftlistbox.EndUpdate();
            }
            if (rightlistbox.SelectedItem != null)
            {
                rightlistbox.BeginUpdate();
                rightlistbox.Items.RemoveAt(rightlistbox.SelectedIndex);
                rightlistbox.EndUpdate();
            }
        }

        /// <summary>
        /// This allows the numbers to be moved from left to right and right to left.
        /// The move to is determent by the button text.
        /// </summary>
        private void ChangeNumberPlace_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                if (button.Text == ">")
                {
                    if (leftlistbox.SelectedItem != null)
                    {
                        leftlistbox.BeginUpdate();
                        rightlistbox.BeginUpdate();
                        if (!rightlistbox.Items.Contains(leftlistbox.SelectedItem))
                        {
                            rightlistbox.Items.Add(leftlistbox.SelectedItem);
                        }
                        leftlistbox.Items.RemoveAt(leftlistbox.SelectedIndex);
                        leftlistbox.EndUpdate();
                        rightlistbox.EndUpdate();
                    }
                }
                if (button.Text == "<")
                {
                    if (rightlistbox.SelectedItem != null)
                    {
                        leftlistbox.BeginUpdate();
                        rightlistbox.BeginUpdate();
                        if (!leftlistbox.Items.Contains(rightlistbox.SelectedItem))
                        {
                            leftlistbox.Items.Add(rightlistbox.SelectedItem);
                        }
                        rightlistbox.Items.RemoveAt(rightlistbox.SelectedIndex);
                        leftlistbox.EndUpdate();
                        rightlistbox.EndUpdate();
                    }
                }
            }
            else
            {
                MessageBox.Show("An not existing button triggered the change number function.");
            }
        }

        /// <summary>
        /// This will move all numbers to the left or to the right.
        /// The move to is determent by the button text.
        /// </summary>
        private void MoveEveryNumber_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                if (button.Text == ">>")
                {
                    leftlistbox.BeginUpdate();
                    rightlistbox.BeginUpdate();
                    foreach (int number in leftlistbox.Items)
                    {
                        if (!rightlistbox.Items.Contains(number))
                        {
                            rightlistbox.Items.Add(number);
                        }
                    }
                    leftlistbox.Items.Clear();
                    leftlistbox.EndUpdate();
                    rightlistbox.EndUpdate();
                }
                if (button.Text == "<<")
                {
                    leftlistbox.BeginUpdate();
                    rightlistbox.BeginUpdate();
                    foreach (int number in rightlistbox.Items)
                    {
                        if (!leftlistbox.Items.Contains(number))
                        {
                            leftlistbox.Items.Add(number);
                        }
                    }
                    rightlistbox.Items.Clear();
                    leftlistbox.EndUpdate();
                    rightlistbox.EndUpdate();
                }
            }
            else
            {
                MessageBox.Show("An not existing button triggered the change number function.");
            }
        }
    }
}

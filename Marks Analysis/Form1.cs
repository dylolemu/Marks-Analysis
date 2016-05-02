using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marks_Analysis
{
    public partial class marksAnalysis : Form
    {
        public marksAnalysis()
        {
            InitializeComponent();
        }
        bool canClick = false;
        int n;
        List<int> grades = new List<int>() { };
        private void addButton_Click(object sender, EventArgs e)
        {
           
            try
            {
                label1.Text = "";
                n=(int.Parse(marksBox.Text));//changes text into integer
                if (n >= 0 && n <=100)//numbers has to be in between 0-100
                {
                    canClick = true;//analyze button can be clicked
                    grades.Add(n);//adds it to list
                    label3.Text = "";
                }
                else { label3.Text = "Must enter number between 0-100"; }//if number is not in between 0-100

            }
            catch (FormatException)
            {
                label3.Text = "You must enter an integer";//if text is not a number
            }
            catch (IndexOutOfRangeException)
            {
                label3.Text = "Array is full";
            }
            for (int i = 0; i < grades.Count(); i++)
            {
                grades.Sort();//sorts list numbers in order
                label1.Text += "\n" + grades[i] + "%";//organizes the marks and adds percent
            }
            marksBox.Clear();
        }

        private void analyzeButton_Click(object sender, EventArgs e)
        {
            if (canClick == true)
            {
                label3.Text = "";
                int avg = 0;
                int avg1 = 0;
                int levelR = 0;
                int level1 = 0;
                int level2 = 0;
                int level3 = 0;
                int level4 = 0;
                int minimum = 0;
                int maximum = 0;
                for (int i = 0; i < grades.Count(); i++)
                {
                    avg1 += grades[i];//adds all numbers in the list
                    if (minimum == 0)
                    {
                        //minimum and maximum is equal to first grade inputed
                        maximum = grades[i];
                        minimum = grades[i];
                    }
                    if (minimum > 0 || maximum > 0)
                    {
                        //if mimimum is greater than new grade inputed then it changes to that number
                        if (minimum > grades[i])
                        {
                            minimum = grades[i];
                        }
                        //if maximum is less than new grade inputed then it changes to that number
                        if (maximum < grades[i])
                        {
                            maximum = grades[i];
                        }
                    }
                    if (grades[i] < 50)//if less than 50
                    {
                        levelR += 1;
                    }
                    if (grades[i] >= 50 && grades[i] < 60)//if more than 50 but less than 60
                    {
                        level1 += 1;
                    }
                    if (grades[i] >= 60 && grades[i] < 70)//if more than 60 but less than 70
                    {
                        level2 += 1;
                    }
                    if (grades[i] >= 70 && grades[i] < 80)//if more than 70 but less than 80
                    {
                        level3 += 1;
                    }
                    if (grades[i] >= 80)//if more than 80
                    {
                        level4 += 1;
                    }
                }
                avg = avg1 / grades.Count();//divides sum of all list numbers by total numbers in list
                //writes all the values wanted
                label2.Text = "\nClass Average:     " + avg + "%";
                label2.Text += "\nMinimum Mark:    " + minimum + "%";
                label2.Text += "\nMaximum Mark:   " + maximum + "%";
                label2.Text += "\nRange of Marks:   " + (maximum - minimum);
                label2.Text += "\nNumber at Level R: " + levelR;
                label2.Text += "\nNumber at Level 1: " + level1;
                label2.Text += "\nNumber at Level 2: " + level2;
                label2.Text += "\nNumber at Level 3: " + level3;
                label2.Text += "\nNumber at Level 4: " + level4;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            canClick = false;//analyze button can no longer be clicked
            label1.Text = "";
            label2.Text = "";
            grades.Clear();//clears all numbers in list
        }
    }
}
 
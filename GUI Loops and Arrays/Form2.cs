﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Loops_and_Arrays
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTitle titleform = new FormTitle();
            titleform.Show();
        }

        private void foregroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog forecolor = new ColorDialog();
            forecolor.AllowFullOpen = true;
            if (forecolor.ShowDialog() == DialogResult.OK)
            {
                tabPageHome.ForeColor = forecolor.Color;
                tabPageExamples.ForeColor = forecolor.Color;
            }
;        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog backcolor = new ColorDialog();
            backcolor.AllowFullOpen = true;
            if (backcolor.ShowDialog() == DialogResult.OK)
            {
                tabPageHome.BackColor = backcolor.Color;
                tabPageExamples.BackColor = backcolor.Color;
            }
        }

        private void lightThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabPageExamples.ForeColor = Color.Black;
            tabPageHome.ForeColor = Color.Black;
            tabPageExamples.BackColor = Color.White;
            tabPageHome.BackColor = Color.White;
        }

        private void darkThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabPageExamples.ForeColor = Color.White;
            tabPageHome.ForeColor = Color.White;
            tabPageExamples.BackColor = Color.FromArgb(40, 44, 52);
            tabPageHome.BackColor = Color.FromArgb(40, 44, 52);
        }

        private void draculaToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            tabPageExamples.ForeColor = Color.FromArgb(180, 120, 206);
            tabPageHome.ForeColor = Color.FromArgb(180, 120, 206);
            tabPageExamples.BackColor = Color.FromArgb(40, 44, 52);
            tabPageHome.BackColor = Color.FromArgb(40, 44, 52);
        }

        private void walkthroughEventHappened(CheckBox checkbox)
        {
            checkbox.CheckState = CheckState.Checked; 
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sample");
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            checkBoxCMS.CheckState = CheckState.Unchecked;
            checkBoxHelp.CheckState = CheckState.Unchecked;
            checkBoxHome.CheckState = CheckState.Unchecked;
            checkBoxMS.CheckState = CheckState.Unchecked;
            checkBoxUI.CheckState = CheckState.Unchecked;
        }

        private void forLoopToolStripMenuItemExample_Click(object sender, EventArgs e)
        {
            walkthroughEventHappened(checkBoxMS);
        }

       


    }
}

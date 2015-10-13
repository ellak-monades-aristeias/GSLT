using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leap;
using LeapGSLT;

namespace WindowsFormsApplication1
{        
    public partial class Form1 : Form
    {
        public static LeapListener leap_listener;
        public static Controller leap_controller;

        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "Paused";            
            leap_controller.RemoveListener(leap_listener);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Waiting for user input...";
            leap_controller.AddListener(leap_listener);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnStop_Click_1(object sender, EventArgs e)
        {
            lblStatus.Text = "Paused";
        }

        private void initializeLeapListener()
        {
            // Create a listener and controller
            leap_listener = new LeapListener();
            leap_controller = new Controller();

            // Have the listener receive events from the controller
            leap_controller.AddListener(leap_listener);
        }
        
    }    
}

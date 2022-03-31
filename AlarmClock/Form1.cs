using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlarmClock
{
    public partial class Form1 : Form
    {
        String selectedHour;
        String selectedMinute;
        String selectedSecond;
        System.Timers.Timer timer;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("test 123");
            for (int i = 0; i < 24; i++) {
                this.comboBox1.Items.Add(i.ToString());
            }
            for (int i = 0; i < 60; i++)
            {
                this.comboBox2.Items.Add(i.ToString());
            }
            for (int i = 0; i < 60; i++)
            {
                this.comboBox3.Items.Add(i.ToString());
            }

            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("inside");
            DateTime currentTime = DateTime.Now;
            
            Boolean hourMatched = int.Parse(this.selectedHour) == currentTime.Hour;
            Boolean minutesMatched = int.Parse(this.selectedMinute) == currentTime.Minute;
            Boolean secondsMatched = int.Parse(this.selectedSecond) == currentTime.Second;

            if (hourMatched && minutesMatched && secondsMatched)
            {
                MessageBox.Show("Alarm time");
                timer.Stop();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String hours = comboBox1.SelectedItem != null ? comboBox1.SelectedItem.ToString() : "0";
            String minutes = comboBox2.SelectedItem != null ? comboBox2.SelectedItem.ToString() : "0";
            String seconds = comboBox3.SelectedItem != null ? comboBox3.SelectedItem.ToString() : "0";

            this.selectedHour = hours;
            this.selectedMinute = minutes;
            this.selectedSecond = seconds;

            this.label1.Text = hours;
            this.label2.Text = minutes;
            this.label3.Text = seconds;

            timer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.label1.Text = "00";
            this.label2.Text = "00";
            this.label3.Text = "00";

            this.selectedSecond = null;
            this.selectedHour = null;
            this.selectedMinute = null;
        }
    }
}

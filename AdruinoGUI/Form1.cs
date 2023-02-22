using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdruinoGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // serialPort1.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            port.Write("A");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            port.Write("B");
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            Thread masterthread;
            masterthread = new Thread(runit);
            masterthread.Start();
            port = new SerialPort(comboBox1.Text, Convert.ToInt32(textBox1.Text));
            port.Open();
        }

        SerialPort port;
        String GetValue;
        void runit()
        {
            while (true)
            {
                try
                {
                    if (port.IsOpen==true)
                            {
                        GetValue = port.ReadLine();
                        _ = chart1.Invoke((MethodInvoker)(() => chart1.Series["Series1"].Points.AddXY(DateTime.Now.ToLongTimeString(), Convert.ToInt32(GetValue))));
                    }
                }
                catch(Exception ex)
                {

                }
            }
        }
    }
}

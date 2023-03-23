using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AdruinoGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // serialPort1.Open();
        }

        //void InitRichTextBox()
        //{
            //Init rtbTest...

        //    richTextBox1_textReciever.HideSelection = false;//Hide selection so that AppendText will auto scroll to the end
        //}

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

            masterthread = new Thread(BoxUpdate);
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
                        int number;

                        bool isParsable = Int32.TryParse(GetValue, out number);
                        if (isParsable)
                        {
                            _ = chart1.Invoke((MethodInvoker)(() => chart1.Series["Series1"].Points.AddXY(DateTime.Now.ToLongTimeString(), number)));
                        }
                           // Console.WriteLine(number);
                        else
                        {
                            //richTextBox1_textReciever.Text += GetValue;
                            //richTextBox1_textReciever.Text += GetValue;
                            //richTextBox1_textReciever.SelectionStart = richTextBox1_textReciever.Text.Length;
                            //richTextBox1_textReciever.ScrollToCaret();
                            //richTextBox1_textReciever_TextChanged();

                            this.Invoke(new EventHandler(ShowData));

                            // Console.WriteLine(GetValue);
                        }
                        //Console.WriteLine("Could not be parsed.");

                        //_ = chart1.Invoke((MethodInvoker)(() => chart1.Series["Series1"].Points.AddXY(DateTime.Now.ToLongTimeString(), Convert.ToInt32(GetValue))));
                    }
                }
                catch(Exception ex)
                {

                }

            }

        }

        void BoxUpdate()
        {

        }
        private void ShowData(Object sender, EventArgs e)
        {
            //richTextBox1_textReciever.Text += GetValue;
            richTextBox1_textReciever.Focus();
            richTextBox1_textReciever.AppendText(GetValue);
        }
    }
}

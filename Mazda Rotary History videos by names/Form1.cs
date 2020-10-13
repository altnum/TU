using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace RotaryH
{
    public partial class Form1 : Form
    {
        int counter = 0;
        public Form1()
        {
                InitializeComponent();
            using (StreamReader f = File.OpenText(@"D:\\Rotary Book\videos\list.txt"))
            {
                while (!f.EndOfStream)
                {
                    list1.Items.Add(f.ReadLine());
                    counter++;
                }
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            if (list1.Items.Contains(textBox1.Text))
            {
                list1.SetSelected(list1.FindString(textBox1.Text), list1.Items.Contains(textBox1.Text));
            }
            else
            {
                MessageBox.Show("The item does not exist in the list.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!list1.Items.Contains(textBox1.Text))
            {
                list1.Items.Add(textBox1.Text);
                counter++;
            }
            else
            {
                MessageBox.Show("The video is already in the list.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            list1.Items.Remove(list1.SelectedItem);
            counter--;
        }

        private void Open_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            ProcessStartInfo pi = new ProcessStartInfo();
            pi.UseShellExecute = true;
            int error = 0;
            try
            {
                string path = list1.SelectedItem.ToString();
                pi.FileName = @"D:\\Rotary Book\videos\" + path + ".mp4";
            }
            catch {
                MessageBox.Show("You might want to select a video firstly!");
                error = 1;
            }
            p.StartInfo = pi;

            if (error == 0)
            try
            {
                p.Start();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            FileStream f = File.Open(@"D:\\Rotary Book\videos\list.txt", FileMode.Create, FileAccess.Write);
            if (counter < 0)
                counter = 0;
            object[] arr = new object [counter];
            list1.Items.CopyTo(arr, 0);

            for (int i = 0; i < arr.Length; i++)
            {
                byte[] lineBytes = Encoding.UTF8.GetBytes(arr[i].ToString());
                f.Write(lineBytes, 0, lineBytes.Length);
                string newLine = "\n";
                byte[] newLineBytes = Encoding.UTF8.GetBytes(newLine);
                f.Write(newLineBytes, 0, newLine.Length);
            }
            f.Close();
        }
    }
}

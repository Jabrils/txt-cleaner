using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace txt_cleaner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] allTxts = Directory.GetFiles("txt");

            // 
            for (int i = 0; i < allTxts.Length; i++)
            {
                CleanUp(allTxts[i]);
            }
        }

        void CleanUp(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            string list = reader.ReadToEnd();
            reader.Close();

            string[] repl = new string[] { ",", "?", "(", ")", "-", ":", "!", "'", "\"", " ", };

            // 
            for (int i = 0; i < repl.Length; i++)
            {
                list = list.Replace(repl[i], string.Empty);
            }

            string[] nList = list.Split('\n');

            List<string> final = new List<string>();

            for (int i = 0; i < nList.Length; i++)
            {
                if(!string.IsNullOrWhiteSpace(nList[i]) && nList[i].Length>2 && !final.Contains(nList[i]))
                {
                    final.Add(nList[i]);
                }
            }

            string write = "";

            // 
            for (int i = 0; i < final.Count; i++)
            {
                string ender = "";

                // 
                if (i!=final.Count-1)
                {
                    ender = ",";
                }
                write += final[i] + ender;
            }

            Console.Write(write);

            StreamWriter writer = new StreamWriter(fileName);
            writer.Write(write);
            writer.Close();

        }
    }
}

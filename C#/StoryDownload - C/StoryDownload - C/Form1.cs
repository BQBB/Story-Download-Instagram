using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

namespace StoryDownload___C
{
    public partial class Form1 : Form
    {
        

       

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("This Project Coded By > MrVirus\nInstagram : BQBB\nTelegram : camera");
        }
        public static string getid(string user)
        {

            WebClient web = new WebClient();
          
            var result = web.DownloadString("https://www.instagram.com/" + user);
            string ids=Regex.Match(result, ":\"profilePage_(.*?)\",").Groups[1].Value;
            return ids;
        }
        public void  downloader(string id)
        {
            string Path = System.Environment.CurrentDirectory;
            string url = "http://mrvirus.cf/StoryDownload.php?id="+id;
            WebClient web = new WebClient();
            WebClient download = new WebClient();
            string result = web.DownloadString(url);
            MatchCollection re = Regex.Matches(result, "{URL:(.*?)}");
            int ib = 0;
            foreach (Match x in re)
            {
                if (x.Groups[1].Value.Contains("mp4"))
                {
                    download.DownloadFile(x.Groups[1].Value, Path+"\\vid" + textBox1.Text + Convert.ToString(ib) + ".mp4");
                    ib += 1;

                }
                else
                {
                    download.DownloadFile(x.Groups[1].Value, Path + "\\Photo" + textBox1.Text + Convert.ToString(ib) + ".jpg");
                     ib += 1;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = getid(textBox1.Text);
            downloader(id);


        }
    }
}

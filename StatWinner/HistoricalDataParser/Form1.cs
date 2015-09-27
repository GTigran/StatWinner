//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using BLL.DataParser.Soccerstand;
//using Log.BLL;

//namespace HistoricalDataParser
//{
//    public partial class Form1 : Form
//    {
//        public Form1()
//        {
//            InitializeComponent();
//               /*
//            webKitBrowser1. += delegate(object o, EventArgs args)
//            {
//                int k = 0;
//            };*/

//        }

//        private void button1_Click(object sender, EventArgs e)
//        {
//            //Loger.WriteLog("Subject", "Message", "additional Info", "AdditionalURL", LogSeverity.Error);

//            //var log = Loger.DequeueLastLog();

//            return;

//            var matchId = "l2YM7JvJ";

//            var socerstandParser = new SoccerstandDataParser();

//            socerstandParser.ParseSingleMatch(matchId, delegate
//            {
//                int k = 0;

//            });

//            return;
//           // webKitBrowser1.Navigate("http://www.soccerstand.com");

//            var webBrowser = new WebBrowser();

//            webBrowser.Navigate("http://www.soccerstand.com");

//            webBrowser.ProgressChanged += delegate(object o, WebBrowserProgressChangedEventArgs args)
//            {
//                if (args.CurrentProgress == 100)
//                {
//                    /*
//                    if (webKitBrowser1.Document.GetElementById("fs") != null)
//                    {
                        
//                    }*/
//                }

//            };


//        }
//    }
//}

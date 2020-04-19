using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sortingSoftware
{
    public partial class Form1 : Form
    {
        string path;
        string searchFolder;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection.";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                searchFolder = Path.GetDirectoryName(folderBrowser.FileName);
                // ...
            }



            //String searchFolder = @"C:\Users\Jens\Desktop\sort";
            bool isRecursive = false;
            if (checkBox1.Checked)
            {
                isRecursive = true;
            }
            var filters = new String[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp", "svg", "mp4" };
            var files = GetFilesFrom(searchFolder, filters, isRecursive);



            foreach (var file in files)
            {

                DateTime creation = File.GetLastWriteTime(file);
                string yearMonth = creation.Year.ToString() + creation.Month.ToString();
                string yearMonthDay_dayOfTheWeek = creation.Year.ToString() + creation.Month.ToString() + creation.Day.ToString() + "_" + creation.DayOfWeek;


                string extension = Path.GetExtension(file);

               

                    path = searchFolder + "\\" + yearMonth;// + "\\videos";

               
                try
                {
                    if (Directory.Exists(path))
                    {

                    }
                    else
                    {
                        DirectoryInfo di = Directory.CreateDirectory(path);
                    }


                    /*
                        if (extension == ".mp4")
                    {path = searchFolder + "\\" + yearMonth + "\\" + yearMonthDay_dayOfTheWeek + "\\videos";}
                        else if (extension == ".jpg")
                    {path = searchFolder + "\\" + yearMonth + "\\" + yearMonthDay_dayOfTheWeek + "\\images";}
                    */
                    path = searchFolder + "\\" + yearMonth + "\\" + yearMonthDay_dayOfTheWeek; 
                    if (Directory.Exists(path)){}
                        else{DirectoryInfo di = Directory.CreateDirectory(path);}
                        File.Move(file, path + "\\" + Path.GetFileName(file));
                    

                }
                catch (Exception exc)
                {
                }
                finally { }

            }
        }

                   /*
                    month exist? 
                        create
                            
                    */ 
                    

                // find month if not exist -> create 
                // check if folder exists
                /*
                 if not create folder with date  
                    if file is mp4 create folder if mp4 not exist
                    if file is image create folder if mp4 not exist

                 */

            




        

        public static String[] GetFilesFrom(String searchFolder, String[] filters, bool isRecursive)
        {
            List<String> filesFound = new List<String>();
            // Topdirectoryonly // alldirectories
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, String.Format("*.{0}", filter), searchOption));
            }
            return filesFound.ToArray();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if( checkBox1.Checked )
            {
               
            }
        }
    }
}

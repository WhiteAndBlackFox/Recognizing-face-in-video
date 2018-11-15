using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultiFaceRec
{
    public partial class BD : Form
    {
        public BD()
        {
            InitializeComponent();
        }

        private void BD_Load(object sender, EventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo("TrainedFaces/");

            var listName = new List<String>();

            StreamReader streamReader = new StreamReader("TrainedFaces/names.txt");
            String name = "";
            while(name != null)
            {
                name = streamReader.ReadLine();
                if ( name != null) {
                    listName.Add(name);
                }
            }

            foreach (FileInfo file in dir.GetFiles())

            {

                try

                {

                    this.imageList1.Images.Add(Image.FromFile(file.FullName));
                    //listName.Add(file.Name);
                }

                catch
                {

                    Console.WriteLine("This is not an image file");

                }

            }

            this.listView1.View = View.LargeIcon;

            this.imageList1.ImageSize = new Size(32, 32);

            this.listView1.LargeImageList = this.imageList1;

            //or

            //this.listView1.View = View.SmallIcon;

            //this.listView1.SmallImageList = this.imageList1;



            for (int j = 0; j < this.imageList1.Images.Count; j++)

            {

                ListViewItem item = new ListViewItem();

                item.ImageIndex = j;

                this.listView1.Items.Add(item);

                this.listView1.Items[this.listView1.Items.Count - 1].Text = listName[j];

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(listView1.SelectedIndices[0].ToString());
            string face = Application.StartupPath + "/TrainedFaces/face" + listView1.SelectedIndices[0].ToString() + ".bmp";
            //File.Delete(Application.StartupPath + "/TrainedFaces/" + face);

            /* StreamReader reader = new StreamReader(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
            string content = reader.ReadToEnd();
            reader.Close();
            
            content = Regex.Replace(content, searchText, replaceText);

            StreamWriter writer = new StreamWriter(filePath);
            writer.Write(content);
            writer.Close();*/
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PainWindowsForms
{
    public partial class NewSongWindow : Form
    {
        public SongsContainer songsContainer;
        public string[] types = { "Rock", "Pop", "Rap" };
        public int currentType =0;
        public NewSongWindow()
        {
            InitializeComponent();
            //this.comboBox1.SelectedIndex= 0;
        }

        public NewSongWindow(SongsContainer songsContainer)
        {
            
            this.songsContainer = songsContainer;
            InitializeComponent();
            //this.comboBox1.SelectedIndex = 0;
        }

        

        private void save(object sender, EventArgs e)
        {
            if(this.titleTextBox.Text == "" || this.authorTextBox.Text == "")
            {
                errorProvider1.SetError(button1, "wypełnij wszystkie pola");
                return;
            }
            this.songsContainer.AddSong(new Song(this.songsContainer.lastId++,
                this.myControl1.SelectedSongType,
                this.titleTextBox.Text,
                this.authorTextBox.Text,
                this.dateTimePicker1.Value
                ));

            
            this.Close();
        }

        /*private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.currentType = ++this.currentType % 3;
            Console.WriteLine(currentType);
            if (currentType == 0)
            {
                this.pictureBox1.Image = global::PainWindowsForms.Resource.ImageRock;
                this.comboBox1.SelectedIndex = 0;
            }
            else if (currentType == 1)
            {
                this.pictureBox1.Image = global::PainWindowsForms.Resource.ImagePop;
                this.comboBox1.SelectedIndex = 1;
            }
            else
            {
                this.pictureBox1.Image = global::PainWindowsForms.Resource.ImageRap;
                this.comboBox1.SelectedIndex = 2;
            }
        }*/

        private void titleTextBoxValidated(object sender, EventArgs e)
        {
            errorProvider1.SetError(titleTextBox, "");
        }

        private void titleTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(titleTextBox.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(titleTextBox, "Pole nie może być puste");
            }
        }

        private void authorTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(authorTextBox, "");
        }

        private void authorTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(authorTextBox.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(authorTextBox, "Pole nie może być puste");
            }
        }

       /* private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.comboBox1.SelectedIndex == 0)
            {
                this.pictureBox1.Image = global::PainWindowsForms.Resource.ImageRock;
                currentType = 0;
            }
            else if(this.comboBox1.SelectedIndex == 1)
            {
                this.pictureBox1.Image = global::PainWindowsForms.Resource.ImagePop;
                currentType = 1;
            }
            else
            {
                this.pictureBox1.Image = global::PainWindowsForms.Resource.ImageRap;
                currentType = 2;
            }
        }*/
    }
}

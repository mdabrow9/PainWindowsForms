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
    public partial class EditSongWindow : Form
    {
        public SongsContainer songsContainer;

        private int currentType;
        public EditSongWindow()
        {
            InitializeComponent();
        }

        public EditSongWindow(SongsContainer songsContainer)
        {
            this.songsContainer = songsContainer;
            InitializeComponent();

            fillComboBox();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.label2.Visible = true;
            this.label3.Visible = true;
            //this.label4.Visible = true;
            this.label5.Visible = true;

            this.titleTextBox.Visible = true;
            this.authorTextBox.Visible = true;
            this.dateTimePicker1.Visible = true;
            this.button1.Visible = true;
            this.myControl1.Visible = true;
            /*this.comboBox1.Visible = true;
            
            this.pictureBox1.Visible = true;*/
            

            Song selected = this.songsContainer.findSongByListIndex(this.comboBox.SelectedIndex);
            this.titleTextBox.Text = selected.title;
            this.authorTextBox.Text = selected.author;
            this.dateTimePicker1.Value = selected.recordingDate;
            this.myControl1.SelectedSongType = selected.type;
           /* this.comboBox1.SelectedIndex = selected.type;
            this.currentType = selected.type;
            
            if (currentType == 0)
            {
                this.pictureBox1.Image = global::PainWindowsForms.Resource.ImageRock;
               
            }
            else if (currentType == 1)
            {
                this.pictureBox1.Image = global::PainWindowsForms.Resource.ImagePop;
                
            }
            else
            {
                this.pictureBox1.Image = global::PainWindowsForms.Resource.ImageRap;
                
            }*/





        }

        private void fillComboBox()
        {

            foreach (var item in this.songsContainer.songsList)
            {
                this.comboBox.Items.Add(item.ToString());
            }

        }

        /*private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.currentType = ++this.currentType % 3;
            //Console.WriteLine(currentType);
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
            if (this.comboBox1.SelectedIndex == 0)
            {
                this.pictureBox1.Image = global::PainWindowsForms.Resource.ImageRock;
                currentType = 0;
            }
            else if (this.comboBox1.SelectedIndex == 1)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.titleTextBox.Text == "" || this.authorTextBox.Text == "")
            {
                errorProvider1.SetError(button1, "wypełnij wszystkie pola");
                return;
            }

            this.songsContainer.editSong(new Song(this.songsContainer.findSongByListIndex(this.comboBox.SelectedIndex).id,
                this.myControl1.SelectedSongType,
                this.titleTextBox.Text,
                this.authorTextBox.Text,
                this.dateTimePicker1.Value
                ),this.comboBox.SelectedIndex);


            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

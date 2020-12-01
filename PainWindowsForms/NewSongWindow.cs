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
        public Song songToEdit = null;
        public NewSongWindow()
        {
            InitializeComponent();
            
        }

        public NewSongWindow(SongsContainer songsContainer)
        {
            
            this.songsContainer = songsContainer;
            InitializeComponent();
            
        }
        public NewSongWindow(SongsContainer songsContainer, Song song)
        {

            this.songsContainer = songsContainer;
            this.songToEdit = song;
            InitializeComponent();

            this.titleTextBox.Text = this.songToEdit.title;
            this.authorTextBox.Text = this.songToEdit.author;
            this.dateTimePicker1.Value = this.songToEdit.recordingDate;
            this.myControl1.SelectedSongType = this.songToEdit.type;

        }



        private void save(object sender, EventArgs e)
        {
            if(this.titleTextBox.Text == "" || this.authorTextBox.Text == "")
            {
                errorProvider1.SetError(button1, "wypełnij wszystkie pola");
                return;
            }
            if(songToEdit == null)
            {
                this.songsContainer.AddSong(new Song(this.songsContainer.lastId++,
                this.myControl1.SelectedSongType,
                this.titleTextBox.Text,
                this.authorTextBox.Text,
                this.dateTimePicker1.Value
                ));
            }
            else
            {
                this.songsContainer.editSong(new Song(this.songToEdit.id,
                this.myControl1.SelectedSongType,
                this.titleTextBox.Text,
                this.authorTextBox.Text,
                this.dateTimePicker1.Value
                ),this.songToEdit);
            }
            

            
            this.Close();
        }

       

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

       
    }
}

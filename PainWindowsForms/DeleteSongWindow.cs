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
    public partial class DeleteSongWindow : Form
    {
        public SongsContainer songsContainer;
        public DeleteSongWindow()
        {
            InitializeComponent();
        }

        public DeleteSongWindow(SongsContainer songsContainer)
        {
            this.songsContainer = songsContainer;
            InitializeComponent();

            fillComboBox();
            if(this.songsContainer.songsList.Count()!=0)
            {
                this.comboBox1.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.comboBox1.SelectedIndex != -1) this.songsContainer.deleteSong(this.comboBox1.SelectedIndex);
            this.Close();
            //Console.WriteLine(this.comboBox1.SelectedIndex);
        }
        private void fillComboBox()
        {

            foreach (var item in this.songsContainer.songsList)
            {
                this.comboBox1.Items.Add(item.ToString());
            }
           
        }


    }
}

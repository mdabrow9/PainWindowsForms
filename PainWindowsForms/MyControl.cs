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
    public partial class MyControl : UserControl
    {
        private  int currentType;
        
        public MyControl()
        {
            InitializeComponent();
            this.comboBox1.SelectedIndex = 0;
        }

        [Category("SongType")]
        [BrowsableAttribute(true)]
        public int SelectedSongType
        {
            get
            {
                return(int) this.comboBox1.SelectedIndex;
            
            }
            set
            {
                this.comboBox1.SelectedIndex = value%3;
                setPicture(value%3);
                currentType = value % 3;
            }
        }
        private void setPicture(int type)
        {
            if (type == 0)
            {
                this.pictureBox1.Image = global::PainWindowsForms.Resource.ImageRock;
                
            }
            else if (type == 1)
            {
                this.pictureBox1.Image = global::PainWindowsForms.Resource.ImagePop;
                
            }
            else
            {
                this.pictureBox1.Image = global::PainWindowsForms.Resource.ImageRap;
                
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.currentType = ++this.currentType % 3;
            
            if (currentType == 0)
            {
                setPicture(0);
                this.comboBox1.SelectedIndex = 0;
            }
            else if (currentType == 1)
            {
                setPicture(1);
                this.comboBox1.SelectedIndex = 1;
            }
            else
            {
                setPicture(2);
                this.comboBox1.SelectedIndex = 2;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == 0)
            {
                setPicture(0);
                currentType = 0;
            }
            else if (this.comboBox1.SelectedIndex == 1)
            {
                setPicture(1);
                currentType = 1;
            }
            else
            {
                setPicture(2);
                currentType = 2;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

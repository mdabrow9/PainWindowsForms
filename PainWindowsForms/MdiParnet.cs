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
    public partial class MdiParnet : Form
    {
        private int subWindowCount = 1;
        private SongsContainer songsContainer;
        public MdiParnet()
        {
            this.songsContainer = new SongsContainer(this);
            InitializeComponent();
        }

        private void NewWindow(object sender, EventArgs e)
        {
            Form children = new ListWindow(this.songsContainer);
            children.MdiParent = this;
            children.Text = "Utwory Muzyczne " + subWindowCount.ToString();
            this.subWindowCount++;
            children.Show();
            this.showHiddenFunctions();
            
        }

        public void SetStatusBarText(string text)
        {
            this.statusBarText.Text = text;
        }
        private void showHiddenFunctions()
        {
            this.toolStrip2.Visible = true;
        }

        
        

        private void addTestingData(object sender, EventArgs e)
        {
            ((ListWindow)this.MdiChildren[0]).songsContainer.addTestingData();
        }
    }
}

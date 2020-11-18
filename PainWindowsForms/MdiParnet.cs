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
            this.toolStrip1.Visible = true;
        }

        private void showAddSongWindow(object sender, EventArgs e)
        {
            NewSongWindow win = new NewSongWindow(this.songsContainer);
            win.ShowDialog();
        }

        private void showEditSongWindow(object sender, EventArgs e)
        {
            EditSongWindow win = new EditSongWindow(this.songsContainer);
            win.ShowDialog();
        }

        private void showDeleteSongWindow(object sender, EventArgs e)
        {
            DeleteSongWindow win = new DeleteSongWindow(this.songsContainer);
            win.ShowDialog();
        }
        public void refreshAllWindows()
        {
            foreach (var item in this.MdiChildren)
            {
                ((ListWindow)item).refresh();
            }
            
        }

        private void addTestingData(object sender, EventArgs e)
        {
            ((ListWindow)this.MdiChildren[0]).songsContainer.addTestingData();
        }
    }
}

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
    public partial class ListWindow : Form
    { 
        public SongsContainer songsContainer;
        private int selectedFilter;

        public ListWindow()
        {
            InitializeComponent();
           
        }

        public ListWindow(SongsContainer songsContainer)
        {
            this.songsContainer = songsContainer;
            InitializeComponent();

            //this.showAllSongs(null,null);
        }

        private void showItemListView(object sender, EventArgs e)
        {
            this.listView.Visible = true;
            this.treeView.Visible = false;
        }

        private void showItemTreeView(object sender, EventArgs e)
        {
            this.listView.Visible = false;
            this.treeView.Visible = true;
        }

        private void showItemNoneView(object sender, EventArgs e)
        {
            this.listView.Visible = false;
            this.treeView.Visible = false;
        }

        

        private void showAllSongs(object sender, EventArgs e)
        {
            selectedFilter = 0;
            fillListView(this.songsContainer.songsList);
            fillTreeView(this.songsContainer.songsList);

            updateStatusBar(null,null);

            



        }

        private void showSongsAfter2000r(object sender, EventArgs e)
        {
            selectedFilter = 1;
            List<Song> list = (from item in this.songsContainer.songsList where item.recordingDate.Year >= 2000 select item).ToList();
            fillListView(list);
            fillTreeView(list);
            updateStatusBar(null, null);
        }

        private void showSongsBefore2000r(object sender, EventArgs e)
        {
            selectedFilter = 2;
            List<Song> list = (from item in this.songsContainer.songsList where item.recordingDate.Year < 2000 select item).ToList();
            fillListView(list);
            fillTreeView(list);
            updateStatusBar(null, null);
        }

        private void fillTreeView(List<Song> list)
        {
            this.treeView.Nodes.Clear();
            
            foreach (var item in list)
            {
                this.treeView.Nodes.Add(item.newTreeNode());
            }
        }

        private void fillListView(List<Song> list)
        {
            this.listView.Items.Clear();
            foreach (var item in list)
            {
                this.listView.Items.Add(item.newListViewItem());
            }
        }

        private void ListWindow_Load(object sender, EventArgs e)
        {

        }

        private void updateStatusBar(object sender, EventArgs e)
        {
            ((MdiParnet)this.MdiParent).SetStatusBarText("Liczba wyświetlanych elementów: " + this.listView.Items.Count);
        }

        public void refresh()
        {
            if (this.selectedFilter == 0) this.showAllSongs(null, null);
            else if (this.selectedFilter == 1) this.showSongsAfter2000r(null, null);
            else this.showSongsBefore2000r(null, null);
        }

        private void ListWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if(((MdiParnet)this.MdiParent).MdiChildren.Length == 1 && !e.CloseReason.Equals(CloseReason.MdiFormClosing)) //bez tego nie zamknie programu
            {
                e.Cancel = true;
            }
        }

        private void myControl1_Load(object sender, EventArgs e)
        {

        }
    }
}

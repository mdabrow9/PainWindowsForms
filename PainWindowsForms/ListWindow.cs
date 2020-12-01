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

       

        

        private void showAllSongs(object sender, EventArgs e)
        {
            selectedFilter = 0;
            fillListView(this.songsContainer.songsList);
            

            updateStatusBar(null,null);

        }

        private void showSongsAfter2000r(object sender, EventArgs e)
        {
            selectedFilter = 1;
            List<Song> list = (from item in this.songsContainer.songsList where item.recordingDate.Year >= 2000 select item).ToList();
            fillListView(list);
            
            updateStatusBar(null, null);
        }

        private void showSongsBefore2000r(object sender, EventArgs e)
        {
            selectedFilter = 2;
            List<Song> list = (from item in this.songsContainer.songsList where item.recordingDate.Year < 2000 select item).ToList();
            fillListView(list);
            
            updateStatusBar(null, null);
        }

        

        private void fillListView(List<Song> list)
        {
            this.listView.Items.Clear();
            foreach (var item in list)
            {
                this.listView.Items.Add(item.ToListViewItem());
            }
        }

        private void ListWindow_Load(object sender, EventArgs e)
        {
            songsContainer.AddSongEvent += refreshAfterAddition;
            songsContainer.EditSongEvent += refreshAfterEdit;
            songsContainer.DeleteSongEvent += refreshAfterDelete;
        }

        private void updateStatusBar(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text ="Liczba wyświetlanych elementów: " + this.listView.Items.Count;
        }

        public void refreshAfterAddition(Song newSong)
        {
            if (this.selectedFilter == 0)
            {
                //this.showAllSongs(null, null);
                this.listView.Items.Add(newSong.ToListViewItem());
                
            }
            else if (this.selectedFilter == 1)
            {
                //this.showSongsAfter2000r(null, null);
                if(newSong.recordingDate.Year >= 2000)
                {
                    this.listView.Items.Add(newSong.ToListViewItem());
                    
                }
            }
            else
            {
                //this.showSongsBefore2000r(null, null);
                if (newSong.recordingDate.Year < 2000)
                {
                    this.listView.Items.Add(newSong.ToListViewItem());
                    
                }
            }

            updateStatusBar(null, null);
        }

        public void refreshAfterEdit(Song oldSong, Song newSong)
        {
            
            if (this.selectedFilter == 0)
            {
                // this.showAllSongs(null, null);
                int index = findSongIndexInListView(oldSong);
                this.listView.Items[index] = newSong.ToListViewItem();
                
            }
            else if (this.selectedFilter == 1)
            {
                //this.showSongsAfter2000r(null, null);
                int index = findSongIndexInListView(oldSong);
                if (newSong.recordingDate.Year >= 2000)
                {
                    
                   
                    if (oldSong.recordingDate.Year >= 2000)
                    {

                        this.listView.Items[index] = newSong.ToListViewItem();

                        //this.treeView.Nodes[treeIndex] = newSong.newTreeNode();
                        
                    }
                    else
                    {
                        this.listView.Items.Add(newSong.ToListViewItem());
                    }
                    


                }
                else
                {
                    this.listView.Items.RemoveAt(index);

                }
            }
            else
            {
                //this.showSongsBefore2000r(null, null);
                int index = findSongIndexInListView(oldSong);
                if (newSong.recordingDate.Year < 2000)
                {
                    
                   
                    if (oldSong.recordingDate.Year < 2000)
                    {

                        this.listView.Items[index] = newSong.ToListViewItem();
                        //this.treeView.Nodes[treeIndex] = newSong.newTreeNode();
                       
                    }
                    else
                    {
                        this.listView.Items.Add(newSong.ToListViewItem());
                    }

                }
                else
                {
                    this.listView.Items.RemoveAt(index);

                }
            }

            updateStatusBar(null, null);
        }

        public void refreshAfterDelete(Song oldSong)
        {
            int index = findSongIndexInListView(oldSong);
            
            if (this.selectedFilter == 0)
            {
                this.listView.Items.RemoveAt(index);
               
            }
            else if (this.selectedFilter == 1) 
            { 
                if(index != -1) this.listView.Items.RemoveAt(index);
                
            }
            else 
            {
                if (index != -1) this.listView.Items.RemoveAt(index);
                
            }

            updateStatusBar(null, null);
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

        private int findSongIndexInListView(Song song)
        {
            for (int i =0;i<this.listView.Items.Count; i++)
            {
                if(this.listView.Items[i].SubItems[0].Text == song.id.ToString() )
                {
                    return i;
                }
            }
            return -1;
        }
        

        

        private void ListWindow_Deactivate(object sender, EventArgs e)
        {
            ToolStripManager.RevertMerge(((MdiParnet)this.MdiParent).toolStrip2, toolStrip1);
            ToolStripManager.RevertMerge(((MdiParnet)this.MdiParent).statusStrip1, statusStrip1);
        }

        private void ListWindow_Activated(object sender, EventArgs e)
        {
            
            ToolStripManager.Merge(toolStrip1, ((MdiParnet)this.MdiParent).toolStrip2);
            ToolStripManager.Merge(statusStrip1, ((MdiParnet)this.MdiParent).statusStrip1);
        }

        private void showAddSongWindow(object sender, EventArgs e)
        {
            NewSongWindow win = new NewSongWindow(this.songsContainer);
            win.ShowDialog();
        }

        private void showEditSongWindow(object sender, EventArgs e)
        {
            if (this.listView.SelectedItems.Count > 0)
            {

            
                Song item = (Song)this.listView.SelectedItems[0].Tag;
                NewSongWindow win = new NewSongWindow(this.songsContainer , item );
                win.ShowDialog();
            }
        }

        private void showDeleteSongWindow(object sender, EventArgs e)
        {
            

            if(this.listView.SelectedItems.Count >0 )
            {
                Song item = (Song)this.listView.SelectedItems[0].Tag;
                this.songsContainer.deleteSong(item);
            }
           
        }

        
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PainWindowsForms
{
    public class Song
    {
        public int id;
        public string[] types = { "Rock", "Pop", "Rap" };
        public string title;
        public string author;
        public DateTime recordingDate;
        public int type;

        public Song( int id, int type , string title, string author , DateTime recordingDate )
        {
            this.id = id;
            this.type = type;
            this.title = title;
            this.author = author;
            this.recordingDate = recordingDate;

        }
        public override string ToString()
        {
            return "ID: " + this.id + " gatunek: " + this.types[this.type] + " Tytuł: " + this.title + " Autor: " + this.author;
        }

        public ListViewItem newListViewItem()
        {
            string[] item = { this.id.ToString(), this.title, this.author, this.recordingDate.ToString(), this.types[this.type] };
            return new ListViewItem(item);

            //return new ListViewItem(new string[] {"lsllsl", this.id.ToString(), this.title, this.author, this.recordingDate.ToString(),this.types[this.type] });
        }
        public TreeNode newTreeNode()
        {
            TreeNode[] subNode = { new TreeNode(this.title), 
                new TreeNode(this.author), 
                new TreeNode(this.recordingDate.ToString()), 
                new TreeNode(this.types[this.type]) };

            return new TreeNode(this.id.ToString(), subNode);
        }


    }
}

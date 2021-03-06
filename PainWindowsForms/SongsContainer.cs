﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PainWindowsForms
{
    public class SongsContainer
    {
        public List<Song> songsList;
        public event Action<Song> AddSongEvent;
        public event Action<Song , Song> EditSongEvent;
        public event Action<Song> DeleteSongEvent;

        public MdiParnet mdiParent;

        public int lastId = 0;

        public SongsContainer( MdiParnet mdiParent)
        {
            this.songsList = new List<Song>();
            this.mdiParent = mdiParent;
        }
        public void AddSong(Song newSong)
        {
            this.songsList.Add(newSong);

            AddSongEvent?.Invoke(newSong);

        }
        public void editSong(Song newSong, Song oldSong)
        {
            
            //var oldSong = this.songsList[];
            this.songsList[findSongIndexInList(oldSong)] = newSong;
            EditSongEvent?.Invoke(oldSong,newSong);
        }
        public void deleteSong(Song oldSong)
        {
            
            //var oldSong = this.songsList[index];
            this.songsList.RemoveAt(findSongIndexInList(oldSong));
            DeleteSongEvent?.Invoke(oldSong);
        }
        public Song findSongByListIndex(int id)
        {
            return this.songsList[id];
        }




        public void addTestingData()
        {
            
            string[] testTitle = {"BLINDING LIGHTS" ,
                "DANCE MONKEY" ,
                "ROSES" ,
                "DON'T START NOW" ,
                "BEFORE YOU GO" ,
                "ROCKSTAR" ,
                "SOMEONE YOU LOVED" ,
                "OWN IT" ,
                "THE BOX" ,
                "SAY SO" ,
                "LONELY" ,
                "WATERMELON SUGAR" ,
                "ADORE YOU" ,
                "PHYSICAL" ,
                "HEAD & HEART" ,
                "ROVER" ,
                "SAVAGE LOVE (LAXED - SIREN BEAT)" ,
                "DEATH BED" ,
                "BREAKING ME" ,
                "RAIN ON ME" ,
                "LIFE IS GOOD" ,
                "TOOSIE SLIDE" ,
                "BRUISES" ,
                "GODZILLA" ,
                "EVERYTHING I WANTED" ,
                "ROXANNE" ,
                "BAD GUY" ,
                "INTENTIONS" ,
                "MEMORIES" ,
                "RAIN" ,
                "SAVAGE" ,
                "FLOWERS" ,
                "RIDE IT" ,
                "BLUEBERRY FAYGO" ,
                "YOU SHOULD BE SAD" ,
                "FALLING" ,
                "BREAK MY HEART" ,
                "THIS CITY" ,
                "DINNER GUEST" ,
                "BETTER OFF WITHOUT YOU"};

            string[] author = { "WEEKND" ,
                "TONES & I" ,
                "SAINT JHN" ,
                "DUA LIPA" ,
                "LEWIS CAPALDI" ,
                "DABABY FT RODDY RICCH" ,
                "LEWIS CAPALDI" ,
                "STORMZY/ED SHEERAN/BURNA BOY" ,
                "RODDY RICCH" ,
                "DOJA CAT" ,
                "JOEL CORRY" ,
                "HARRY STYLES" ,
                "HARRY STYLES" ,
                "DUA LIPA" ,
                "JOEL CORRY FT MNEK" ,
                "S1MBA FT DTG" ,
                "JAWSH 685 & JASON DERULO" ,
                "POWFU FT BEABADOOBEE" ,
                "TOPIC FT A7S" ,
                "LADY GAGA & ARIANA GRANDE" ,
                "FUTURE FT DRAKE" ,
                "DRAKE" ,
                "LEWIS CAPALDI" ,
                "EMINEM FT JUICE WRLD" ,
                "BILLIE EILISH" ,
                "ARIZONA ZERVAS" ,
                "BILLIE EILISH" ,
                "JUSTIN BIEBER FT QUAVO" ,
                "MAROON 5" ,
                "AITCH/AJ TRACEY/TAY KEITH" ,
                "MEGAN THEE STALLION" ,
                "NATHAN DAWE FT JAYKAE" ,
                "REGARD" ,
                "LIL MOSEY" ,
                "HALSEY" ,
                "HARRY STYLES" ,
                "DUA LIPA" ,
                "SAM FISCHER" ,
                "AJ TRACEY FT MOSTACK" ,
                "BECKY HILL FT SHIFT K3Y"};
            int id = 1000;

            for (int i = 0; i < 40; i++)
            {
                this.songsList.Add(new Song(id++, i%3,testTitle[i] , author[i], new DateTime(1980+i, 10, 1)));
            }
            //mdiParent.refreshAllWindows();


        }

        private int findSongIndexInList(Song song)
        {
            for (int i = 0; i < this.songsList.Count; i++)
            {
                if (this.songsList[i].id == song.id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}

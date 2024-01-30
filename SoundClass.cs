using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace FirstPlayableOop
{
    internal class SoundClass // <- Class Responsible For Sound Functions
    {
        static public void MusicPlayer(string M) // <- plays the background music
        {
            SoundPlayer BGM = new SoundPlayer();
            BGM.SoundLocation = M;
            BGM.PlayLooping();
        } 
    } 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int highscore;

    public PlayerData (scr_Highscore Highscore)
    {
        highscore = Highscore.highscore;
    }

    public float master;
    public float music;
    public float sfx;
    public float musicSlider;
    public float sfxSlider;

    public PlayerData (scr_VolumeOptions Volume)
    {
        master = Volume.master;
        music = Volume.music;
        sfx = Volume.sfx;
        musicSlider = Volume.musicSlider;
        sfxSlider = Volume.sfxSlider;
    }
}

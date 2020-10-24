using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class scr_VolumeOptions : MonoBehaviour
{

    public float master;
    public float music;
    public float sfx;
    public float musicSlider;
    public float sfxSlider;

    public Slider MasterSlider;
    public Slider MusicSlider;
    public Slider SFXSlider;
    public Text MasterValue;
    public Text MusicValue;
    public Text SFXValue;

    public Canvas canvas;

    //Save Game
    public void SaveVolume()
    {
        SaveSystem.SaveVolume(this);
    }

    //Load Game
    public void LoadVolume()
    {
        PlayerData data = SaveSystem.LoadVolume();

        master = data.master;
        music = data.music;
        sfx = data.sfx;
        MasterSlider.value = data.master;
        MusicSlider.value = data.musicSlider;
        SFXSlider.value = data.sfxSlider;

        Debug.Log(data.master);
    }

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        master = MasterSlider.value;
        musicSlider = MusicSlider.value;
        sfxSlider = SFXSlider.value;

        music = musicSlider * MasterSlider.value;
        sfx = sfxSlider * MasterSlider.value;

        MasterValue.text = "" + (Mathf.Round(master * 100.0f) * 1f);
        MusicValue.text = "" + (Mathf.Round(musicSlider * 100.0f) * 1f);
        SFXValue.text = "" + (Mathf.Round(sfxSlider * 100.0f) * 1f);

    }
}

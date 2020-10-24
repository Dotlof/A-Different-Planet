using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_TitleScreen_Cam : MonoBehaviour
{
    public AudioSource audioSource;

    public void LoadVolume()
    {
        PlayerData data = SaveSystem.LoadVolume();

        audioSource.volume = data.music;

    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        LoadVolume();
    }
}

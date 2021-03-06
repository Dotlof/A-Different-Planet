﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_AbilitysJNR : MonoBehaviour
{
    public GameObject scene;
    public Image image;
    public Sprite farbig;
    public Sprite grau;
    public GameObject Player;
    public int icon;
    float Items;
    float AnzahlItems;
    bool active = true;

    // Start is called before the first frame update
    void Start()
    {
        AnzahlItems = GameObject.FindGameObjectsWithTag("Collectible").Length;
        image = GetComponent<Image>();
        image.sprite = grau;
    }

    // Update is called once per frame
    void Update()
    {
        Items = AnzahlItems - ((AnzahlItems / 3) * icon);
        if (Player.gameObject.GetComponent<scr_JNRPlayerMovement>().Items >= Items)
        {
            image.sprite = farbig;
            if (active == true)
            {
                active = false;
                scene.gameObject.GetComponent<scr_JNRCam>().abilitys++;
            }
            
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_ItembarJNR : MonoBehaviour
{
    float AnzahlItems;
    float ItemsGes;
    public Image image;
    public Sprite[] sprites;
    int index;
    float FloatIndex;
    float Prozentsatz;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        AnzahlItems = GameObject.FindGameObjectsWithTag("Collectible").Length;
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        ItemsGes = Player.gameObject.GetComponent<scr_JNRPlayerMovement>().Items;
        if (ItemsGes < (AnzahlItems / 3) * 1)
        {
            Prozentsatz = ItemsGes / (AnzahlItems / 3);
        }
        if (ItemsGes > (AnzahlItems / 3) * 1)
        {
            Prozentsatz = (ItemsGes - (AnzahlItems / 3)) / (AnzahlItems / 3);
        }
        if (ItemsGes > (AnzahlItems / 3) * 2)
        {
            Prozentsatz = (ItemsGes - ((AnzahlItems / 3) * 2)) / (AnzahlItems / 3);
        }

        FloatIndex = 114 * Prozentsatz;
        index = Convert.ToInt32(FloatIndex);

        image.sprite = sprites[index];

        //Debug.Log(Prozentsatz);
        //Debug.Log(index);
        //Debug.Log((AnzahlItems / 3) * 1);
    }
}

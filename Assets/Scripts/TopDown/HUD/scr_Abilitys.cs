using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_Abilitys : MonoBehaviour
{
    public GameObject player;
    public Image image;
    public Sprite one;
    public Sprite two;
    public Sprite three;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameObject.GetComponent<scr_Starship>().ability == 1)
        {

                image.sprite = one;
            

        }
        if (player.gameObject.GetComponent<scr_Starship>().ability == 2)
        {

                image.sprite = two;
            
        }
        if (player.gameObject.GetComponent<scr_Starship>().ability == 3)
        {

                image.sprite = three;
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_TopDown_UI : MonoBehaviour
{

    public Canvas canvas;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        /*if (player.gameObject.GetComponent<scr_Starship>().GameEnd == true || player.gameObject.GetComponent<scr_Starship>().GameWon == true)
        {
            canvas.enabled = false;
        }*/
    }
}

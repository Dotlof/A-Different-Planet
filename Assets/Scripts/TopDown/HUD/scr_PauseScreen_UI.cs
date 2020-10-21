using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PauseScreen_UI : MonoBehaviour
{
    public Canvas canvas;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameObject.GetComponent<scr_Starship>().GamePaused == true)
        {
            canvas.enabled = true;
        }
        else
        {
            canvas.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Victory_UI : MonoBehaviour
{

    public Canvas canvas;
    public GameObject player;
    public CanvasGroup canvasGroup;
    float opacity;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        canvasGroup.alpha = opacity;
        if (player.gameObject.GetComponent<scr_Starship>().GameWon == true)
        {
            canvas.enabled = true;
        }
        if (canvas.enabled == true)
        {
            opacity += Time.deltaTime * 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_EndScore : MonoBehaviour
{

    public Text text;
    public int score = 0;
    public GameObject player;
    public GameObject CurrentScore;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");
        CurrentScore = GameObject.FindGameObjectWithTag("Score");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameObject.GetComponent<scr_Starship>().GameEnd == true)
        {
            score = CurrentScore.gameObject.GetComponent<scr_Score>().score;
        }
        text.text = "" + score;
    }
}

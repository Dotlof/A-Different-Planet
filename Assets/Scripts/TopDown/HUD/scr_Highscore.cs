using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class scr_Highscore : MonoBehaviour
{

    public int highscore = 0;
    public GameObject score;
    public GameObject player;
    public Text text;

    //Save Game
    public void SaveHighscore()
    {
        SaveSystem.SaveHighscore(this);
    }

    //Load Game
    public void LoadHighscore()
    {
        PlayerData data = SaveSystem.LoadHighscore();

        highscore = data.highscore;
    }

    // Start is called before the first frame update
    void Start()
    {
       
        text = GetComponent<Text>();
        LoadHighscore();
        


    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        score = GameObject.FindGameObjectWithTag("Score");
        if (player.gameObject.GetComponent<scr_Starship>().GameEnd == true)
        {
            if (score.gameObject.GetComponent<scr_Score>().score > highscore)
            {
                highscore = score.gameObject.GetComponent<scr_Score>().score;
                SaveHighscore();
            }
        }
        text.text = "" + highscore;
    }
}

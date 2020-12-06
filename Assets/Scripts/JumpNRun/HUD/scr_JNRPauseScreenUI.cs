using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_JNRPauseScreenUI : MonoBehaviour
{
    public Canvas canvas;
    public GameObject player;
    public GameObject Items;
    public bool pause = false;

    public void ChangeScene(string sceneName)
    {
        if (player.gameObject.GetComponent<scr_JNRPlayerMovement>().GamePaused == true || player.gameObject.GetComponent<scr_Starship>().GameEnd == true || player.gameObject.GetComponent<scr_Starship>().GameWon == true)
        {
            SceneManager.LoadScene(sceneName);
            Debug.Log("loading");
        }

    }

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
        if (player.gameObject.GetComponent<scr_JNRPlayerMovement>().GamePaused == true)
        {
            canvas.enabled = true;
            pause = true;
        }
        else
        {
            canvas.enabled = false;
            pause = false;
        }
    }
}

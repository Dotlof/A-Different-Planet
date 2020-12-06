using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_JNRDeathScreen_UI : MonoBehaviour
{
    public Canvas canvas;
    public CanvasGroup canvasGroup;
    public GameObject player;
    float opacity;

    public void ChangeScene(string sceneName)
    {
        if (player.gameObject.GetComponent<scr_JNRPlayerMovement>().GamePaused == true || player.gameObject.GetComponent<scr_JNRPlayerMovement>().GameEnd == true || player.gameObject.GetComponent<scr_JNRPlayerMovement>().GameWon == true)
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
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        canvasGroup.alpha = opacity;
        if (player.gameObject.GetComponent<scr_JNRPlayerMovement>().GameEnd == true)
        {
            canvas.enabled = true;
        }
        if (canvas.enabled == true)
        {
            opacity += Time.deltaTime * 1;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_TitleScreen_UI : MonoBehaviour
{

    public Canvas canvas;
    public Canvas Startup;
    public CanvasGroup canvasGroup;
    public bool started = true;
    bool animEnd = false;
    float alpha = 0;

    IEnumerator anims()
    {
        yield return new WaitForSeconds(3f);
        animEnd = true;
    }

    IEnumerator starting()
    {
        canvas.enabled = false;
        Startup.enabled = true;
        yield return new WaitForSeconds(3f);
        Startup.enabled = false;
        canvas.enabled = true;
        started = false;
        scr_GameInstance.control.started = false;
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(anims());
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponent<Canvas>();
        if (scr_GameInstance.control.started == true)
        {
            canvasGroup.alpha = 0;
            StartCoroutine(starting());
        }
        else
        {
            canvas.enabled = true;
            Debug.Log("sas");
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (canvasGroup.alpha <= 1 && animEnd == true)
        {
            canvasGroup.alpha += Time.deltaTime;
        }
    }
}

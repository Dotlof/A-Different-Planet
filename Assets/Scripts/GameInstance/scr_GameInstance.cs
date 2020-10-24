using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_GameInstance : MonoBehaviour
{
    public static scr_GameInstance control;

    public bool started = true;


    void Awake()
    {
        control = this;
        DontDestroyOnLoad(transform.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Titlescreen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

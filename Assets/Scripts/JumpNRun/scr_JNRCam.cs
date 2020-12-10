using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_JNRCam : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public GameObject collider1;
    public GameObject player;
    public AudioSource audioSource;
    float xDir;
    float yDir = 260;
    float speed = 750;
    bool freeCam = false;
    float size = 650;
    public int abilitys = 0;
    

    public void LoadVolume()
    {
        PlayerData data = SaveSystem.LoadVolume();

        audioSource.volume = data.music;

    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        LoadVolume();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        scr_GameInstance.control.Ability = abilitys;
        //Debug.Log(scr_GameInstance.control.Ability);
        if (transform.position.x == 54080)
        {
            freeCam = true;
        }
        if (freeCam == false)
        {
            xDir = player.gameObject.transform.position.x;
            if (player.gameObject.GetComponent<scr_JNRPlayerMovement>().hight <= 600)
            {
                if (yDir >= 260)
                {
                    yDir -= Time.deltaTime * speed;
                }
                //Debug.Log("height 1");
            }
            else if (player.gameObject.GetComponent<scr_JNRPlayerMovement>().hight > 600 && player.gameObject.GetComponent<scr_JNRPlayerMovement>().hight < 1100)
            {
                if (yDir < 600)
                {
                    yDir += Time.deltaTime * speed;
                }
                if (yDir > 600)
                {
                    yDir -= Time.deltaTime * speed;
                }
                //Debug.Log("height 2");
            }
            else if (player.gameObject.GetComponent<scr_JNRPlayerMovement>().hight > 1100 && player.gameObject.GetComponent<scr_JNRPlayerMovement>().hight < 2048)
            {
                if (yDir < 1100)
                {
                    yDir += Time.deltaTime * speed;
                }
                if (yDir > 1100)
                {
                    yDir -= Time.deltaTime * speed;
                }
                //Debug.Log("height 3");
            }
            else if (player.gameObject.GetComponent<scr_JNRPlayerMovement>().hight >= 2048)
            {
                if (yDir <= 2048)
                {
                    yDir += Time.deltaTime * speed;
                }
                //Debug.Log("height 3");
            }
            transform.position = new Vector3(xDir, yDir, -10);
        }
        else
        {
            transform.position = new Vector3(54080,player.transform.position.y,-10);
            if (size < 1000)
            {
                size += Time.deltaTime * 80;
            }
            Camera.main.orthographicSize = size;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_JNRCam : MonoBehaviour
{
    public GameObject collider1;
    public GameObject player;
    float xDir;
    float yDir = 260;
    float speed = 750;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
        else if (player.gameObject.GetComponent<scr_JNRPlayerMovement>().hight >= 1100)
        {
            if (yDir <= 1100)
            {
                yDir += Time.deltaTime * speed;
            }
            //Debug.Log("height 3");
        }
        transform.position = new Vector3(xDir, yDir, -10);
    }
}

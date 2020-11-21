using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_zahnrad : MonoBehaviour
{
    float YDir;
    float XDir;
    float Yanim = 0;
    bool drehen = true;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        YDir = transform.position.y;
        XDir = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

        if (Yanim >= 0.25)
        {
            drehen = true;
        }
        else if (Yanim <= -0.25)
        {
            drehen = false;
        }

        if (drehen == true)
        {
            Yanim -= Time.deltaTime * 0.5f;
        }
        else if (drehen == false)
        {
            Yanim += Time.deltaTime * 0.5f;
        }
        YDir = YDir + Yanim;
        transform.position = new Vector3(XDir, YDir, 0);

        //Debug.Log(Yanim);
    }
}

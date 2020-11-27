using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ItemPlatform : MonoBehaviour
{
    public GameObject Player;
    SpriteRenderer spriteRenderer;
    public Sprite Blue;
    public Sprite Red;
    bool blue = false;
    bool backwards = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Player.gameObject.GetComponent<scr_JNRPlayerMovement>().Items >= 25)
            {
                blue = true;
                spriteRenderer.sprite = Blue;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Red;
    }

    // Update is called once per frame
    void Update()
    {
        if (blue == true)
        {
            if (transform.position.y < 2048 && backwards == false)
            {
                transform.position += new Vector3(0, 1, 0) * Time.deltaTime * 500;
            }
            else if (transform.position.x < 704 && backwards == false)
            {
                transform.position += new Vector3(1, 0, 0) * Time.deltaTime * 500;
            }
            else if (transform.position.y < 2432 && backwards == false)
            {
                transform.position += new Vector3(0, 1, 0) * Time.deltaTime * 500;
            }
            else
            {
                backwards = true;
            }
            if (transform.position.y > 2048 && backwards == true)
            {
                transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * 500;
            }
            else if (transform.position.x > -1088 && backwards == true)
            {
                transform.position -= new Vector3(1, 0, 0) * Time.deltaTime * 500;
            }
            else if (transform.position.y > 0 && backwards == true)
            {
                transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * 500;
            }
            else
            {
                backwards = false;
            }


        }

        //Debug.Log(transform.position);
    }
}

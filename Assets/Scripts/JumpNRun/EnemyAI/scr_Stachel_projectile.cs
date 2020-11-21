using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Stachel_projectile : MonoBehaviour
{
    float speed = 500;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator kill()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(kill());
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation == Quaternion.Euler(0, 0, 0))
        {
            transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
        }
        if (transform.rotation == Quaternion.Euler(0, 0, -45))
        {
            transform.position += new Vector3(1, 1, 0) * speed * Time.deltaTime;
        }
        if (transform.rotation == Quaternion.Euler(0, 0, 45))
        {
            transform.position += new Vector3(-1, 1, 0) * speed * Time.deltaTime;
        }
    }
}

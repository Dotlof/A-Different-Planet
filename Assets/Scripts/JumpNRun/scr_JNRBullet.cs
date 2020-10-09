using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_JNRBullet : MonoBehaviour
{

    public float Direction;
    float speed = 100;
    Vector3 moveRight = new Vector3(1, 0, 0);
    Vector3 moveLeft = new Vector3(-1, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Kill());
    }

    // Update is called once per frame
    void Update()
    {
        if (Direction == 1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.position += moveRight * speed * Time.deltaTime;
        }
        if (Direction == 2)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.position += moveLeft * speed * Time.deltaTime;
        }

    }

        IEnumerator Kill()
        {
            yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
        }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag != "Player")
        {
            Destroy(gameObject);
        }
    }

}


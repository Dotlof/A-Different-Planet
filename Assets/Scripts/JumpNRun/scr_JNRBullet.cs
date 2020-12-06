using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_JNRBullet : MonoBehaviour
{

    public float Direction;
    float speed = 3000f;
    Vector3 moveRight = new Vector3(1, 0, 0);
    Vector3 moveLeft = new Vector3(-1, 0, 0);
    Vector3 moveUp = new Vector3(0, 1, 0);
    Vector3 moveDown = new Vector3(0, -1, 0);
    Vector3 moveUpLeft = new Vector3(-1, 1, 0);
    Vector3 moveDownLeft = new Vector3(-1, -1, 0);
    Vector3 moveUpRight = new Vector3(1, 1, 0);
    Vector3 moveDownRight = new Vector3(1, -1, 0);


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
            transform.localScale = new Vector3(1, 1, 1);
            transform.position += moveRight * speed * Time.deltaTime;
        }
        if (Direction == 2)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.rotation = Quaternion.Euler(0, 0, -45);
            transform.position += moveDownRight * speed * Time.deltaTime;
        }
        if (Direction == 3)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.rotation = Quaternion.Euler(0, 0, 90);
            transform.position += moveDown * speed * Time.deltaTime;
        }
        if (Direction == 4)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.rotation = Quaternion.Euler(0, 0, 45);
            transform.position += moveDownLeft * speed * Time.deltaTime;
        }
        if (Direction == 5)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.position += moveLeft * speed * Time.deltaTime;
        }
        if (Direction == 6)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.rotation = Quaternion.Euler(0, 0, -45);
            transform.position += moveUpLeft * speed * Time.deltaTime;
        }
        if (Direction == 7)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.rotation = Quaternion.Euler(0, 0, 90);
            transform.position += moveUp * speed * Time.deltaTime;
        }
        if (Direction == 8)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.rotation = Quaternion.Euler(0, 0, 45);
            transform.position += moveUpRight * speed * Time.deltaTime;
        }
        //Debug.Log(transform.position);

    }

        IEnumerator Kill()
        {
            yield return new WaitForSeconds(0.5f);
            Destroy(gameObject);
        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Collectible")
        {
            Destroy(gameObject);
            Debug.Log(collision);
        }
    }
}


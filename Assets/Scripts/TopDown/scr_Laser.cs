using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class scr_Laser : MonoBehaviour
{

    public float Direction;
    float speed = 100;
    Vector3 moveRight = new Vector3(1, 0, 0);
    Vector3 moveLeft = new Vector3(-1, 0, 0);
    Vector3 moveTop = new Vector3(0, 1, 0);
    Vector3 moveBottom = new Vector3(0, -1, 0);

    IEnumerator kill()
    {
        yield return new WaitForSeconds(1f);
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
        if (Direction == 3)
        {
            transform.localRotation = Quaternion.Euler(0, 0, -90);
            transform.position += moveTop * speed * Time.deltaTime;
        }
        if (Direction == 4)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 90);
            transform.position += moveBottom * speed * Time.deltaTime;
        }


    }
}

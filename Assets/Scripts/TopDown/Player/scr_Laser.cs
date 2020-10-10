﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class scr_Laser : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    public float Direction;
    float speed = 800;
    Vector3 moveRight = new Vector3(1, 0, 0);
    Vector3 moveLeft = new Vector3(-1, 0, 0);
    Vector3 moveTop = new Vector3(0, 1, 0);
    Vector3 moveBottom = new Vector3(0, -1, 0);

    IEnumerator kill()
    {
        yield return new WaitForSeconds(0.5f);
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
        if (Direction == 5)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 135);
            transform.position += moveTop + moveLeft * speed * Time.deltaTime;
        }
        if (Direction == 6)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 45);
            transform.position += moveBottom + moveLeft * speed * Time.deltaTime;
        }
        if (Direction == 7)
        {
            transform.localRotation = Quaternion.Euler(0, 0, -135);
            transform.position += moveTop + moveRight * speed * Time.deltaTime;
        }
        if (Direction == 8)
        {
            transform.localRotation = Quaternion.Euler(0, 0, -45);
            transform.position += moveBottom + moveRight * speed * Time.deltaTime;
        }


    }
}
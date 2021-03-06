﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class scr_Strahl : MonoBehaviour
{
    public float Dir;
    float speed = 2000;
    Vector3 moveRight = new Vector3(1, 0, 0);
    Vector3 moveLeft = new Vector3(-1, 0, 0);
    Vector3 moveTop = new Vector3(0, 1, 0);
    Vector3 moveBottom = new Vector3(0, -1, 0);
    Vector3 moveTopRight = new Vector3(1, 1, 0);
    Vector3 moveTopLeft = new Vector3(-1, 1, 0);
    Vector3 moveBottomRight = new Vector3(1, -1, 0);
    Vector3 moveBottomLeft = new Vector3(-1, -1, 0);

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
        if (Dir == 1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.position += moveRight * speed * Time.deltaTime;
        }
        if (Dir == 2)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.position += moveLeft * speed * Time.deltaTime;
        }
        if (Dir == 3)
        {
            transform.localRotation = Quaternion.Euler(0, 0, -90);
            transform.position += moveTop * speed * Time.deltaTime;
        }
        if (Dir == 4)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 90);
            transform.position += moveBottom * speed * Time.deltaTime;
        }
        if (Dir == 5)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 135);
            transform.position += moveTopLeft * speed * Time.deltaTime;
        }
        if (Dir == 6)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 45);
            transform.position += moveBottomLeft * speed * Time.deltaTime;
        }
        if (Dir == 7)
        {
            transform.localRotation = Quaternion.Euler(0, 0, -135);
            transform.position += moveTopRight * speed * Time.deltaTime;
        }
        if (Dir == 8)
        {
            transform.localRotation = Quaternion.Euler(0, 0, -45);
            transform.position += moveBottomRight * speed * Time.deltaTime;
        }

    }
}

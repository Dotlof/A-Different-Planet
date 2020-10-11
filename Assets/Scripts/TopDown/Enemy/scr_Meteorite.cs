﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Meteorite : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            RandomDirX = RandomDirX / -1;
            RandomDirY = RandomDirY / -1;
        }
        if (collision.gameObject.tag == "Laser")
        {
            health--;
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    private void RandomFarbe()
    {
        switch (RandomColor)
        {
            case 1:
                spriteRenderer.sprite = Meteor1;
                break;
            case 2:
                spriteRenderer.sprite = Meteor2;
                break;
            case 3:
                spriteRenderer.sprite = Meteor3;
                break;
            case 4:
                spriteRenderer.sprite = Meteor4;
                break;
            case 5:
                spriteRenderer.sprite = Meteor5;
                break;
        }


    }

    private void crack()
    {
        if (health == 2 && RandomColor == 1)
        {
            spriteRenderer.sprite = Meteor1_1;
        }
        else if (health == 1 && RandomColor == 1)
        {
            spriteRenderer.sprite = Meteor1_2;
        }

        if (health == 2 && RandomColor == 2)
        {
            spriteRenderer.sprite = Meteor2_1;
        }
        else if (health == 1 && RandomColor == 2)
        {
            spriteRenderer.sprite = Meteor2_2;
        }
    }

    IEnumerator spawn()
    {
        kill = true;
        yield return new WaitForSeconds(3f);
        kill = false;

    }

    public SpriteRenderer spriteRenderer;
    public Sprite Meteor1;
    public Sprite Meteor1_1;
    public Sprite Meteor1_2;
    public Sprite Meteor2;
    public Sprite Meteor2_1;
    public Sprite Meteor2_2;
    public Sprite Meteor3;
    public Sprite Meteor4;
    public Sprite Meteor5;
    int RandomColor;
    int health = 3;
    float RandomDirX;
    float RandomDirY;
    float Speed;
    float RotZ;
    public float dist;
    bool kill = false;
    Vector3 movement;
    public GameObject Starship;

    // Start is called before the first frame update
    void Start()
    {
        dist = Vector3.Distance(Starship.transform.position, transform.position);
        RandomDirX = Random.Range(-1f, 1f);
        RandomDirY = Random.Range(-1f, 1f);
        RandomColor = Random.Range(1, 6);
        Speed = Random.Range(100f, 600f);
        RandomFarbe();
        StartCoroutine(spawn());

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = RandomDirX;
        transform.position += new Vector3(movement.x, 0, 0) * Time.deltaTime * Speed;

        movement.y = RandomDirY;
        transform.position += new Vector3(0, movement.y, 0) * Time.deltaTime * Speed;

        RotZ += Time.deltaTime * Speed;
        transform.rotation = Quaternion.Euler(0, 0, RotZ);

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (dist <= 1000 && kill == true)
        {
            Destroy(gameObject);
            Debug.Log("kill");
        }
        crack();

    }
}

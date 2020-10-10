using System.Collections;
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
    }

    float RandomDirX;
    float RandomDirY;
    float Speed;
    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        RandomDirX = Random.Range(-1f, 1f);
        RandomDirY = Random.Range(-1f, 1f);
        Speed = Random.Range(100f, 1000f);

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = RandomDirX;
        transform.position += new Vector3(movement.x, 0, 0) * Time.deltaTime * Speed;

        movement.y = RandomDirY;
        transform.position += new Vector3(0, movement.y, 0) * Time.deltaTime * Speed;
    }
}

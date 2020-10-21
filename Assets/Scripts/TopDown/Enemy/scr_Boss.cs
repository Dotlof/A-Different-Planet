using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Boss : MonoBehaviour
{
    IEnumerator zerstoren()
    {
        yield return new WaitForSeconds(0.5f);
        geschutze = GameObject.FindGameObjectsWithTag("mini_boss").Length;
        if (dead == false)
        {
            StartCoroutine(zerstoren());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator moving()
    {
        pos = 1;
        yield return new WaitForSeconds(10f);
        shoot = 1;
        yield return new WaitForSeconds(Time.deltaTime);
        shoot = 2;
        yield return new WaitForSeconds(15f);
        shoot = 0;

        pos = 2;
        yield return new WaitForSeconds(10f);
        shoot = 1;
        yield return new WaitForSeconds(Time.deltaTime);
        shoot = 2;
        yield return new WaitForSeconds(15f);
        shoot = 0;

        pos = 3;
        yield return new WaitForSeconds(10f);
        shoot = 1;
        yield return new WaitForSeconds(Time.deltaTime);
        shoot = 2;
        yield return new WaitForSeconds(15f);
        shoot = 0;

        pos = 4;
        yield return new WaitForSeconds(10f);
        shoot = 1;
        yield return new WaitForSeconds(Time.deltaTime);
        shoot = 2;
        yield return new WaitForSeconds(15f);
        shoot = 0;

        StartCoroutine(moving());
    }

    public int shoot = 0;
    float rotSpeed = 25f;
    float speed = 800f;
    float RotZ;
    float step;
    int pos;
    int geschutze;
    bool dead = false;
    Vector3 rechts = new Vector3(5000, 0, 0);
    Vector3 links = new Vector3(-5000, 0, 0);
    Vector3 oben = new Vector3(0, 5000, 0);
    Vector3 unten = new Vector3(0, -5000, 0);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(moving());
    }

    // Update is called once per frame
    void Update()
    {
        step = Time.deltaTime * speed;
        RotZ += Time.deltaTime * rotSpeed;
        transform.rotation = Quaternion.Euler(0, 0, RotZ);

        if (pos == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, oben, step);
        }
        if (pos == 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, links, step);
        }
        if (pos == 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, unten, step);
        }
        if (pos == 4)
        {
            transform.position = Vector2.MoveTowards(transform.position, rechts, step);
        }

        if (geschutze == 0)
        {
            dead = true;
        }
    }
}

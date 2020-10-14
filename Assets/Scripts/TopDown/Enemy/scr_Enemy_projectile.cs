using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Enemy_projectile : MonoBehaviour
{

    public GameObject Enemy;
    float Speed = 1000;
    Vector3 Pos;
    private Transform target;

    IEnumerator zerstoren()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Pos = target.position;
        StartCoroutine(zerstoren());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Pos, Speed * Time.deltaTime);
        if (transform.position == Pos)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class scr_Boss_projectile : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(6f);
        Destroy(gameObject);
    }

    float speed = 1000;
    public Vector3 richtung;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(death());
    }


    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, richtung, step);
    }
}

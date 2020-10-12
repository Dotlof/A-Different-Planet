using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_JNRFire : MonoBehaviour
{

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<scr_JNRPlayerMovement>().HP--;
        }
    }

}

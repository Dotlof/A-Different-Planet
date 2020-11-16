using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_JNRSpawner : MonoBehaviour
{
    bool cd = false;
    public bool Upsidedown;
    public GameObject Fire;

    IEnumerator Cooldown()
    {
        if (cd == false)
        {
            yield return new WaitForSeconds(5f);
            if(Upsidedown == true)
            {
                Instantiate(Fire, new Vector3(transform.position.x ,transform.position.y -98,0), transform.rotation = Quaternion.Euler(0,0,180) );
            }
            else Instantiate(Fire, new Vector3(transform.position.x, transform.position.y + 98, 0), Quaternion.identity);
            cd = true;
            StartCoroutine(Cooldown());
        }
        else { yield return new WaitForSeconds(3f); cd = false; StartCoroutine(Cooldown()); }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Cooldown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

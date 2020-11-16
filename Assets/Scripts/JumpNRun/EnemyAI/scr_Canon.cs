using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Canon : MonoBehaviour
{
    public GameObject rocket;
    Vector3 RocketStart;

    IEnumerator Shoot()
    {
        Instantiate(rocket, RocketStart, transform.rotation);
        yield return new WaitForSeconds(2f);
        StartCoroutine(Shoot());
    }

    // Start is called before the first frame update
    void Start()
    {
        RocketStart = transform.position + new Vector3(0, 40, 0);
        StartCoroutine(Shoot());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

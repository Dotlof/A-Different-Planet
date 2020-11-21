using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Canon : MonoBehaviour
{
    public GameObject rocket;
    Vector3 RocketStart;
    public float range = 200;
    float relativeRange;

    IEnumerator Shoot()
    {
        rocket.GetComponent<scr_JNR_rocket>().range = relativeRange;
        Instantiate(rocket, RocketStart, transform.rotation);
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(Shoot());
    }

    // Start is called before the first frame update
    void Start()
    {
        relativeRange = transform.position.x - range;
        RocketStart = transform.position + new Vector3(0, 40, 0);
        StartCoroutine(Shoot());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

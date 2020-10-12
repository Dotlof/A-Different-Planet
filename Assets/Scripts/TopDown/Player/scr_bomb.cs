using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_bomb : MonoBehaviour
{
    IEnumerator explosion()
    {
        yield return new WaitForSeconds(3f);
        detonation = true;
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }

    public bool detonation;

    // Start is called before the first frame update
    void Start()
    {
        detonation = false;
        StartCoroutine(explosion());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(detonation);
    
    }
}

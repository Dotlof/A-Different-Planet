using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_bomb : MonoBehaviour
{
    IEnumerator explosion()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }

    public bool detonation;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0.1f, 0.1f, 1);
        detonation = false;
        StartCoroutine(explosion());
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += Time.deltaTime * new Vector3(6f,6f,0f);
        //Debug.Log(detonation);
    
    }
}

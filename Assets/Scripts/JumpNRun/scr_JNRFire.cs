using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_JNRFire : MonoBehaviour
{
    Animator animator;

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(4f);
        animator.SetBool("End", true);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fire());
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

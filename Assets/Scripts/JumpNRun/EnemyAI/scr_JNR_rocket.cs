using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_JNR_rocket : MonoBehaviour
{
    float Speed = 1000f;
    Animator animator;

    // Start is called before the first frame update

    IEnumerator death()
    {
        yield return new WaitForSeconds(2f);
        Speed = 0f;
        animator.SetBool("Death", true);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);

    }

    void Start()
    {
        StartCoroutine(death());
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(1,0,0) * Time.deltaTime * Speed;
        transform.rotation = Quaternion.Euler(0, 0, 180);
    }
}

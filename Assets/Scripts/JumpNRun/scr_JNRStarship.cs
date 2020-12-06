using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_JNRStarship : MonoBehaviour
{
    public Animator animator;
    bool start = false;
    float speed = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Launch());
        }
    }

    IEnumerator Launch()
    {
        animator.SetBool("launch", true);
        yield return new WaitForSeconds(1f);

        start = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (start == true)
        {
            if (speed <= 5000)
            {
                speed += Time.deltaTime * speed;
            }

            transform.position += new Vector3(0, 1, 0) * Time.deltaTime * speed;
        }
    }
}

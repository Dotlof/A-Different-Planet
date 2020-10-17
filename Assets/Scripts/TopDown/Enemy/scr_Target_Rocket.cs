using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Target_Rocket : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            StartCoroutine(Trigger());
        }
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Trigger());
        }
    }

    IEnumerator Trigger()
    {
        moveSpeed = 0f;
        animator.SetBool("Death", true);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(5f);
        moveSpeed = 0f;
        animator.SetBool("Death", true);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    public Transform Player;
    private Rigidbody2D rb;
    private Vector2 movement;
    float moveSpeed = 500f;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(death());
        animator = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
}

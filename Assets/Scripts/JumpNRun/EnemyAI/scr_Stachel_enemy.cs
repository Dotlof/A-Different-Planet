using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Stachel_enemy : MonoBehaviour
{
    Animator animator;
    public GameObject projectile;
    public float MoveSpeed = 400;
    public float P1;
    public float P2;
    string Direction = "Right";
    int HP = 10;
    bool stop = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && stop == false)
        {
            StartCoroutine(dmg());
        }
    }

    IEnumerator dmg()
    {
        HP--;
        animator.SetBool("Dmg", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Dmg", false);
    }

    IEnumerator shoot()
    {
        yield return new WaitForSeconds(3f);
        animator.SetBool("Shoot", true);
        stop = true;
        yield return new WaitForSeconds(1.6f);
        Instantiate(projectile, transform.position + new Vector3(0, 51, 0), transform.rotation);
        Instantiate(projectile, transform.position + new Vector3(44, 35, 0), Quaternion.Euler(0, 0, -45));
        Instantiate(projectile, transform.position + new Vector3(-44, 35, 0), Quaternion.Euler(0, 0, 45));
        yield return new WaitForSeconds(1.4f);
        animator.SetBool("Shoot", false);
        stop = false;
        StartCoroutine(shoot());
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(shoot());
    }

    // Update is called once per frame
    void Update()
    {
        if (Direction == "Right" && stop == false)
        {
            transform.position += new Vector3(MoveSpeed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Direction == "Left" && stop == false)
        {
            transform.position -= new Vector3(MoveSpeed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (transform.position.x >= P2)
        {
            Direction = "Left";
        }

        if (transform.position.x <= P1)
        {
            Direction = "Right";
        }

        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Geschutz : MonoBehaviour
{
    IEnumerator shoot()
    {
        Instantiate(projectile, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(projectile, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(projectile, transform.position, transform.rotation);
        yield return new WaitForSeconds(3f);
        StartCoroutine(shoot());
    }

    public GameObject projectile;
    public Transform Player;
    private Rigidbody2D rb;
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(shoot());
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

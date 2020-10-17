using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Rocket_Launcher : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            //Debug.Log("HIT");
            health--;
            StartCoroutine(dmg());
        }
    }

    IEnumerator dmg()
    {
        spriteRenderer.sprite = damage;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.sprite = normal;
    }
    IEnumerator shoot()
    {
        Instantiate(projectile, transform.position, transform.rotation);
        yield return new WaitForSeconds(10f);
        StartCoroutine(shoot());
    }

    float health = 15f;
    public SpriteRenderer spriteRenderer;
    public Sprite damage;
    public Sprite normal;
    public GameObject projectile;
    public GameObject player;
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

        if (health <= 0)
        {
            player.gameObject.GetComponent<scr_big_enemy>().destroyed--;
            Destroy(gameObject);
        }
    }
}

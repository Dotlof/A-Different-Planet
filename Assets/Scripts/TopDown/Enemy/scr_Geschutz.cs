using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Geschutz : MonoBehaviour
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
        yield return new WaitForSeconds(0.25f);
        Instantiate(projectile, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.25f);
        Instantiate(projectile, transform.position, transform.rotation);
        yield return new WaitForSeconds(3f);
        StartCoroutine(shoot());
    }

    public SpriteRenderer spriteRenderer;
    public Sprite damage;
    public Sprite normal;
    public GameObject projectile;
    public GameObject player;
    public GameObject Score;
    public Transform Player;
    private Rigidbody2D rb;
    private Vector2 movement;
    float health = 10;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(shoot());
        rb = this.GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Score = GameObject.FindGameObjectWithTag("Score");
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
            Score.gameObject.GetComponent<scr_Score>().score = Score.gameObject.GetComponent<scr_Score>().score + 100;
            Destroy(gameObject);
        }
    }
}

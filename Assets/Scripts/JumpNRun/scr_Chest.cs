using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Chest : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite normal;
    public Sprite dmg;
    public Sprite opened;
    int health = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            StartCoroutine(damage());
        }
    }

    IEnumerator damage()
    {
        health--;
        spriteRenderer.sprite = dmg;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.sprite = normal;
    }
    IEnumerator open()
    {
        yield return new WaitForSeconds(1f);
        spriteRenderer.sprite = opened;
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = normal;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            StartCoroutine(open());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_1UP : MonoBehaviour
{
    IEnumerator spriteChange()
    {
        for (int i = 0; i < 23; i++)
        {
            spriteRenderer.sprite = normal;
            yield return new WaitForSeconds(1f);
            spriteRenderer.sprite = white;
            yield return new WaitForSeconds(0.1f);
        }
        for (int i = 0; i < 8; i++)
        {
            spriteRenderer.sprite = normal;
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.sprite = white;
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);

    }

    public SpriteRenderer spriteRenderer;
    public Sprite normal;
    public Sprite white;
    public bool Timer = true;

    // Start is called before the first frame update
    void Start()
    {
        if (Timer == true)
        {
            StartCoroutine(spriteChange());
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

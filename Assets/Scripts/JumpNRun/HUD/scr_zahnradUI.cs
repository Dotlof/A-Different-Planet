using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_zahnradUI : MonoBehaviour
{
    int index;
    public Image image;
    public Sprite[] sprites;


    IEnumerator anim()
    {
        yield return new WaitForSeconds(0.08f);
        if (sprites.Length > index + 1)
        {
            index++;
        }
        else
        {
            index = 0;
        }
        StartCoroutine(anim());
    }

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(anim());
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = sprites[index];
    }
}

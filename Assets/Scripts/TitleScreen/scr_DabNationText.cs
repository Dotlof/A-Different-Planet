using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_DabNationText : MonoBehaviour
{
    public Text text;
    int anims = 0;
    float alpha;

    IEnumerator colorChange()
    {
        yield return new WaitForSeconds(2f);
        anims = 1;
        


    }

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.color = new Color(255,255,255,0);
        StartCoroutine(colorChange());
    }

    // Update is called once per frame
    void Update()
    {
        text.color = new Color(255, 255, 255, alpha);
        switch (anims)
        {
            case 0:
                if (alpha <= 1)
                {
                    alpha += Time.deltaTime * 1;
                }
                break;
            case 1:
                if (alpha >= 0)
                {
                    alpha += Time.deltaTime * -1;
                }
                break;
        }

        //Debug.Log(alpha);

    }
}

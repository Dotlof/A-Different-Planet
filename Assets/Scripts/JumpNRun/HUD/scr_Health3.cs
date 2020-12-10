using UnityEngine;
using UnityEngine.UI;

public class scr_Health3 : MonoBehaviour
{

    public GameObject player;
    public Image spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<Image>();
        spriteRenderer.enabled = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameObject.GetComponent<scr_JNRPlayerMovement>().HP < 3)
        {
            spriteRenderer.enabled = false;
        }
        else
        {
            spriteRenderer.enabled = true;
        }
    }
}

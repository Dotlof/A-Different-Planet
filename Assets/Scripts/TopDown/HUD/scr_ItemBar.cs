using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_ItemBar : MonoBehaviour
{
	IEnumerator Timer()
    {
		yield return new WaitForSeconds(0.0521648408972353f);
		if (index < sprites.Length)
        {
			image.sprite = sprites[index];
			index++;
		}
		StartCoroutine(Timer());
	}

	public GameObject player;
	bool doOnce = true;

	public Sprite[] sprites;
	public float spritePerFrame = 3.5f;
	public bool loop = true;
	public bool destroyOnEnd = false;

	private int index = 0;
	private Image image;
	private int frame = 0;

	void Awake()
	{
		StartCoroutine(Timer());
		image = GetComponent<Image>();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		
		if (index >= sprites.Length)
        {
			index = 114;
			doOnce = true;
        }
			if (player.gameObject.GetComponent<scr_Starship>().AbilityCooldown < 0.5 && doOnce == true)
		{
			doOnce = false;
			if (loop) index = 0;
			if (destroyOnEnd) Destroy(gameObject);
		}
		//Debug.Log(player.gameObject.GetComponent<scr_Starship>().AbilityCooldown);
		Debug.Log(index);
	}
}

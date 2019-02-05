using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
	public int life = 50;
	[SerializeField] private Sprite halfLifeSprite;

	// Update is called once per frame
	void Update()
	{
		if(life == 25)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = halfLifeSprite;
		}
		if (life == 0)
		{
			Destroy(gameObject);
		}
	}
}

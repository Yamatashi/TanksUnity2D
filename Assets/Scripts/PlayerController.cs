using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MovingController
{


	// Update is called once per frame
	void Update()
	{
		int horizontal = 0;
		int vertical = 0;

		horizontal = (int) Input.GetAxisRaw("Horizontal");
		vertical = (int) Input.GetAxisRaw("Vertical");
		
		if (horizontal != 0)
		{
			vertical = 0;
		}

		if (horizontal != 0 || vertical != 0)
		{
			RaycastHit2D hit;
			MoveObject(horizontal, vertical, out hit);
		}

		if (Input.GetKeyDown("space"))
		{
			TowerController tower = GetComponentInChildren<TowerController>();
			tower.FireEvent("Player");
		}

		if (life == 0)
		{
			Destroy(this.gameObject);
			SceneManager.LoadScene("Lose");
		}
	}

	
}

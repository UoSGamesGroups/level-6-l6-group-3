using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prologuePickUpWeapon : MonoBehaviour {

	[SerializeField] private GameObject textPickUpWeapon;
	[SerializeField] private GameObject playerHand;


	private GameObject player;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if (Vector3.Distance(transform.position, player.transform.position) < 4f)
		{
			textPickUpWeapon.gameObject.SetActive(true);
			if (Input.GetKeyDown(KeyCode.E))
			{
				playerHand.gameObject.SetActive(true);
				this.gameObject.SetActive(false);
			}
		}
		else
		{
			textPickUpWeapon.gameObject.SetActive(false);
		}
		
		if (playerHand.gameObject.activeInHierarchy)
			this.enabled=false;
	}


}

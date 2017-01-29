using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemymeleeAttack : MonoBehaviour {
	
	
	
	GameObject player;
	playerSts _playerSts;
	
	//attack
	[SerializeField] float dmg;
	float currentAttackTime;
	float endAttackTime=1.4f;
	
	
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		_playerSts = GameObject.FindGameObjectWithTag("Player").GetComponent<playerSts>();
	}
	
	void Update()
	{
		Attack();
	}
	
	void Attack()
	{
		if(Vector3.Distance(transform.position, player.transform.position)<3)
		{
			currentAttackTime += Time.deltaTime;
			
			if(currentAttackTime == endAttackTime/2)
			{
				print("now attack animation");
			}
			
			if(currentAttackTime >=endAttackTime)
			{
				_playerSts.current_player_hp -= dmg;
				currentAttackTime =0f;
			}
		}
		else
		{
			currentAttackTime =0f;
		}
	}
	
}
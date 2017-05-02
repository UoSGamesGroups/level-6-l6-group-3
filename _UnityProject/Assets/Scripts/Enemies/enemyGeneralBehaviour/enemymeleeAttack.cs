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
		if(Vector3.Distance(transform.position, player.transform.position)<4)
		{
			currentAttackTime += Time.deltaTime;
			
			if(currentAttackTime == endAttackTime/2)
			{
				print("now attack animation");
			}
			
			if(currentAttackTime >=endAttackTime)
			{
				_playerSts.current_player_hp -= dmg;
				var a = GameObject.FindGameObjectWithTag("dmgFrame");
				a.GetComponent<Image>().color = new Color(a.GetComponent<Image>().color.r, a.GetComponent<Image>().color.g, a.GetComponent<Image>().color.b, 0.8f);
				Debug.Log(a);
				currentAttackTime =0f;
			}
		}
		else
		{
			currentAttackTime =0f;
		}
	}
	
}
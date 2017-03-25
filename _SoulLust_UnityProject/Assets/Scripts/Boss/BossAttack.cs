using System.Collections;
using UnityEngine;

public class BossAttack : MonoBehaviour {

	[SerializeField] GameObject[] bossAttacks;
	GameObject player;

	int attackingChance;

	void Awake()
	{
		player= GameObject.FindGameObjectWithTag("Player");
	}

	IEnumerator Start()
	{
		while(true)
		{
			yield return new WaitForSeconds(3f);
			attackingChance = Random.Range(0, 10);

			if(attackingChance < 10)
			{
				Instantiate(bossAttacks[0], bossAttacks[0].transform.position = new Vector3(player.transform.position.x + Random.Range(-5f,5f),50,player.transform.position.z + Random.Range(-5f,5f)) ,transform.rotation );
			}

		}
	}




}

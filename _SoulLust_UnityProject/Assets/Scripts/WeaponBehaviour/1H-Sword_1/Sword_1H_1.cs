using UnityEngine;
using System.Collections;

public class Sword_1H_1 : MonoBehaviour {


	[SerializeField] private int sword_1h_level = 0;


	private GameObject[] enemies;
	[SerializeField] Animator anim;
	private Animator _camera;
	
	[Header("Primary Sts")]
	[SerializeField] private float sword_1h_dmg;
	[SerializeField] private float max_cooldown;

	[Header("Level1 - cc")]
	[SerializeField] private float crit_chance;

	[Header("Level2 - cd")]
	[SerializeField] private float crit_damage;
	

	BonusController bonus;
	private float current_cooldown= 0;
	
	private bool onCooldown = false;


	void Awake()
	{
        bonus = GameObject.FindGameObjectWithTag("Player").GetComponent<BonusController>();
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
		//_col = GetComponent<MeshCollider>();
	}

	IEnumerator Start()
	{
		while (true)
		{
			enemies = GameObject.FindGameObjectsWithTag("enemy");
			yield return new WaitForSeconds(1f);
		}
	}
	

	void Update()
	{
		Attack_1();
	}



	void Attack_1()
	{
		if (!onCooldown)
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				anim.SetTrigger("attack");
				onCooldown = true;
			}
		}
		
		if (onCooldown)
		{
			current_cooldown += Time.deltaTime;

			if (current_cooldown > max_cooldown)
			{
				onCooldown = false;
				current_cooldown = 0;
			}
		}
	}


	void OnTriggerEnter(Collider col)
	{
		foreach (GameObject enemy in enemies)
		{
			if (col.gameObject == enemy)
			{
                _camera.SetTrigger("shake");

                switch (sword_1h_level)
				{
					case 0:
						enemy.GetComponent<enemySts>().enemy_hp -= sword_1h_dmg + bonus.BonusDmg;
						break;
					case 1:
						enemy.GetComponent<enemySts>().enemy_hp -= Level_1_CritChance();
						break;
					case 2:
						enemy.GetComponent<enemySts>().enemy_hp -= Level_2_DmgWithCritDamage();
						break;
					case 3:
						enemy.GetComponent<enemySts>().enemy_hp -= Level_2_DmgWithCritDamage();
						enemy.GetComponent<debuffsOnEnemy>().bleedDuration = 5f;



						break;
				}
			}
		}
	}

	

	float Level_1_CritChance()
	{
		float dmgWithCrit = 0;
		float  cc_value = 0;
		cc_value = Random.Range(1f, 100f);

		if (cc_value <= crit_chance)
		{
			dmgWithCrit = (sword_1h_dmg+ bonus.BonusDmg) * 2.0f;
			print("isCrit");
		}
		else if (cc_value > crit_chance)
		{
			dmgWithCrit = sword_1h_dmg+ bonus.BonusDmg;
		}
		return dmgWithCrit;
	}

	float Level_2_DmgWithCritDamage()
	{
		float dmgWithCrit = 0;
		float cc_value = 0;
		cc_value = Random.Range(1f, 100f);

		if (cc_value <= crit_chance)
		{
			dmgWithCrit =(sword_1h_dmg+ bonus.BonusDmg) * crit_damage;
			print("isCrit + Cd");
		}
		else if (cc_value > crit_chance)
		{
			dmgWithCrit = sword_1h_dmg+ bonus.BonusDmg;
		}
		return dmgWithCrit;
	}
}

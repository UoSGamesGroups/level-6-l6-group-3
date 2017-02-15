using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour {

	
	int bonusId;

	//id1
	float bonusHp; 
	public float BonusHp{
		get{return bonusHp;}
		set{bonusHp = value;}
	}

	//id2
	float bonusMs;
	public float BonusMs{
		get{return bonusMs;}
		set{bonusMs = value;}
	}

	//id3
	float bonusDmg;
	public float BonusDmg{
		get{return bonusDmg;}
		set{bonusDmg = value;}
	}

	//id4
	float bonusLwrHealthDrop;
	public float BonusLwrHealthDrop{
		get{return bonusLwrHealthDrop;}
		set{bonusLwrHealthDrop = value;}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "bonus")
		{
			bonusId = col.gameObject.GetComponent<BonusId>().Id;
			Destroy(col.gameObject);
		}
	}

	void Update()
	{
		switch(bonusId)
		{
			case 1:
				bonusHp = 5f;
				break;
			case 2:
				bonusMs = 0.3f;
				break;
			case 3:
				bonusDmg = 1f;
				break;
			case 4:
				bonusLwrHealthDrop = 0.03f;
				break;
		}
		bonusId = 0;

	}



}

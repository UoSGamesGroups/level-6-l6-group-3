using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour {

	
	int bonusId;

	[SerializeField] GameObject text;
	GameObject obj;
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
				obj = Instantiate(text, text.transform.position = transform.position + new Vector3(0,3,0), text.transform.rotation );
				obj.GetComponent<TextMesh>().text = "Health Increased";
				break;
			case 2:
				bonusMs = 0.3f;
				obj = Instantiate(text, text.transform.position = transform.position + new Vector3(0,3,0), text.transform.rotation );
				obj.GetComponent<TextMesh>().text = "Movement speed\nIncreased";
				break;
			case 3:
				bonusDmg = 1f;
				obj = Instantiate(text, text.transform.position = transform.position + new Vector3(0,3,0), text.transform.rotation );
				obj.GetComponent<TextMesh>().text = "Damage Increased";
				break;
			case 4:
				bonusLwrHealthDrop = 0.03f;
				obj = Instantiate(text, text.transform.position = transform.position + new Vector3(0,3,0), text.transform.rotation );
				obj.GetComponent<TextMesh>().text = "Health drops\nslower";
				break;
		}
		bonusId = 0;

	}



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wepManagementPanelBehaviour : MonoBehaviour {

	[SerializeField] GameObject[] weapons;
	[SerializeField] GameObject[] panels;
	
	int id;
	public int Id
	{
		get{return id;}
		set{id = value;}
	}

	void Update()
	{
		WeaponChosen();
	}

	void WeaponChosen()
	{
		if(id!=0)
		{
			foreach(GameObject w in weapons)
				w.gameObject.SetActive(false);
			foreach(GameObject p in panels)
				p.gameObject.SetActive(false);
		}
		switch(id)
		{
			case 1:
				weapons[id-1].gameObject.SetActive(true);
				panels[id-1].gameObject.SetActive(true);

				id=0;
				break;
			case 2:
				weapons[id-1].gameObject.SetActive(true);
				panels[id-1].gameObject.SetActive(true);
				id=0;
				break;
			case 3:
				weapons[id-1].gameObject.SetActive(true);
				panels[id-1].gameObject.SetActive(true);
				id=0;
				break;
			case 4:
				weapons[id-1].gameObject.SetActive(true);
				panels[id-1].gameObject.SetActive(true);
				id=0;
				break;
			case 5:
				weapons[id-1].gameObject.SetActive(true);
				panels[id-1].gameObject.SetActive(true);
				id=0;
				break;

		}
	}

}

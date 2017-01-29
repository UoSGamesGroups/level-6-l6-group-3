using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wepSelect : MonoBehaviour {

	[SerializeField] int id;
	[SerializeField]wepManagementPanelBehaviour _wepManagementPanelBehaviour;

	public void ClickOnWeapon()
	{
		_wepManagementPanelBehaviour.Id = id;
		print("wmerge");
	}

}

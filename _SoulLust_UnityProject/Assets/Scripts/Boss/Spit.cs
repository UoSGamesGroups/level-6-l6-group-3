using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit : MonoBehaviour {

	/// <summary>
	/// OnTriggerStay is called once per frame for every Collider other
	/// that is touching the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerStay(Collider other)
	{
			if(other.gameObject.tag == "Player")
			{
				other.gameObject.GetComponent<playerSts>().current_player_hp -= Time.deltaTime * 50f;
			}
	}
}

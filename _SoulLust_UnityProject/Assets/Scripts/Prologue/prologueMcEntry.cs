using System.Collections;
using UnityEngine;

public class prologueMcEntry : MonoBehaviour {

	MonoBehaviour[] mono;


	void Awake()
	{
		mono = GetComponents<MonoBehaviour>();
	}

	IEnumerator Start()
	{
		yield return new WaitForSeconds(5);

		foreach(MonoBehaviour a in mono)
		{
			if(a.enabled == false)
				a.enabled = true;
		}
		enabled = false;
	}

	void FixedUpdate()
	{
		transform.position += Time.deltaTime * 2 * Vector3.forward;
	}
}

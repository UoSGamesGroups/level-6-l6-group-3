using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarGlow : MonoBehaviour {


	[SerializeField] SpriteRenderer sprite;
	Color32 col= new Color32(110,0,0,255);
	IEnumerator Start()
	{
		while(true)
		{
			yield return new WaitForSeconds(1f);
			col = new Color32(110,0,0,255);
			yield return new WaitForSeconds(1f);
			col = new Color32(220,0,0,255);
		}
	}

	void Update()
	{
		sprite.color = Color.Lerp(sprite.color, col, Time.deltaTime * 2);
	}
}

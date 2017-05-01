using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextOnMcTrigger : MonoBehaviour {

	[SerializeField] string text;
	Text canvasText;
	int isFadingState = 0; //1- fade in, 2-fade out
	float alpha;


	void Awake()
	{
		canvasText = GameObject.FindGameObjectWithTag("canvasText").GetComponent<Text>();
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
			StartCoroutine(ActivateText());
	}

	IEnumerator ActivateText()
	{
		isFadingState = 1; 
		canvasText.text = text;
		yield return new WaitForSeconds(5);
		isFadingState = 2;
		yield return new WaitForSeconds(2);
		enabled = false;
	}

	void Update()
	{
		alpha = Mathf.Clamp(alpha, 0f,1f);
		canvasText.color = new Color(canvasText.color.r, canvasText.color.g, canvasText.color.b, alpha );
		if(isFadingState ==1)
		{
			alpha +=  Time.deltaTime * 0.6f;
		}
		else if(isFadingState ==2)
		{
			alpha -=  Time.deltaTime * 0.6f;
		}
	}



}

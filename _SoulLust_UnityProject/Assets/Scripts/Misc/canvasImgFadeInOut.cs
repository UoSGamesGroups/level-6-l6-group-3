using UnityEngine;
using UnityEngine.UI;

public class canvasImgFadeInOut : MonoBehaviour {

	[SerializeField] bool isFadeIn;
	[SerializeField] float fadeSpeed;
	Image img;

	void Awake()
	{
		img = GetComponent<Image>();
	}

	void Update()
	{
		if(!isFadeIn && img.color.a >0)
			img.color -= new Color(0,0,0,fadeSpeed) * Time.deltaTime;
		else if(isFadeIn && img.color.a <1)
			img.color += new Color(0,0,0,fadeSpeed) * Time.deltaTime;
		

	}



}

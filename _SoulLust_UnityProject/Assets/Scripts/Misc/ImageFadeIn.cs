using UnityEngine;
using UnityEngine.UI;

public class ImageFadeIn : MonoBehaviour {

	[SerializeField] Image img;
	[SerializeField] float fadeSpeed;


	void Update()
	{
		img.color += new Color(0,0,0,Time.deltaTime * fadeSpeed);
	}

}

using UnityEngine;
using UnityEngine.UI;
public class DamageFrameBehaviour : MonoBehaviour {

	void Update()
	{
		if(GetComponent<Image>().color.a>0)
			GetComponent<Image>().color -= new Color(0f,0f,0f,1f) * Time.deltaTime * 0.7f;
	}
}

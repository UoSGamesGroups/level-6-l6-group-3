using UnityEngine;

public class FloatingText : MonoBehaviour {

	[SerializeField] float speed;
	
	void Update()
	{
		transform.position += Vector3.up * Time.deltaTime * speed;

		GetComponent<TextMesh>().color -= Time.deltaTime * 0.7f* new Color(0,0,0,1);
		if(GetComponent<TextMesh>().color.a <=0)
			Destroy(gameObject);
	}




}

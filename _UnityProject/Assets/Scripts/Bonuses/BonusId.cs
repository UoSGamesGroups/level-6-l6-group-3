using UnityEngine;

public class BonusId : MonoBehaviour {

	[SerializeField] int id;
	public int Id{
		get{return id;}
		set{id = value;}
	}


	void Update()
	{
		transform.Rotate(Vector3.up, Time.deltaTime * 50f);
	}


}

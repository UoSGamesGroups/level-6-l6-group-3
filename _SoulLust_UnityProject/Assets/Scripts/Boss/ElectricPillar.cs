using UnityEngine;

public class ElectricPillar : MonoBehaviour {


	playerSts _playerHp;
	bool isFalling = true;
	[SerializeField] float speed;

	void Awake()
	{
		_playerHp = GameObject.FindGameObjectWithTag("Player").GetComponent<playerSts>();
	}

	void Update()
	{
		if(isFalling )
			transform.position += Vector3.up * Time.deltaTime * speed;

			if(Vector3.Distance(transform.position, _playerHp.transform.position)<4)
			{
				_playerHp.current_player_hp -= Time.deltaTime * 120f;
			}

	}

	
	void OnCollisionEnter(Collision other)
	{
			if(other.gameObject.tag == "floor")
			{
				Debug.Log("sadsdas");
				isFalling = false;
			}
	}


}

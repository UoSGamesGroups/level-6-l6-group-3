using UnityEngine;
using System.Collections;

public class bleed_effect : MonoBehaviour {

	[SerializeField] private float bleed_time = 5f;
	[SerializeField] private float bleed_dmg = 2f;


    private float start_bleed_time;

	private enemySts enemy_hp;


	void Awake()
	{
		enemy_hp = GetComponent<enemySts>();
	}

    void Start()
    {
        start_bleed_time = bleed_time;
    }



	void Update()
	{
		if (bleed_time > 0)
		{
			enemy_hp.enemy_hp -= Time.deltaTime * bleed_dmg;
            bleed_time -= Time.deltaTime;

        }
		else
		{
			this.enabled = false;
		}

	}

    public void Reset(bool activate)
    {
        if (activate)
        {
            bleed_time = start_bleed_time;
            activate = false;
        }
    }

}

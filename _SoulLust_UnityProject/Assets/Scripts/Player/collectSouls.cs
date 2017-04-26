using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectSouls : MonoBehaviour {

	public static float soulsCurrency;
	[SerializeField] Text soulsCurrencyText;
	[SerializeField] ParticleSystem healPart;
    GameObject[] souls;
    playerSts _playerSts;
	


    private void Awake()
    {
        _playerSts = GetComponent<playerSts>();
    }

    private IEnumerator Start()
    {
        while (true)
        {
            souls = GameObject.FindGameObjectsWithTag("soul");
            yield return new WaitForSeconds(1f);
        }
    }


    void Update()
    {
		soulsCurrencyText.text = "Souls: \n" + soulsCurrency.ToString("N0");
		
        foreach (GameObject s in souls)
        {
            if (Vector3.Distance(transform.position, s.transform.position) < 2)
            {
                healPart.Play();
                _playerSts.current_player_hp += 3f;
                s.transform.position = new Vector3(99f, 99f, 99f);
                s.gameObject.SetActive(false);
				soulsCurrency += 1;
            }
        }
    }


}

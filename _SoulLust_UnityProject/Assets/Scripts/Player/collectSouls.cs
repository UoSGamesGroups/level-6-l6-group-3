using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectSouls : MonoBehaviour {


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
        foreach (GameObject s in souls)
        {
            if (Vector3.Distance(transform.position, s.transform.position) < 2)
            {
                _playerSts.current_player_hp += 5f;
                s.transform.position = new Vector3(99f, 99f, 99f);
                s.gameObject.SetActive(false);
            }
        }
    }


}

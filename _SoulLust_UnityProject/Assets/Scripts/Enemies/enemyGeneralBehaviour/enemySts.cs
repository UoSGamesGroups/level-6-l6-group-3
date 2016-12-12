using UnityEngine;
using System.Collections;

public class enemySts : MonoBehaviour {


    [SerializeField] private GameObject deadBody;

    public float enemy_hp;


    void Update()
    {
        Death();
    }




    void Death()
    {
        if (enemy_hp <= 0)
        {
            deadBody.transform.parent = null;
            deadBody.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }

    }
}

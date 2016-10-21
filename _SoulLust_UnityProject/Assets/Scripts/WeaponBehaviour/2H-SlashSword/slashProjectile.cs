using UnityEngine;
using System.Collections;

public class slashProjectile : MonoBehaviour {

	
    [SerializeField] private float ms;
    [SerializeField] private float dmg;

    private GameObject[] enemies;



    void Awake()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
    }




    void Update()
    {
        ms -= Time.deltaTime * 20;
        transform.position += transform.forward * ms * Time.deltaTime;

        if (ms < 3)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        foreach (GameObject enemy in enemies)
        {
            if (col.gameObject == enemy)
            {
                enemy.GetComponent<enemySts>().enemy_hp -= dmg;
                print("sad");
            }
        }
    }


}

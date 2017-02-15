using UnityEngine;
using System.Collections;

public class hammer_2H : MonoBehaviour {



    private GameObject[] enemies;
    private GameObject spikePos;



    [SerializeField] private int hammer_level;


    
    [Header("Primary stats")]
    [SerializeField] private float dmg;
    [SerializeField] private float max_cooldown = 2f;


    [Header("Level_1")]
    [SerializeField] private float improved_dmg;

    [Header("Level_3")]
    [SerializeField] GameObject spikes;
    bool activateSpikes = false;
    float timeTillSpikes = 0.8f;


    private Animator anim;
    private bool onCooldown;
    private GameObject player;

    private float current_cooldown = 0;
    BonusController bonus;
    

    void Awake()
    {
        anim = GetComponent<Animator>();
        bonus = GameObject.FindGameObjectWithTag("Player").GetComponent<BonusController>(); 
        spikePos = GameObject.FindGameObjectWithTag("spikePos");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    IEnumerator Start()
    {
        while (true)
        {
            enemies = GameObject.FindGameObjectsWithTag("enemy");
            yield return new WaitForSeconds(1f);
        }
    }


    void Update()
    {
        Attack_1();

        Level_1();
        Level_3_spikes();

    }


    void OnTriggerEnter(Collider col)
    {
        foreach (GameObject enemy in enemies)
        {
            if (col.gameObject == enemy)
            {
                enemy.GetComponent<enemySts>().enemy_hp -= dmg +bonus.BonusDmg;


                //level 2 - root
                if (hammer_level >= 2)
                {
                    enemy.GetComponent<debuffsOnEnemy>().isRooted = true;
                }



            }
        }
    }


    void Attack_1()
    {
        if (!onCooldown)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                anim.SetTrigger("attack_1");
                onCooldown = true;
                player.GetComponent<playerMovement>().enabled = false;
                if (hammer_level >= 3)
                {
                    activateSpikes = true;
                }
            }
        }

        if (onCooldown)
        {
            current_cooldown += Time.deltaTime;

            if (current_cooldown > max_cooldown)
            {
                onCooldown = false;
                player.GetComponent<playerMovement>().enabled = true;
                current_cooldown = 0;
            }
        }
    }



    //level 1
    void Level_1()
    {
        if (hammer_level >= 1)
        {
            dmg = improved_dmg+bonus.BonusDmg;
            max_cooldown = 1.2f;
            anim.speed = 1.5f;
        }
    }


    void Level_3_spikes()
    {
        if (hammer_level >= 3 && activateSpikes)
        {
            timeTillSpikes -= Time.deltaTime;
            if (timeTillSpikes <= 0)
            {
                Instantiate(spikes, spikePos.transform.position, player.transform.rotation);
                timeTillSpikes = 0.8f;
                activateSpikes = false;
            }
        }

    }

   




}

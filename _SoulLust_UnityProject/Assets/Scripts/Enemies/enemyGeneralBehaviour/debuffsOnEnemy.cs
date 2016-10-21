using UnityEngine;
using System.Collections;

public class debuffsOnEnemy : MonoBehaviour {

    private enemyMovement enemyMovementScript;
    private enemySts enemyStsSctipt;
    private Rigidbody rigid;

    

    [Header("Slow Debuff")]
    public float slowDuration;
    [SerializeField] private float slowPotency;
    private float saved_ms;


    [Header("Bleed Debuff")]
    public float bleedDuration;
    [SerializeField] private float bleedDmg;


    [Header("Stun")]
    public bool isRooted = false;
    [SerializeField] float maxRootDuration = 1f;
    float rootDuration = 0f;


    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        enemyMovementScript = GetComponent<enemyMovement>();
        enemyStsSctipt = GetComponent<enemySts>();
    }

    void Start()
    {
        //slow
        saved_ms = enemyMovementScript.enemy_ms;
    }
    

    void Update()
    {
        Slow();
        Bleed();
        Root();
    }

    
    public void Slow()
    {
        if (slowDuration > 0)
        {
            slowDuration -= Time.deltaTime;
            enemyMovementScript.enemy_ms = saved_ms * (1.0f-slowPotency);
        }
        else if (slowDuration <= 0)
        {
            enemyMovementScript.enemy_ms = saved_ms;
        }
    }
    

    public void Bleed()
    {
        if (bleedDuration > 0)
        {
            bleedDuration -= Time.deltaTime;
            enemyStsSctipt.enemy_hp -= Time.deltaTime * bleedDmg;
        }
    }


    void Root()
    {
        

        if (isRooted)
        {
            rootDuration += Time.deltaTime;
            GetComponent<enemyMovement>().enabled = false;

            if (rootDuration >= maxRootDuration)
            {
                GetComponent<enemyMovement>().enabled = true;
                isRooted = false;
                rootDuration = 0f;
            }
        }
    }
    
}

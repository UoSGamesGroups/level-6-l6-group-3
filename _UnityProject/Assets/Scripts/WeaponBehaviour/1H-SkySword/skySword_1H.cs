using UnityEngine;
using System.Collections;

public class skySword_1H : MonoBehaviour
{

    [SerializeField] GameObject weapon_attack;
    public int skySword_level;
    private Vector3 attack_pos;
    private bool onCooldown;
    

    private GameObject[] enemies;

    private RaycastHit raycast;
    private float dist = 1000f;
    private int layer_mask;
    private float rs = 2000f;


    [Header("Primary stats")]
    [SerializeField] float primary_cd;
    [SerializeField] float max_cd = 1;

    [Header("Level 1")]
    [SerializeField] private float improved_cd = 0.5f;
    private float current_cd = 0f;
    




    void Awake()
    {
        layer_mask = LayerMask.GetMask("floor");
    }

    IEnumerator Start()
    {
        while (true)
        {
            enemies = GameObject.FindGameObjectsWithTag("enemy");
            yield return new WaitForSeconds(0.1f);
        }
    }


    void Update()
    {
        Attack_1();

    }


    void Attack_1()
    {
        Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(mousePos, out raycast, dist, layer_mask))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && !onCooldown)
            {
                Instantiate(weapon_attack, raycast.point += transform.forward * 3f, weapon_attack.transform.rotation);
                onCooldown = true;
            }
        }


        if (onCooldown)
        {
            current_cd += Time.deltaTime;
            if (current_cd >= max_cd)
            {
                onCooldown = false;
                current_cd = 0f;
            }
        }
    }


    void Level_1()
    {
        if (skySword_level >= 1)
        {
            max_cd = improved_cd;
        }
    }


}

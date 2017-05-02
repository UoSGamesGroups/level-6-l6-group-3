using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class enemySts : MonoBehaviour {


    [SerializeField] bool isBoss;
    [SerializeField] private GameObject deadBody;
    [SerializeField]GameObject fillHpBar;
    [SerializeField] ParticleSystem blood;
    [SerializeField] GameObject bloodSplatter;
    [SerializeField] GameObject mesh;
    GameObject isHidden;
    float maxHp;
    public float enemy_hp;

    void Awake()
    {
        if(isBoss)
        {
            if(fillHpBar==null)
            {
                fillHpBar = GameObject.FindGameObjectWithTag("bossFillBar");
                isHidden = GameObject.FindGameObjectWithTag("hidden");
            }
            
        }
    }

    void Start()
    {
        maxHp = enemy_hp;
    }

    void Update()
    {
        Death();

        if(fillHpBar!=null)
        {
            fillHpBar.transform.localScale = new Vector3(enemy_hp/maxHp, 1,1);
//            isHidden.transform.localPosition = new Vector3(0, 0, 0);
        }

        // if(isBoss)
        //     mesh.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,0), Time.deltaTime); 
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        float temp = 0.0f;
        GameObject go;

        if(other.gameObject.tag == "weapon")
        {
            // mesh.transform.rotation = Quaternion.Euler(90,90,90);
            blood.Play();
            temp = Random.Range(0.2f, 0.5f);
            go = Instantiate(bloodSplatter, new Vector3(transform.position.x, 0.1f, transform.position.z), Quaternion.Euler(90,0, Random.Range(0,360f)));
            go.transform.localScale = new Vector3(temp, temp, temp);
            Destroy(go.gameObject,2f);
        }
    }

    void Death()
    {
        if (enemy_hp <= 0)
        {
            isBoss = false;
            if(isHidden != null)
              isHidden.gameObject.SetActive(false);
            deadBody.transform.parent = null;
            deadBody.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    


    }
}

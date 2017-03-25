using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class enemySts : MonoBehaviour {


    [SerializeField] bool isBoss;
    [SerializeField] private GameObject deadBody;
    GameObject fillHpBar;
    GameObject isHidden;
    float maxHp;
    public float enemy_hp;

    void Awake()
    {
        if(isBoss)
        {
            fillHpBar = GameObject.FindGameObjectWithTag("bossFillBar");
            isHidden = GameObject.FindGameObjectWithTag("hidden");
        }
    }

    void Start()
    {
        maxHp = enemy_hp;
    }

    void Update()
    {
        Death();

        if(isBoss)
        {
            fillHpBar.transform.localScale = new Vector3(enemy_hp/maxHp, 1,1);
            isHidden.transform.localPosition = new Vector3(0, 0, 0);
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

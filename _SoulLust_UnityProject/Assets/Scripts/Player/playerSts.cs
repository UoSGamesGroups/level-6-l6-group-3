using UnityEngine;
using System.Collections;

public class playerSts : MonoBehaviour {


    public float current_player_hp = 1000;

    [SerializeField] float hunger;
    private float max_player_hp;

    //GUI
    private GameObject mcHpBar;
    private TextMesh mcHpText;


    private void Awake()
    {
        mcHpBar = GameObject.FindGameObjectWithTag("mcHp");
        mcHpText= GameObject.FindGameObjectWithTag("mcHpText").GetComponent<TextMesh>();
    }

    void Start()
    {
        max_player_hp = current_player_hp;
    }

    void Update()
    {
        HpDecreas();
        GUI();
    }

    void HpDecreas()
    {
        current_player_hp -= Time.deltaTime * hunger;
        current_player_hp = Mathf.Clamp(current_player_hp, 0, max_player_hp);
    }

    void GUI()
    {
        mcHpBar.transform.localScale = new Vector3(current_player_hp / max_player_hp, 1f, 1f);
        mcHpText.text = current_player_hp.ToString("N1") +"/"+max_player_hp.ToString("N1");
    }



}

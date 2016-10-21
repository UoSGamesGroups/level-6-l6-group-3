using UnityEngine;
using System.Collections;

public class playerSts : MonoBehaviour {


    public float current_player_hp = 1000;

    private float max_player_hp;



    void Start()
    {
        max_player_hp = current_player_hp;
    }

    void Update()
    {
        current_player_hp = Mathf.Clamp(current_player_hp, 0, max_player_hp);
    }



}

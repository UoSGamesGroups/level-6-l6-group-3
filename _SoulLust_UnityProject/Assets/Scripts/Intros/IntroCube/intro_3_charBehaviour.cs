using UnityEngine;
using System.Collections;

public class intro_3_charBehaviour : MonoBehaviour {



    [SerializeField] private float timeUntilHeadMove;
    [SerializeField] private float timeUntilWalking;


    private Animator anim;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    IEnumerator Start()
    {

        yield return new WaitForSeconds(timeUntilHeadMove);

        anim.SetTrigger("rise_head");

        yield return new WaitForSeconds(timeUntilWalking);

        anim.SetTrigger("char_move");

    }






}

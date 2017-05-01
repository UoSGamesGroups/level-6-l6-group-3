using UnityEngine;
using System.Collections;

public class characterMovement : MonoBehaviour {

    private Animator anim;
    private int state = 0;

    [SerializeField] private float ms;


    [Header("Time")]
    [SerializeField] private float state_1_duration;




    void Awake()
    {
        anim = GetComponent<Animator>();
    }



    IEnumerator Start()
    {
        state = 1;

        yield return new WaitForSeconds(state_1_duration);

        state = 2;
        
    }


    void Update()
    {
        if (state == 1)
        {
            anim.SetBool("move", true);
            transform.position += transform.forward * Time.deltaTime * ms;
        }
        else
        {
            anim.SetBool("move", false);
        }

    }



}

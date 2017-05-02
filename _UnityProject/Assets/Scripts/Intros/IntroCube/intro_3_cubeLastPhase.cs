using UnityEngine;
using System.Collections;

public class intro_3_cubeLastPhase : MonoBehaviour {

    [SerializeField] private MonoBehaviour cubeScripts;

    [SerializeField] private ParticleSystem particles;
    [SerializeField] private float timeUntilLastPhase;


    private Animator anim;
    private MonoBehaviour i ;

    void Awake()
    {
        i = GetComponent<introCube_behaviour2>();
        anim = GetComponent<Animator>();
    }


    IEnumerator Start()
    {
        yield return new WaitForSeconds(timeUntilLastPhase);
        anim.enabled = true;
        
        anim.SetBool("levitate", true);
        particles.Play();


    }




    

}

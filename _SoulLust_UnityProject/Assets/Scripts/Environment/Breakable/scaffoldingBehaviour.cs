using UnityEngine;

public class scaffoldingBehaviour : MonoBehaviour {

    Rigidbody[] rigid;
    bool isBroken = false;
    Animator _anim;
    
    void Awake()
    {
        rigid = GetComponentsInChildren<Rigidbody>();
        _anim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "weapon")
        {
            _anim.SetTrigger("shake");
            foreach (Rigidbody r in rigid)
            {
                r.isKinematic = false;
            }

            GetComponent<BoxCollider>().enabled = false;
        }
    }
}

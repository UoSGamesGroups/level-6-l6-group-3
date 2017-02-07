using UnityEngine;
using System.Collections;

public class cameraFollowsPlayer : MonoBehaviour {

    [SerializeField]
    private float y;
    [SerializeField]
    private float z;

    GameObject player;
    Vector3 target;



    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            target = new Vector3(player.transform.position.x, player.transform.position.y + y, player.transform.position.z + z);
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * 3f);
        }
    }
}

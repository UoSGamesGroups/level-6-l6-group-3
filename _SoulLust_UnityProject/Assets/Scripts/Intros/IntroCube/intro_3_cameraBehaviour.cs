using UnityEngine;
using System.Collections;

public class intro_3_cameraBehaviour : MonoBehaviour {


    [Header("Camera")]
    [SerializeField] private float untilCameraMoves;


    IEnumerator Start()
    {
        yield return new WaitForSeconds(untilCameraMoves);

        transform.position = new Vector3(-1.22f, 4.69f, -1.87f);
        transform.rotation = Quaternion.Euler(16f, -202f, -2f);

    }


}

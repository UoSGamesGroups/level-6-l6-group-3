using UnityEngine;
using System.Collections;

public class cameraRotate : MonoBehaviour {

    [SerializeField]
    private float rs;

    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rs);
    }


}

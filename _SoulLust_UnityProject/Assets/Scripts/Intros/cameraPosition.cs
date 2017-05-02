using UnityEngine;
using System.Collections;

public class cameraPosition : MonoBehaviour {


    [Header("First")]
    [SerializeField] private float firstTransitionTime;
    [SerializeField] private Vector3 firstPosition;
    [SerializeField] private Quaternion firstRotation;

    [Header("Second")]
    [SerializeField] private float secondTransitionTime;
    [SerializeField] private Vector3 secondPosition;
    [SerializeField] private Quaternion secondRotation;

    [Header("Third")]
    [SerializeField] private float thirdTransitionTime;
    [SerializeField] private Vector3 thirdPosition;
    [SerializeField] private Quaternion thirdRotation;

    [Header("Forth")]
    [SerializeField] private float forthTransitionTime;
    [SerializeField] private Vector3 forthPosition;
    [SerializeField] private Quaternion forthRotation;

    [Header("Fifth")]
    [SerializeField] private float fifthTransitionTime;
    [SerializeField] private Vector3 fifthPosition;
    [SerializeField] private Quaternion fifthRotation;

    [Header("Sixth")]
    [SerializeField] private float sixthTransitionTime;
    [SerializeField] private Vector3 sixthPosition;
    [SerializeField] private Quaternion sixthRotation;

    [Header("Sixth")]
    [SerializeField] private Vector3 seventhPosition;
    [SerializeField] private Quaternion seventhRotation;



    IEnumerator Start()
    {
        transform.position = firstPosition;
        transform.rotation =  Quaternion.Euler(30f, 0, 0);


        yield return new WaitForSeconds(firstTransitionTime);


        transform.position = secondPosition;
        transform.rotation = Quaternion.Euler(20.2f, 270.1f, 0f);
        

        yield return new WaitForSeconds(secondTransitionTime - firstTransitionTime);


        transform.position = thirdPosition;
        transform.rotation =  Quaternion.Euler(0f, 0f, 0f);


        yield return new WaitForSeconds(thirdTransitionTime - secondTransitionTime);


        transform.position = forthPosition;
        transform.rotation = Quaternion.Euler(0f, 270f, 0f);


        yield return new WaitForSeconds(forthTransitionTime - thirdTransitionTime);


        transform.position = fifthPosition;
        transform.rotation = Quaternion.Euler(28f, 270f, 0f);


        yield return new WaitForSeconds(fifthTransitionTime - forthTransitionTime);


        transform.position = sixthPosition;
        transform.rotation = Quaternion.Euler(22.8f, 293f, 0f);

        yield return new WaitForSeconds(sixthTransitionTime - fifthTransitionTime);


        transform.position = seventhPosition;
        transform.rotation =  Quaternion.Euler(0f, 0f, 0f);
    }
}

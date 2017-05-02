using UnityEngine;
using System.Collections;

public class introCube_behaviour2 : MonoBehaviour {

    [Header("Time")]
    [SerializeField] private float timeUntilStart;
    [SerializeField] private float timeUntilShake;
    [SerializeField] private float timeUntilEnd;


    [Header("Position")]
    [SerializeField] private float riseSpeed;
    [SerializeField] private float maximumHight;

    [Header("Emission - maximumEmission between 0 and 1")]
    [SerializeField] private float emissionSpeed;
    [SerializeField] private float maximumEmission;


    [Header("Shake")]
    [SerializeField] private float shakeProgressSpeed;
    private float shakeCoeficient = 0f;


    private bool startBehaving;
    private Renderer rend;
    private Color color;
    private bool isStarted = false;


    void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(timeUntilStart);
        startBehaving = true;

        yield return new WaitForSeconds(timeUntilShake);
        StartCoroutine(Shake());

        yield return new WaitForSeconds(timeUntilEnd);
        startBehaving = false;
        //this.enabled = false;
    }


    void Update()
    {
        if (startBehaving)
        {

            isStarted = true;

            if (transform.localPosition.y < maximumHight)
            {
                transform.localPosition += Vector3.up * riseSpeed / 1000 * Time.deltaTime;
            }



            
            if (color.a < maximumEmission)
            {
                color += new Color(1, 1, 1, 1) * Time.deltaTime * emissionSpeed / 1000;
                rend.material.SetColor("_EmissionColor", color);
            }

            //if (transform.localPosition.y >= maximumHight)
            //{
            //    float time = 0f;
            //    float x = Random.Range(maximumEmission - 0.1f, maximumEmission);

            //    time += Time.deltaTime;

            //    if (time > 0.3f)
            //    {
            //        color = new Color(x, x, x, x);
            //        rend.material.SetColor("_EmissionColor", color);
            //        time = 0f;
            //    }
            //}
        }
        else if(!startBehaving && isStarted)
        {
            Vector3 target = new Vector3(0f, 0f, 0f);
            transform.localPosition =Vector3.Lerp(transform.localPosition, target, Time.deltaTime*10);


            rend.material.SetColor("_EmissionColor",Color.black);
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

            if (transform.localPosition.y  <= target.y + 0.001f)
            {
                enabled = false;
            }
        }
    }


    IEnumerator Shake()
    {
        while (startBehaving)
        {
            shakeCoeficient += Time.deltaTime * shakeProgressSpeed;
            print("sada");
            transform.localRotation = Quaternion.Euler(Random.Range(0, shakeCoeficient), Random.Range(0, shakeCoeficient), Random.Range(0, shakeCoeficient));
            

            yield return new WaitForSeconds(0.01f);
        }
    }




}

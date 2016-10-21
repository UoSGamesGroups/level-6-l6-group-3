using UnityEngine;
using System.Collections;

public class rainSplashActivate : MonoBehaviour {

    private GameObject[] rainSplash;

    void Awake()
    {
        rainSplash = GameObject.FindGameObjectsWithTag("rainSplash");
    }


    IEnumerator Start()
    {
        while (true)
        {
            rainSplash[Random.Range(0, rainSplash.Length)].GetComponent<ParticleSystem>().Play(true);
            rainSplash[Random.Range(0, rainSplash.Length)].GetComponent<ParticleSystem>().Play(true);
            rainSplash[Random.Range(0, rainSplash.Length)].GetComponent<ParticleSystem>().Play(true);
            rainSplash[Random.Range(0, rainSplash.Length)].GetComponent<ParticleSystem>().Play(true);


            yield return new WaitForSeconds(0.1f);
        }
    }
}

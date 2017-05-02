using UnityEngine;
using System.Collections;

public class randomThunder : MonoBehaviour {


    private AudioSource audioThunder;
    private Light directionalLight;


    private int chanceToGetThunder;


    void Awake()
    {
        directionalLight = GetComponent<Light>();
        audioThunder = GetComponent<AudioSource>();
    }


    IEnumerator Start()
    {
        while (true)
        {

            yield return new WaitForSeconds(7f);
            chanceToGetThunder = Random.Range(1, 3);

            if (chanceToGetThunder == 1)
            {
                directionalLight.intensity = 8;
                print("lumina");

                
                audioThunder.Play();
                print("sunet");
            } 
        }
    }


    void Update()
    {
        if (directionalLight.intensity > 2)
        {
            directionalLight.intensity -= Time.deltaTime * 3;
        }
    }



}

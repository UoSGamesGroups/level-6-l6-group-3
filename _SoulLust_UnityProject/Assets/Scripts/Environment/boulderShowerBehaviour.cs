using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulderShowerBehaviour : MonoBehaviour {

    [SerializeField] GameObject boulder;
	[SerializeField] float minX;
	[SerializeField] float maxX;
    [SerializeField] float minZ;
    [SerializeField] float maxZ;


    private float timeBetweenBoulder;


    IEnumerator Start()
    {
        while (true)
        {
            transform.localPosition = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
            boulder.transform.localScale = new Vector3(Random.Range(0.3f, 1.5f), Random.Range(0.3f, 1.5f), Random.Range(0.3f, 1.5f));
            Instantiate(boulder, transform.position, transform.rotation = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)));
        
            timeBetweenBoulder = Random.Range(3, 5);
            yield return new WaitForSeconds(timeBetweenBoulder);
        }
    }
}

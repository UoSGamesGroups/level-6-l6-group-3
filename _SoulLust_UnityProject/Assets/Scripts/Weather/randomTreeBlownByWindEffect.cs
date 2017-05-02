using UnityEngine;
using System.Collections;

public class randomTreeBlownByWindEffect : MonoBehaviour {

    private GameObject[] trees;




    void Awake()
    {
        trees = GameObject.FindGameObjectsWithTag("tree");
    }


    IEnumerator Start()
    {
        while (true)
        {
            trees[Random.Range(0, trees.Length)].GetComponent<Animator>().SetTrigger("blow");
            trees[Random.Range(0, trees.Length)].GetComponent<Animator>().SetTrigger("blow");
            trees[Random.Range(0, trees.Length)].GetComponent<Animator>().SetTrigger("blow");
            trees[Random.Range(0, trees.Length)].GetComponent<Animator>().SetTrigger("blow");
            trees[Random.Range(0, trees.Length)].GetComponent<Animator>().SetTrigger("blow");
            trees[Random.Range(0, trees.Length)].GetComponent<Animator>().SetTrigger("blow");
            yield return new WaitForSeconds(0.1f);

        }
    }










}

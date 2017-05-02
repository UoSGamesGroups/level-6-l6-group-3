using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatingBehaviour : MonoBehaviour {

    [SerializeField] private GameObject target;
    [SerializeField] private GameObject[] spawnPosition;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Animator[] gatesAnim;
    [SerializeField] private int numberOfCreeps;


    GameObject[] enemyStored;

	private playerMovement _playerMovement;
	
    private float currentTime=0f;
    private float endTime = 0.5f;

    private GameObject gui;
    private int i; //spawner order
    private GameObject _camera;
    private bool isCameraActivated;
    private Quaternion targetRotation;
    private bool isSpawnCreeps;


    void Awake()
    {
        gui = GameObject.FindGameObjectWithTag("gui");
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
		_playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
    }

    void Start()
    {
        targetRotation = target.transform.rotation;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isCameraActivated = true;
        }
    }


    void Update()
    {
        if (isCameraActivated)
        {
            _camera.transform.position = Vector3.Lerp(_camera.transform.position, target.transform.position, Time.deltaTime * 2);
            _camera.GetComponent<Animator>().enabled = false;
            _camera.transform.rotation = Quaternion.Lerp(_camera.transform.rotation, target.transform.rotation, Time.deltaTime * 1f);
			_playerMovement.enabled = false;
            StartCoroutine(ActivateSpawners());
        }
        if (isSpawnCreeps)
           UnleashEnemies();  
    }



    void UnleashEnemies()
    {
        if(numberOfCreeps >0)
        {
            currentTime += Time.deltaTime;

            if(currentTime >= endTime)
            {
                Instantiate(enemy, spawnPosition[Random.Range(0,spawnPosition.Length)].transform.position, transform.rotation);
                currentTime = 0;
                numberOfCreeps--;
            }
        }

        if(numberOfCreeps == 0)
        {
            enemyStored = GameObject.FindGameObjectsWithTag("enemy");

            if(enemyStored.Length == 0)
            {
                foreach (Animator a in gatesAnim)
                    a.SetBool("open", true);
                GameObject.FindGameObjectWithTag("lock").GetComponent<Animator>().SetTrigger("open");
                // GameObject.FindGameObjectWithTag("lock").GetComponent<SpriteRenderer>().enabled=true;
                enabled = false;
            }
        }
    }

    IEnumerator ActivateSpawners()
    {
        gui.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);

        
        foreach (Animator a in gatesAnim)
            a.SetBool("open", false);

        yield return new WaitForSeconds(1.5f);
        gui.gameObject.SetActive(true);
        isCameraActivated = false;
        _camera.transform.position = Vector3.zero;
        _camera.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        _camera.GetComponent<Animator>().enabled = true;
        GetComponent<BoxCollider>().enabled = false;
		_playerMovement.enabled = true;

        isSpawnCreeps = true;
    }


    // IEnumerator SpawnCreeps()
    // {
    //     while (i<enemies.Length)
    //     {
    //         enemies[i].gameObject.SetActive(true);
    //         i++;
    //         yield return new WaitForSeconds(3f);
    //     }

    //     StartCoroutine(CountCreeps());
    // }

    // IEnumerator CountCreeps()
    // {
    //     while (enemies.Length > 0)
    //     {
    //         enemies = GameObject.FindGameObjectsWithTag("enemy");
    //         yield return new WaitForSeconds(1f);
    //     }


    //     if (enemies.Length == 0)
    //     {
    //         foreach (Animator a in gatesAnim)
    //             a.SetBool("open", true);
    //         GameObject.FindGameObjectWithTag("lock").GetComponent<Animator>().enabled=true;
    //         GameObject.FindGameObjectWithTag("lock").GetComponent<SpriteRenderer>().enabled=true;
    //     }
    // }
}

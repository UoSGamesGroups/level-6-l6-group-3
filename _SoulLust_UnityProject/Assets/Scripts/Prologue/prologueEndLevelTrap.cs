﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class prologueEndLevelTrap : MonoBehaviour {

	[SerializeField] string sceneName;
	[SerializeField] private GameObject imgFadeIn;
	[SerializeField] Animator _cageAnim;
	[SerializeField] Animator _spikeAnim;

	private GameObject _player;
    private cameraFollowsPlayer _camera;

	void Awake()
	{
		_player = GameObject.FindGameObjectWithTag("Player");
        _camera = GameObject.FindGameObjectWithTag("MainCamera").transform.parent.GetComponent<cameraFollowsPlayer>();
	}


	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
			StartCoroutine(ActivateSequence());
	}


	IEnumerator ActivateSequence()
	{
		_cageAnim.SetTrigger("activate");

		yield return new WaitForSeconds(5);

		_spikeAnim.SetTrigger("activate");
		_player.GetComponent<playerMovement>().enabled = false;
		_player.gameObject.tag = "Untagged";
		_player.GetComponent<Rigidbody>().mass=1f;
		_player.GetComponent<Rigidbody>().drag=0f;

        yield return new WaitForSeconds(2);

        GetComponent<Rigidbody>().isKinematic = false;
        _camera.enabled = false;
        imgFadeIn.gameObject.SetActive( true);
		
		yield return new WaitForSeconds(3);
		
		SceneManager.LoadScene(sceneName);
    }
    




}

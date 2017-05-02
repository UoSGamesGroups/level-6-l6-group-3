using UnityEngine;
using System.Collections;

public class audioFadeOut : MonoBehaviour {

    [SerializeField] private float waitTime;
    [SerializeField] private float fadeSpeed;



    private AudioSource _audio;
    private bool isFading;

    void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }


    IEnumerator Start()
    {
        yield return new WaitForSeconds(waitTime);
        isFading = true;
    }

    void Update()
    {
        if (isFading && _audio.volume>=0)
        {
            _audio.volume -= Time.deltaTime * fadeSpeed;
        }
    }
}

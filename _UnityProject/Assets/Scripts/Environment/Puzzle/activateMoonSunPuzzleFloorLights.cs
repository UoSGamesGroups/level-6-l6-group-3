using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateMoonSunPuzzleFloorLights : MonoBehaviour {

    [SerializeField]activateMoonSunPuzzle _activate;

    [SerializeField]float timeUntilActivation;
    private float currentTime;
    private SpriteRenderer _sprite;
    float a;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (_activate.isActivated)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= timeUntilActivation)
            {
                
                a += Time.deltaTime;
                _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, a);
            }

            if (a >= 1)
            {
                this.enabled = false;
            }

        }
    }

}

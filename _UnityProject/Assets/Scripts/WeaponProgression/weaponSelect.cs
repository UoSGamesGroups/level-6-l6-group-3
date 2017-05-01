using UnityEngine;
using System.Collections;

public class weaponSelect : MonoBehaviour {

    private SpriteRenderer sprite;
    [SerializeField] private Color col;
    [SerializeField] private int weaponCode;


    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        
    }

    void OnEnable()
    {
        if (sprite.color != col)
        {
            sprite.color = col;
        }
    }


    void OnMouseEnter()
    {
        sprite.color = Color.white;
        chosenWeapon._chosenWeapon = weaponCode;
    }

    void OnMouseExit()
    {
        sprite.color = col;
        
    }
}

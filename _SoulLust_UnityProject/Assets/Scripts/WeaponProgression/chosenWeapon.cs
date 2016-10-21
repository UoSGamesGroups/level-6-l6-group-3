using UnityEngine;
using System.Collections;

public class chosenWeapon : MonoBehaviour {


    public static int _chosenWeapon = 1;

    [SerializeField] private GameObject[] weaponStack;



    void Update()
    {
        //Choose_weapon_v1();
        Choose_weapon_v2();

    }

    void Choose_weapon_v1()
    {
        switch (_chosenWeapon)
        {
            case 1:
                if (!weaponStack[0].gameObject.activeSelf)
                {
                    foreach (GameObject weapon in weaponStack)
                    {
                        weapon.gameObject.SetActive(false);
                    }
                    weaponStack[0].gameObject.SetActive(true);
                }
                break;

            case 2:
                if (!weaponStack[1].gameObject.activeSelf)
                {
                    foreach (GameObject weapon in weaponStack)
                    {
                        weapon.gameObject.SetActive(false);
                    }
                    weaponStack[1].gameObject.SetActive(true);
                }
                break;

            case 3:
                if (!weaponStack[2].gameObject.activeSelf)
                { 
                    foreach (GameObject weapon in weaponStack)
                    {
                        weapon.gameObject.SetActive(false);
                    }
                    weaponStack[2].gameObject.SetActive(true);
                }
                break;

            case 4:
                if (!weaponStack[3].gameObject.activeSelf)
                {
                    foreach (GameObject weapon in weaponStack)
                    {
                        weapon.gameObject.SetActive(false);
                    }
                    weaponStack[3].gameObject.SetActive(true);
                }
                break;

            case 5:
                if (!weaponStack[4].gameObject.activeSelf)
                {
                    foreach (GameObject weapon in weaponStack)
                    {
                        weapon.gameObject.SetActive(false);
                    }
                    weaponStack[4].gameObject.SetActive(true);
                }
                break;
        }
        
    }


    void Choose_weapon_v2()
    {
        if (_chosenWeapon == 1)
        {
            weaponStack[0].gameObject.SetActive(true);
            weaponStack[1].gameObject.SetActive(false);
            weaponStack[2].gameObject.SetActive(false);
            weaponStack[3].gameObject.SetActive(false);
            weaponStack[4].gameObject.SetActive(false);
        }

        if (_chosenWeapon == 2)
        {
            weaponStack[0].gameObject.SetActive(false);
            weaponStack[1].gameObject.SetActive(true);
            weaponStack[2].gameObject.SetActive(false);
            weaponStack[3].gameObject.SetActive(false);
            weaponStack[4].gameObject.SetActive(false);
        }

        if (_chosenWeapon == 3)
        {
            weaponStack[0].gameObject.SetActive(false);
            weaponStack[1].gameObject.SetActive(false);
            weaponStack[2].gameObject.SetActive(true);
            weaponStack[3].gameObject.SetActive(false);
            weaponStack[4].gameObject.SetActive(false);
        }

        if (_chosenWeapon == 4)
        {
            weaponStack[0].gameObject.SetActive(false);
            weaponStack[1].gameObject.SetActive(false);
            weaponStack[2].gameObject.SetActive(false);
            weaponStack[3].gameObject.SetActive(true);
            weaponStack[4].gameObject.SetActive(false);
        }

        if (_chosenWeapon == 5)
        {
            weaponStack[0].gameObject.SetActive(false);
            weaponStack[1].gameObject.SetActive(false);
            weaponStack[2].gameObject.SetActive(false);
            weaponStack[3].gameObject.SetActive(false);
            weaponStack[4].gameObject.SetActive(true);
        }
    }



}

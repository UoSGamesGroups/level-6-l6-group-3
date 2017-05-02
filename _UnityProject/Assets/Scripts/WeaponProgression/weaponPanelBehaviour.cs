using UnityEngine;
using System.Collections;

public class weaponPanelBehaviour : MonoBehaviour {

    [Header("Panel")]
    [SerializeField] private GameObject panel;

    [Header("Weapons")]
    [SerializeField] GameObject weapon_1;
    [SerializeField] GameObject weapon_2;
    [SerializeField] GameObject weapon_3;
    [SerializeField] GameObject weapon_4;
    [SerializeField] GameObject weapon_5;


    private int progress;
    private bool isShown;


    IEnumerator Start()
    {
        while (true)
        {
            progress = cubeWeaponProgression.weaponProgression;
            yield return new WaitForSeconds(1);
        }

    }

    void Update()
    {
        if (progress > 0)
        {
            ShowPanel();
            WeaponToShow();
        }
        
    }
    

    void ShowPanel()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            isShown = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            isShown = false;
        }


        if (isShown)
        {
            panel.SetActive(true);
            if (Time.timeScale > 0)
            {
                Time.timeScale -= Time.deltaTime * 3f;
            }
        }
        else
        {
            panel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    void WeaponToShow()
    {
        switch (progress)
        {
            case 1:
                weapon_1.SetActive(true);
                break;
            case 5:
                weapon_1.SetActive(true);
                weapon_2.SetActive(true);
                break;
            case 9:
                weapon_1.SetActive(true);
                weapon_2.SetActive(true);
                weapon_3.SetActive(true);
                break;
            case 13:
                weapon_1.SetActive(true);
                weapon_2.SetActive(true);
                weapon_3.SetActive(true);
                weapon_4.SetActive(true);
                break;
            case 17:
                weapon_1.SetActive(true);
                weapon_2.SetActive(true);
                weapon_3.SetActive(true);
                weapon_4.SetActive(true);
                weapon_5.SetActive(true);
                break;
        }

    }
   


}

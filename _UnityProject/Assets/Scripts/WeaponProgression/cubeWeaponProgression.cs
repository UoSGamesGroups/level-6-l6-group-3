using UnityEngine;
using System.Collections;

public class cubeWeaponProgression : MonoBehaviour {




    public static int weaponProgression;

    [SerializeField] private int weaponProg = 17;


    IEnumerator Start()
    {
        while (true)
        {
            weaponProgression = weaponProg;
            yield return new WaitForSeconds(1);
        }

    }

}

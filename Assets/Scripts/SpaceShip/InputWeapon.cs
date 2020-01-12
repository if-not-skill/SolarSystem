using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ProjectSpaceship;
using UnityEngine;

public class InputWeapon : MonoBehaviour
{
    public List<IWeapon> Weapons = new List<IWeapon>();

    void Awake()
    {
        Weapons = GetComponentsInChildren<IWeapon>().ToList();
    }

    public void FireWeapons()
    {
        foreach (var weapon in Weapons)
        {
            //laser.FireWeapon(laser.transform.position
            //    + laser.transform.forward * laser.MaxDistance);
            weapon.FireWeapon(weapon.transform.TransformDirection(Vector3.forward) * weapon.MaxDistance);
        }
    }
}

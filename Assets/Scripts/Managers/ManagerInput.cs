using System;
using System.Collections;
using System.Collections.Generic;
using ProjectSpaceship;
using UnityEngine;

public class ManagerInput : MonoBehaviour
{
    [SerializeField] private ShipMovement spaceShipMovement = null;
    [SerializeField] private string downShift = "e";
    [SerializeField] private string upShift = "q";
    [SerializeField] private string fire = "space";

    public delegate void SimpleDelegate();
    public static SimpleDelegate OnPlayerFire;

    private void Update()
    {
        if (Input.GetKeyDown(downShift))
        {
            spaceShipMovement.DownShift();
        }
        else if (Input.GetKeyDown(upShift))
        {
            spaceShipMovement.UpShift();
        }

        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        if (Math.Abs(horizontal) > 0 || Math.Abs(vertical) > 0)
        {
            spaceShipMovement.Movement(horizontal, vertical);
        }

        var yaw = Input.GetAxis("Yaw");
        var pitch = Input.GetAxis("Pitch");
        var roll = Input.GetAxis("Roll");

        if (Math.Abs(yaw) > 0 || Math.Abs(pitch) > 0 || Math.Abs(roll) > 0)
        {
            spaceShipMovement.Turn(yaw, pitch, roll);
        }

        if (Input.GetKey(fire))
        {
            if (OnPlayerFire != null)
            {
                OnPlayerFire();
            }
        }
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShip
{
    public enum SubsystemType
    {
        Engines,
        Weapons,
        Health
    }

    public class ShipSubsystem : MonoBehaviour
    {
        public ProjectSpaceship.SpaceShip _SpaceShip = null;


        private void Awake()
        {
            if (_SpaceShip == null)
            {
                _SpaceShip = GetComponentInParent<ProjectSpaceship.SpaceShip>();
            }
        }
        public virtual void ResetSubsystem()
        {
        }
    }

}
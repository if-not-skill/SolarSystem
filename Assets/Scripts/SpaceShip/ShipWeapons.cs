using System.Collections.Generic;
using System.Linq;
using SpaceShip;
using UnityEngine;

namespace ProjectSpaceship
{
    public class ShipWeapons : ShipSubsystem
    {

        public List<IWeapon> Weapons = new List<IWeapon>();
        private GameAgent gameAgent = null;

        private void Awake()
        {
            gameAgent = transform.GetComponentInParent<GameAgent>();
            Weapons = GetComponentsInChildren<IWeapon>().ToList();
        }

        private void OnEnable()
        {
            if (gameAgent.AgentFaction == GameAgent.Factions.Player)
            {
                ManagerInput.OnPlayerFire += FireWeapons;
            }
        }

        private void OnDisable()
        {
            if (gameAgent.AgentFaction == GameAgent.Factions.Player)
            {
                ManagerInput.OnPlayerFire -= FireWeapons;
            }
        }

        public float MaxDistance()
        {
            if (Weapons == null) return 0;
            return Weapons[0].MaxDistance;
        }

        public void FireWeapons(Vector3 targetPosition)
        {
            foreach (var weapon in Weapons)
            {
                weapon.FireWeapon(targetPosition);
            }
        }

        public void FireWeapons()
        {
            foreach (var weapon in Weapons)
            {
                weapon.FireWeapon(weapon.transform.TransformDirection(Vector3.forward) * weapon.MaxDistance);
            }
        }

    }

}

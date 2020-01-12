using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace ProjectSpaceship
{
	public class EnemyAttack : MonoBehaviour {
		[SerializeField] Transform Target = null;
        [SerializeField] private ShipWeapons shipWeapons = null;

		private void Update() {
			if (InFront() && HaveLineOfSight()) {
                FireWeapon(Target.position);
            }
		}

		public bool InFront() {
            if (Target == null) return false;
            Vector3 directionToTarget = transform.position - Target.position;
            float angle = Vector3.Angle(transform.forward, directionToTarget);
            if (Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270)
            {   
                return true;
            }
            return false;
        }

		public bool HaveLineOfSight() {
            if (Target == null) return false;
            RaycastHit hit;
			Vector3 direction = Target.position - transform.position;
            
            if (Physics.Raycast(transform.position, direction, out hit, shipWeapons.MaxDistance()))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    return true;
                }
            }
            
            return false;
        }   

		private void FireWeapon(Vector3 targetPosition) {
            //foreach (var weapon in _Weapons)
            //{
            //    weapon.FireWeapon(targetPosition);
            //}
            shipWeapons.FireWeapons(targetPosition);
        }
    }
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProjectSpaceship
{
	public interface IWeapon
    {
        float MaxDistance { get; }
        Transform transform { get; }
        void FireWeapon(Vector3 targetPosition);
        Vector3 CastRay(Vector3 targetPosition);
        void Visualize(Vector3 targetPosition);

        void Damage(float damageAmount, Vector3 hitPosition, GameAgent sender);
	}
}

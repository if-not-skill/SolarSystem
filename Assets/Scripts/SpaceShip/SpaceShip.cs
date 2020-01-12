using System.Collections.Generic;
using System.Collections;
using SpaceShip;
using UnityEngine;

namespace ProjectSpaceship
{
	public class SpaceShip : MonoBehaviour //, ITrackable
	{
		public GameAgent Agent = null;

		public ShipSubsystem[] Subsystems = null;

        //[SerializeField] protected List<ModuleMount> moduleMounts = new List<ModuleMount>();



		protected virtual void Awake()
		{
            Subsystems = GetComponentsInChildren<ShipSubsystem>();
            if (Subsystems == null) return;
			foreach (var subsystem in Subsystems)
			{
				//subsystem.Construct(moduleMounts);
			}
		}

		public virtual void OnAgentEnterShip(GameAgent newAgent)
		{
	      Agent = newAgent;
		}
	}
}
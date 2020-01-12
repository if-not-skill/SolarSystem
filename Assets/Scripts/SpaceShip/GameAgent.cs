using UnityEngine;

namespace ProjectSpaceship
{
    public class GameAgent : MonoBehaviour
    {
        public enum Factions { NoFaction, Player, Friends, Enemies }
        
        public SpaceShip CurrentShip;
        public SpaceShip StartingShip;
        
        public Factions AgentFaction;

        public delegate void GameAgentDelegate(GameAgent gameAgent);

        public GameAgentDelegate OnPlayerEnteredShip;
        public GameAgentDelegate OnPlayerExitedShip;


        private void Start()
        {
            if (StartingShip != null)
            {
                CurrentShip = StartingShip;
                if (AgentFaction == Factions.Player && OnPlayerEnteredShip != null)
                {
                    OnPlayerEnteredShip(this);
                }
            }
        }

        private void Update()
        {

        }
    }
}
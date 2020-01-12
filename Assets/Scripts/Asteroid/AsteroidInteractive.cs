using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProjectSpaceship
{
    public class AsteroidInteractive : MonoBehaviour, IDamageable
    {
        [SerializeField] float _health;
        [SerializeField] int _score = 1;
        [SerializeField] private GameObject _smallAsteroid = null;


        float IDamageable.Health => throw new System.NotImplementedException();

        public int DivisionCounter = 0;
        public int MaxDivisionCounter = 3;

        public void ReceiveDamage(float damageAmount, Vector3 hitPosition, GameAgent sender)
        {
            _health -= damageAmount;

            if(_health <= 0)
            {
                PoolManager.Instance.Active(0, transform.position);
                Destroy(gameObject);

                if (_smallAsteroid != null && MaxDivisionCounter >= DivisionCounter)
                {
                    var spread = Random.Range(0.5f, 1.5f);

                    var asteroid1 = Instantiate(_smallAsteroid, new Vector3(transform.position.x - spread, transform.position.y - spread, transform.position.z - spread),
                        Quaternion.identity).GetComponent<AsteroidInteractive>();
                    asteroid1.DivisionCounter = DivisionCounter + 1;
                    
                    var asteroid2 = Instantiate(_smallAsteroid, new Vector3(transform.position.x + spread, transform.position.y + spread, transform.position.z + spread),
                        Quaternion.identity).GetComponent<AsteroidInteractive>();
                    asteroid2.DivisionCounter = DivisionCounter + 1;
                }
                ManagerEvents.Instance.AddScore(_score);
            }
        }

        public void ReceiveHeal(float healAmount, Vector3 hitPosition, GameAgent sender)
        {
            throw new System.NotImplementedException();
        }
    }
}
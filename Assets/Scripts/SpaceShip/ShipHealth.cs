using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using SpaceShip;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectSpaceship
{

    public class ShipHealth : ShipSubsystem, IDamageable
    {
        [SerializeField] private Rigidbody _rigidbody = null;
        [SerializeField] private float _health;
        [SerializeField] private float _maxHealth = 100f;
        [SerializeField] private Text HealthPlayer = null;
        [SerializeField] private int score = 100;
        [SerializeField] private Slider slider = null;
        

        public delegate void HealthDelegate(float healthLoss);

        public HealthDelegate ReceiceDamage_ = null;
        public HealthDelegate ReceiveHeal_ = null;

        public float Health => _health;

        private void Start()
        {
            _health = _maxHealth;
            ManagerEvents.Instance.GameStart_();
            if (slider != null)
            {
                slider.value = _health / _maxHealth;
            }

            if (HealthPlayer != null)
            {
                HealthPlayer.text = _health.ToString(CultureInfo.InvariantCulture);
            }
        }

        public void ReceiveDamage(float damageAmount, Vector3 hitPosition, GameAgent sender)
        {
            if (ReceiceDamage_ != null)
                ReceiceDamage_(damageAmount);
            

            _health = Mathf.Clamp(_health - damageAmount, 0, _maxHealth);
            if(_SpaceShip.Agent.AgentFaction == GameAgent.Factions.Player) {
                HealthPlayer.text = _health.ToString(CultureInfo.InvariantCulture);
            }

            if (slider != null)
            {
                slider.value = _health / _maxHealth;
            }
                //AddForce(damageAmount, hitPosition);
            if (_health <= 0)
            {
                if(_SpaceShip.Agent.AgentFaction == GameAgent.Factions.Enemies)
                {
                    ManagerEvents.Instance.AddScore(score);
                    ManagerEnemy.Instance.EnemyDie();
                }
                else if(_SpaceShip.Agent.AgentFaction == GameAgent.Factions.Friends)
                {
                    ManagerEvents.Instance.AddScore(-score);
                }
                else if (_SpaceShip.Agent.AgentFaction == GameAgent.Factions.Player)
                {
                    ManagerEvents.Instance.GameLost_();
                }

                Destroy(gameObject);
            }
        }

        public void ReceiveHeal(float healAmount, Vector3 hitPosition, GameAgent sender)
        {
            if (ReceiveHeal_ != null)
                ReceiveHeal_(healAmount);
            _health = Mathf.Clamp(_health + healAmount, 0, _maxHealth);
            HealthPlayer.text = _health.ToString(CultureInfo.InvariantCulture);
            if (slider != null)
            {
                slider.value = _health / _maxHealth;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                ReceiveDamage(2, contact.point, null);
            }
        }

        public void AddForce(float forceX, Vector3 hitPosition, Transform hitSource = null)
        {
            //Debug.Log("Trying to AddForce to: " + gameObject.name + " -> " + hitSource.name);
            if (_rigidbody == null) return;

            Vector3 forceVector = hitPosition - hitPosition.normalized;
            _rigidbody.AddForceAtPosition(forceVector, hitPosition, ForceMode.Impulse);
        }
    }
}
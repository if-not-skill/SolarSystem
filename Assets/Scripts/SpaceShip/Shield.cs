using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ProjectSpaceship;

public class Shield : MonoBehaviour, IDamageable
{
    [SerializeField] Text shieldPoint;
    [SerializeField] float _health;

    public float Health => _health;

    public void ReceiveDamage(float damageAmount, Vector3 hitPosition, GameAgent sender)
    {
        _health -= Mathf.Clamp(_health - damageAmount, 0, 100);
        shieldPoint.text = _health.ToString();
        if(Health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void ReceiveHeal(float healAmount, Vector3 hitPosition, GameAgent sender)
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {
        shieldPoint.text = Health.ToString();
    }

    void Update()
    {
        
    }
}

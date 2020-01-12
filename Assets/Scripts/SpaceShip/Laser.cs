using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectSpaceship;
using UnityEditor;

public class Laser : MonoBehaviour, IWeapon
{
    public bool CanFire = true;
    public float DefaultDamage = 50;
    public float MaxDistance = 100f;
    float IWeapon.MaxDistance => MaxDistance;
    Transform IWeapon.transform => transform;

    [SerializeField] private ProjectSpaceship.ShipWeapons _shipWeapons;
    [SerializeField] private float MaxTimeLaserIsOn = 1f;
    [SerializeField] private float MaxTimeLaserIsOff = 1f;
    [SerializeField] private LineRenderer lineRend;
    [SerializeField] private Light lightPoint;
    [SerializeField] private List<IDamageable> TargetList;
    
    private AudioSource audioSource = null;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        _shipWeapons = GetComponentInParent<ProjectSpaceship.ShipWeapons>();
        TargetList = new List<IDamageable>();
        lineRend = GetComponent<LineRenderer>();
        lightPoint = GetComponent<Light>();
    }

    private void Start()
    {
        LaserSwitch(false);
    }

    public void FireWeapon(Vector3 targetPosition)
    {
        if (CanFire)
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }
            Visualize(CastRay(targetPosition));
        }
    }

    public void Visualize(Vector3 targetPosition)
    {
        LaserSwitch(true);
        lineRend.SetPosition(0, transform.position);
        lineRend.SetPosition(1, targetPosition);
        StartCoroutine(TurnOffWeapoCor(MaxTimeLaserIsOn));
    }

    public void LaserSwitch(bool isActive)
    {
        lineRend.enabled = isActive;
        lightPoint.enabled = isActive;
    }

    public Vector3 CastRay()
    {
        var targetCoordinates = transform.position + (transform.forward * MaxDistance) + transform.position;
        return CastRay(targetCoordinates);
    }

    public Vector3 CastRay(Vector3 targetPosition)
    {
        CanFire = false;

        RaycastHit hit;
        GameAgent gameAgent = GetComponentInParent<GameAgent>();
        if(gameAgent.AgentFaction != GameAgent.Factions.Player)
        {
            targetPosition -= transform.position;
        }
        if (Physics.Raycast(transform.position, targetPosition, out hit))
        {
            var targetHit = hit.transform.GetComponent<IDamageable>();
            if (targetHit != null)
            {
                TargetList.Add(targetHit);
                Damage(DefaultDamage, hit.point, _shipWeapons._SpaceShip.Agent);
            }
            return hit.point;
        }
        return transform.position + (transform.forward * MaxDistance);
    }

    public void TurnOffWeapon()
    {
        LaserSwitch(false);
        StartCoroutine(PauseShots(MaxTimeLaserIsOff));
    }

    IEnumerator PauseShots(float timeBeforeTurningOff)
    {
        yield return new WaitForSeconds(timeBeforeTurningOff);
        CanFire = true;
    }

    IEnumerator TurnOffWeapoCor(float timeBeforeTurningOn)
    {
        yield return new WaitForSeconds(timeBeforeTurningOn);
        TurnOffWeapon();
    }

    public void Damage(float damageAmount, Vector3 hitPosition, ProjectSpaceship.GameAgent sender)
    {
        foreach (IDamageable value in TargetList)
        {
            value.ReceiveDamage(damageAmount, hitPosition, sender);
        }
        TargetList.Clear();
    }
}
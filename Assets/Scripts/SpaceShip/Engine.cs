using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    public float MovementSpeed;

    [SerializeField] private Light lightPoint;

    private void Awake()
    {
        lightPoint = GetComponent<Light>();
    }

    private void Start()
    {
        SwitchLight(false);
    }

    public void SwitchLight(bool isActive)
    {
        lightPoint.enabled = isActive;
    }

    public float Thrust()
    {
        return MovementSpeed;
    }
}

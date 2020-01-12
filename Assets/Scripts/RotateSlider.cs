using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSlider : MonoBehaviour
{
    [SerializeField] GameObject target = null;

    void Update()
    {
        if(target != null)
        {
            transform.LookAt(target.transform);
        }
    }
}

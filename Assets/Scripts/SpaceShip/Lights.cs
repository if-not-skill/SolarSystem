using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public List<Light> Flashlights = new List<Light>();

    private bool enable = false;

    private void Start()
    {
        SwitchEnabled(enable);
        enable = !enable;
    }

    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            SwitchEnabled(enable);
            enable = !enable;
        }
    }

    private void SwitchEnabled(bool isEnabled)
    {
        foreach(var flashlight in Flashlights)
        {
            flashlight.enabled = isEnabled;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Random.Range(-2, 2), 
            Random.Range(-2, 2), Random.Range(-2, 2));       
    }
}

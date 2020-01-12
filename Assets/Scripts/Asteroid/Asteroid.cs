using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProjectSpaceship
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] float _minScale = 0.8f;
        [SerializeField] float _maxScale = 1.2f;
        [SerializeField] float _rotationOffset = 100f;

        Vector3 _randomRotation;

        void Start()
        {
            Vector3 scale = Vector3.one;
            scale.x = Random.Range(_minScale, _maxScale);
            scale.y = Random.Range(_minScale, _maxScale);
            scale.z = Random.Range(_minScale, _maxScale);

            transform.localScale = scale;

            _randomRotation.x = Random.Range(_rotationOffset, _rotationOffset);
            _randomRotation.y = Random.Range(_rotationOffset, _rotationOffset);
            _randomRotation.z = Random.Range(_rotationOffset, _rotationOffset);
        }

        void Update()
        {
            transform.Rotate(_randomRotation * Time.deltaTime);
        }
    }
}
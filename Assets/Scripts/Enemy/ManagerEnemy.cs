using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using REM;

public class ManagerEnemy : SingletonManager<ManagerEnemy>
{
    [SerializeField] private GameObject Enemy = null;
    [SerializeField] private int MaxNumberOfEnemy = 5;
    [SerializeField] private int GridSpacing = 10;

    private int NumberOfEnemy;

    private void Start()
    {
        NumberOfEnemy = MaxNumberOfEnemy;
        //for (int x = 0; x < MaxNumberOfEnemy; x++)
        //{
        //    for (int y = 0; y < MaxNumberOfEnemy; y++)
        //    {
        //        for (int z = 0; z < MaxNumberOfEnemy; z++)
        //        {
        //            InstantiateEnemy(x, y, z);
        //        }
        //    }
        //}
        for (var i = 0; i < MaxNumberOfEnemy; i++)
        {
            InstantiateEnemy(i, i, i);
        }
    }

    private void Update()
    {
        if (NumberOfEnemy < MaxNumberOfEnemy)
        {
            InstantiateEnemy(0, 0, 0);
            NumberOfEnemy++;
        }
    }

    void InstantiateEnemy(int x, int y, int z)
    {
        GameObject gameObject = 
        Instantiate(Enemy,
            new Vector3(transform.position.x + OffsetEnemy() + (x * GridSpacing),
                transform.position.y + OffsetEnemy() + (y * GridSpacing),
                transform.position.z + OffsetEnemy() + (z * GridSpacing)),
                Quaternion.identity,
                transform);
        gameObject.SetActive(true);
    }

    public void EnemyDie()
    {
        NumberOfEnemy--;
    }

    float OffsetEnemy()
    {
        return Random.Range(-GridSpacing / 2f, GridSpacing / 2f);
    }
}

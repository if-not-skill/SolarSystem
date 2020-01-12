using UnityEngine;
using REM;

public class ManagerAsteroid : SingletonManager<ManagerAsteroid>
{
    public GameObject Asteroid;
    public int NumberOfAsteroidOnAxis = 10;
    public int GridSpacing = 100;

    protected void Start() {
        PlaceAsteroids();
    }

    private void PlaceAsteroids() {
        for(var x = 0; x < NumberOfAsteroidOnAxis; x++)
        {
            for(var y = 0; y < NumberOfAsteroidOnAxis; y++)
            {
                for(var z = 0; z < NumberOfAsteroidOnAxis; z++)
                {
                    InstantiateAsteroid(x, y, z);
                }
            }
        }
    }

    public void InstantiateAsteroid(int x, int y, int z) {
        Instantiate(Asteroid,
            new Vector3(transform.position.x + OffsetAsteroid() + (x*GridSpacing),
                transform.position.y + OffsetAsteroid() + (y*GridSpacing),
                transform.position.z + OffsetAsteroid() + (z*GridSpacing)),
                Quaternion.identity,
                transform);
    }

    float OffsetAsteroid() {
        return Random.Range(-GridSpacing / 2f, GridSpacing / 2f);
    }
}
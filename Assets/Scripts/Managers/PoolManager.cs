using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

using REM;

public class PoolManager : SingletonManager<PoolManager>
{

    enum NamesPrefab
    {
        Explosion = 0,
    }

    [SerializeField] private List<GameObject> Prefabs = new List<GameObject>();
    [SerializeField] private int AmountCreateAtStart = 10;
    [SerializeField] private List<GameObject> SpawnedInsts = new List<GameObject>();
    [SerializeField] private List<string> SpawnedInstsNames = new List<string>();
    [SerializeField] private List<GameObject> Used = new List<GameObject>();
    
    protected override void Awake()
    {
        base.Awake();
    }

    protected void Start()
    {
        foreach (var prefab in Prefabs)
        {
            for (var i = 0; i < AmountCreateAtStart; i++)
            {
                SpawnedInsts.Add(Instantiate(prefab, this.transform));
                prefab.SetActive(false);
            }
        }

        foreach (var inst in SpawnedInsts)
        {
            SpawnedInstsNames.Add(inst.name);
        }

    }

    public void Active(int id, Vector3 position)
    {
        Spawn(SpawnedInsts[id], position);
        StartCoroutine(Pause(2, id));
    }

    private IEnumerator Pause(float time, int id)
    {
        yield return new WaitForSeconds(time);
        Despawn(SpawnedInsts[id]);
    }

    public void Spawn(GameObject objectToSpawn, Vector3 position)
    {
        if (SpawnedInstsNames.Find(x => x == objectToSpawn.name) != null)
        {
            SpawnedInsts[SpawnedInstsNames.IndexOf(objectToSpawn.name)].transform.position = position;
            SpawnedInsts[SpawnedInstsNames.IndexOf(objectToSpawn.name)].SetActive(true);
        }
    }


    public void Despawn(GameObject objectToDespawn)
    {
        if (SpawnedInstsNames.Find(x => x == objectToDespawn.name) != null)
        {
            SpawnedInsts[SpawnedInstsNames.IndexOf(objectToDespawn.name)].SetActive(false);
        }
    }

    private void DeleteSpawned(GameObject objectToDelete)
    {
        SpawnedInsts.Remove(objectToDelete);
        SpawnedInstsNames.Remove(objectToDelete.name);
    }

    private void AddSpewned(GameObject objectToAdd)
    {
        SpawnedInsts.Add(objectToAdd);
        SpawnedInstsNames.Add(objectToAdd.name);
    }

}

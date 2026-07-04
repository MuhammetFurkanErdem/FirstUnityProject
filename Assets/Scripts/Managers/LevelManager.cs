using NUnit.Framework;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject door;
    public GameObject collectablePrefab;
    public List<GameObject> collectables;

    public void RestartLevelManager()
    {
        DeactivateDoor();
        RandomizeDoorPosition();
        DeleteCollectables();
        GenerateCollectables();
    }

    private void DeleteCollectables()
    {
        foreach (GameObject collectable in collectables)
        {
            Destroy(collectable);
        }
        collectables.Clear();
    }

    private void GenerateCollectables()
    {
        var newCollectable = Instantiate(collectablePrefab);
        newCollectable.transform.position = new Vector3(Random.Range(-3.5f, 3.5f), 0, 8);
        collectables.Add(newCollectable);
    }

    private void RandomizeDoorPosition()
    {
        var pos = door.transform.position;
        pos.x = Random.Range(-3.2f, 3.2f);
        door.transform.position = pos;
    }

    private void DeactivateDoor()
    {
        door.SetActive(false);
    }

    public void AppleCollected()
    {
        door.SetActive(true);
    }

}

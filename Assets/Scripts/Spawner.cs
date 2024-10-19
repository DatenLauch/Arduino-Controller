using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject spawnOnThisObject;
    [SerializeField]
    int objectBorderSize;
    int spawnSizeX;
    int spawnSizeY;
    [SerializeField]
    GameObject itemToSpawn;
    [SerializeField]
    int quantityToSpawn;
    Dictionary<Vector3, GameObject> itemsDictionary;

    // Start is called before the first frame update
    void Start()
    {
        spawnSizeX = (int)spawnOnThisObject.transform.localScale.x;
        spawnSizeY = (int)spawnOnThisObject.transform.localScale.y;
        itemsDictionary = new Dictionary<Vector3, GameObject>();
        startSpawner();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void startSpawner()
    {
        while (quantityToSpawn > 0)
        {
            quantityToSpawn--;
            int tries = 0;
            while (tries < 100)
            {
                Vector3 position = randomizePosition();
                if (!itemsDictionary.ContainsKey(position) & position != new Vector3(0, 0, 0))
                {
                    spawnOnPosition(position);
                    break;
                }
                tries++;
            }
            if (tries == 100)
            {
                Debug.Log("Couldn't find empty area to spawn item!");
                return;
            }
        }
    }

    Vector3 randomizePosition()
    {
        int spawnRangeX = spawnSizeX - objectBorderSize;
        int spawnRangeY = spawnSizeY - objectBorderSize;
        int randomX = UnityEngine.Random.Range(-spawnRangeX / 2, spawnRangeX / 2);
        int randomY = UnityEngine.Random.Range(-spawnRangeY / 2, spawnRangeY / 2);
        Vector3 position = new Vector3(randomX, 0, randomY);
        return position;
    }

    void spawnOnPosition(Vector3 position)
    {
        GameObject spawnedItem = Instantiate(itemToSpawn);
        itemToSpawn.transform.position = new Vector3(position.x, 0.75f, position.z);
        itemsDictionary.Add(position, spawnedItem);
        Debug.Log(itemsDictionary);
    }
}

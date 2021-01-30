using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTiles : MonoBehaviour
{
    public GameObject[] prefabs;
    public float zSpawn = 0;
    public float tileLen = 5;
    public int numberOfTiles = 3;
    public Transform Player;
    private List<GameObject> ActiveTiles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
            {
                SpawnTile(0);
            }
            else
                SpawnTile(Random.Range(1, 5));
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.position.z - 55 > zSpawn - (numberOfTiles * tileLen))
        {
            if(Player.position.z > 300)
            {
                SpawnTile(Random.Range(1, prefabs.Length));
                DeleteTile();
                Debug.Log("Range > 200");
            }
            else
            {
                SpawnTile(Random.Range(1, 5));
                DeleteTile();
                Debug.Log("Range" + Player.position.z);
            }
            
        }
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(prefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        ActiveTiles.Add(go);
        zSpawn += tileLen;
    }

    private void DeleteTile()
    {
        Destroy(ActiveTiles[0]);
        ActiveTiles.RemoveAt(0);
    }
}

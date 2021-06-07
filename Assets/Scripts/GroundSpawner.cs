using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
  public GameObject groundTile;
 // public GameObject city;
  Vector3 nextSpawnPoint;
   // Vector3 nextSpawnPointC;



  public void SpawnTile (bool spawnItems)
   {
     GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
     nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if (spawnItems)
        {
            temp.GetComponent<GroundTile>().spawnObstacle();
            temp.GetComponent<GroundTile>().spawnMasks();
        }
   }

  /* public void SpawnCity ()
    {
        GameObject tempC = Instantiate(city, nextSpawnPointC, Quaternion.identity);
        nextSpawnPointC = tempC.transform.GetChild(3).transform.position;
    } */
    // Start is called before the first frame update
    private void Start()
    {
      for (int i = 0; i < 15; i++) {
     //       SpawnCity();
            if (i < 3)
            {
                SpawnTile(false);
            }
            else
      SpawnTile(true);
      }
    
        }
    }
  

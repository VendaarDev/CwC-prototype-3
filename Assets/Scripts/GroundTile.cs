using UnityEngine;

public class GroundTile : MonoBehaviour
{
  GroundSpawner groundSpawner;
  public GameObject obstaclePrefab;
  public GameObject maskPrefab;

 [SerializeField] GameObject tallObstaclePrefab;
 [SerializeField] float  tallObstacleChance = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        
    }

    private void OnTriggerExit (Collider other)
    {
      groundSpawner.SpawnTile(true);
      Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnObstacle ()
    {
      GameObject obstacleToSpawn = obstaclePrefab;
      float random = Random.Range(0f, 1f);
        if (random < tallObstacleChance)
        {
            obstacleToSpawn = tallObstaclePrefab;
        }

      int obstacleSpawnIndex = Random.Range(2, 5);
      Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

      Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }

    public void spawnMasks ()
    {
      int masksToSpawn = Random.Range(0, 2);
      for (int i = 0; i < masksToSpawn; i++) {
        GameObject temp = Instantiate(maskPrefab, transform);
        temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
      }
    }

    Vector3 GetRandomPointInCollider (Collider collider)
    {
      Vector3 point = new Vector3(
      Random.Range(collider.bounds.min.x, collider.bounds.max.x),
      Random.Range(collider.bounds.min.y, collider.bounds.max.y),
      Random.Range(collider.bounds.min.z, collider.bounds.max.z));

      if (point != collider.ClosestPoint(point)) {
        point = GetRandomPointInCollider(collider);
      }

      point.y = 1;
      return point;
    }
}

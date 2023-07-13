using UnityEngine;

public class ObjectSpawner2 : MonoBehaviour
{
    [SerializeField]
    private int objectSpawnCount = 30;
    [SerializeField]
    private GameObject[] prefabArray;
    [SerializeField]
    private Transform[] spawnPointArray;

    private int currentObjectCount = 0;
    private float objectSpawnTime = 0.0f;

    private void Update()
    {
        if (currentObjectCount + 1 > objectSpawnCount)
            return;

        objectSpawnTime += Time.deltaTime;

        //0.5초에 한번씩 실행
        if(objectSpawnTime >= 0.5f)
        { 
            int prefabIndex = Random.Range(0, prefabArray.Length);
            int spawnIndex = Random.Range(0, spawnPointArray.Length);

            Vector3 position = spawnPointArray[spawnIndex].position;
            GameObject clone = Instantiate(prefabArray[prefabIndex], position, Quaternion.identity);

            Vector3 moveDirection = (spawnIndex == 0 ? Vector3.right : Vector3.left);
            clone.GetComponent<Movement2D2>().Setup(moveDirection);

            currentObjectCount++;
            objectSpawnTime = 0.0f;
        }
    }
}

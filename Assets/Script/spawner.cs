using UnityEngine;

public class spawner : MonoBehaviour
{
    public float minSpawnDelay;
    public float maxSpawnDelsy;
    public GameObject[] gameObjects;
    void OnEnable()
    {
        Invoke("spawn", Random.Range(minSpawnDelay, maxSpawnDelsy));
    }
    void OnDisable(){
        CancelInvoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawn(){
        var randomObject = gameObjects[Random.Range(0, gameObjects.Length)];
    Instantiate(randomObject, transform.position, Quaternion.identity);
    Invoke("spawn", Random.Range(minSpawnDelay, maxSpawnDelsy));
    }
}

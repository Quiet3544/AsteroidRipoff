using System.Collections;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject playerObj;
    public AsteroidSpawner1[] asteroidsPrefab;
    public float spawnTime = .5f;
    public float asteroidSpeed = 100f;
    Vector3 positiony;
    float minX;
    float maxX;
    float minY;
    float maxY;
    float wantedX;
    float wantedY;
    void Start()
    {
        StartCoroutine(locationGenerator());
    }

    void whichToSpawn()
    {
        transform.rotation = Random.rotation;
        int i = Random.Range(0, 100);
        for (int j = 0; j < asteroidsPrefab.Length; j++)
        {
            if (i >= asteroidsPrefab[j].minProbabilityRange && i <= asteroidsPrefab[j].maxProbabilityRange)
            {

                var asteroid = Instantiate(asteroidsPrefab[j].spawnObject, positiony, Quaternion.identity);
                asteroid.GetComponent<Rigidbody2D>().AddForce(asteroidSpeed * Time.deltaTime * transform.up);


                break;
            }
        }
    }

    IEnumerator locationGenerator()
    {
        while (true)
        {
            int location = Random.Range(0, 4);
            Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
            minX = (-stageDimensions.x) + 1f;
            maxY = stageDimensions.x - 1f;
            minY = (-stageDimensions.y) + 1f;
            maxX = stageDimensions.y - 1f;


            wantedX = Random.Range(minX, maxX);
            wantedY = Random.Range(minY, maxY);
            if (Mathf.Approximately(playerObj.transform.position.x, wantedX)
                && Mathf.Approximately(playerObj.transform.position.y, wantedY))
            {
                wantedX = Random.Range(minX, maxX);
                wantedY = Random.Range(minY, maxY);
            }
            positiony = new Vector3(wantedX, wantedY);
            whichToSpawn();

            yield return new WaitForSeconds(spawnTime);
        }
    }
}



[System.Serializable]
public class AsteroidSpawner1
{
    public GameObject spawnObject;
    public Rigidbody2D rigidbody2D;
    public int minProbabilityRange = 0;
    public int maxProbabilityRange = 100;
}
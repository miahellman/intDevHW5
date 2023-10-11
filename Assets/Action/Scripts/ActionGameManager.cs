using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionGameManager : MonoBehaviour
{
    public GameObject cloudPrefab;

    public int maxClouds;
    public int minClouds;


    public float timeToCloud;
    float timeToCloudCounter;

    BoxCollider2D worldBounds;

    Vector3 minBounds;
    Vector3 maxBounds;

    List<GameObject> allClouds = new List<GameObject>();

    private void Start()
    {
        worldBounds = GetComponent<BoxCollider2D>();
        minBounds = worldBounds.bounds.min;
        maxBounds = worldBounds.bounds.max;

    }

    private void Update()
    {
        timeToCloudCounter += Time.deltaTime * 5;
        if (timeToCloudCounter > timeToCloud || allClouds.Count < minClouds)
        {
            if (allClouds.Count < maxClouds)
            {
                MakeACloud();
                timeToCloudCounter = 0;
            }
        }
    }

    void MakeACloud()
    {
        GameObject newCloud = Instantiate(cloudPrefab);
        Vector3 newPos = new Vector3(
            Random.Range(minBounds.x, maxBounds.x),
            Random.Range(minBounds.y, maxBounds.y),
            0f
            );
        newCloud.transform.position = newPos;
        allClouds.Add(newCloud);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject, 0.5f);
        }
    }

}

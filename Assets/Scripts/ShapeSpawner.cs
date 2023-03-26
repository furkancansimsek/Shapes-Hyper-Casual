using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] shapes;
    public float spawnRate;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            int where = Random.Range(0, spawnPoints.Length);
            int who = Random.Range(0, shapes.Length);
            Instantiate(shapes[who], spawnPoints[where].position, Quaternion.identity);
            spawnRate = Random.Range(.5f, 1f);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}

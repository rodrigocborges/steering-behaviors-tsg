using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSpawner : MonoBehaviour
{
    [SerializeField] private GameObject entity;
    [SerializeField] private int amount;
    [SerializeField] private float radius;
    void Start()
    {
        for(int i = 0; i < amount; ++i)
        {
            float randomX = Random.Range(-radius, radius);
            float randomY = Random.Range(-radius, radius);
            GameObject e = Instantiate(entity, new Vector3(randomX, randomY, 0), Quaternion.identity);
            e.transform.parent = transform;
        }
    }
}

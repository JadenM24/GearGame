using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearSpawner : MonoBehaviour
{
    [SerializeField] private int maxCount = 0;
    [SerializeField] private GameObject gearPrefab = null;
    [SerializeField] private float minTime = 0f, maxTime = 0f;

    private float tempTime = 0f;
    internal static int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        tempTime = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (tempTime <= 0f && maxCount > count)
        {
            GameObject temp = Instantiate(gearPrefab, Vector2.zero, Quaternion.identity);
            tempTime = Random.Range(minTime, maxTime);
            count++; 
        }
        else if(maxCount > count)
        {
            tempTime -= Time.deltaTime;
        }
    }
}

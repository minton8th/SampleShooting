using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] rockPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenRock", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenRock()
    {
        int randomNum = Random.Range(0, 8);
        Instantiate(rockPrefab[randomNum], new Vector3(-2.5f + 5 * Random.value, 6, 0), Quaternion.identity);
    }
}

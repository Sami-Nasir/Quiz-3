using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] gObject;
    public Transform t;
    private Vector3 pos;
    float var;
    private float offset = 10.0f;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAnimal()); 
    }

    // Update is called once per frame
    void Update()
    {
        var = Random.Range(-21, 23);
        i=Random.Range(0, gObject.Length);
    }
    IEnumerator SpawnAnimal()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            Instantiate(gObject[i],new Vector3(var, -6f,-485f), transform.rotation);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalForce : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody rigidBody;
    private float temp=0f;
    bool playerManager;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerManager = GameObject.Find("Player").GetComponent<PlayerMovement>().playerCatchAnimal;
        StartCoroutine(DistroyPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        addForce();
    }
    private void addForce()
    {
        rigidBody.AddForce(Vector3.forward * speed);
    }
    IEnumerator DistroyPlayer()
    {
        while (true)
        {
            if (playerManager)
            {
                yield return new WaitForSeconds(3.0f);
                Destroy(gameObject);
            }
        }
    }
}

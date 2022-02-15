using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rbody;
    private float speed = 20f;
    private float movementInput = 10f;
    public GameObject animal;
    private float horizontalInput;
    private float verticalInput;
    private Renderer renderer;
    private bool isGround = false;
    private int Score = 0;
    public bool playerCatchAnimal=false;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Projectile();
    }
     void Movement()
    {
        horizontalInput=Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput);
    }
     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Animal"))
        {
            animal.transform.parent = transform;
            playerCatchAnimal = true;
            isGround = true;
            Score += 25;
            Debug.Log(Score);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Game Over");
            renderer.material.SetColor("Color",Color.white);
            isGround = false;

        }
    }
    void Projectile()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rbody.AddForce(0, speed, speed, ForceMode.Impulse);
        }
    }
}

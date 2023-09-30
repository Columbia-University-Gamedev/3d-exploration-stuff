using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public float speed = 5;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * speed * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            MyFunction();
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            Duplicate();
        }
    }

    bool touchingGround = false;

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            touchingGround = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            touchingGround = false;
        }
    }

    public float jumpForce = 10f;
    void MyFunction()
    {
        if(touchingGround)
        {
            //rb.AddForce(Vector3.up * jumpForce, ForceMode.Force);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public GameObject spherePrefab;

    void Duplicate()
    {
        Instantiate(spherePrefab, transform.position + Vector3.up * 2, Quaternion.identity);
    }
}

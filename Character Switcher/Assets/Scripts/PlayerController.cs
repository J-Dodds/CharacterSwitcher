using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveForce = 10.0f;

    private Rigidbody rigBod;

	// Use this for initialization
	void Start ()
    {
        rigBod = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
	    if (Input.GetKey(KeyCode.W))
        {
            rigBod.AddForce(Vector3.forward * moveForce * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rigBod.AddForce(Vector3.back * moveForce * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigBod.AddForce(Vector3.left * moveForce * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigBod.AddForce(Vector3.right * moveForce * Time.deltaTime);
        }
	}
}

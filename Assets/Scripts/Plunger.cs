using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plunger : MonoBehaviour
{

	Rigidbody body;
	[SerializeField] [Range(1, 100000)] float force = 1;
	Vector3 startPos;
	private float maxMovement;
	[SerializeField][Range(1,20)] float offset;

	// Start is called before the first frame update
	void Start()
	{
		body = GetComponent<Rigidbody>();
		startPos = transform.position;
		maxMovement = startPos.z + offset;
		print(startPos);

	}

	// Update is called once per frame
	void Update()
	{
		ApplyTension();
		//print(body.position);
	}

	private void ApplyTension()
	{
		if(body.position.z > maxMovement)
		{
			//body.MovePosition(startPos);
			print("gone too far");
			return;
		}
		else
		{
			if (Input.GetKey(KeyCode.Space))
			{

				Vector3 total = Vector3.back * force * Time.deltaTime;
				body.AddRelativeForce(Vector3.forward * force * Time.deltaTime);
				//body.MovePosition(Vector3.forward * force * Time.deltaTime);

			}
		}
		


	}
}

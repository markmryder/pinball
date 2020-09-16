using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSwing : MonoBehaviour
{
	public float defaultAngle = 0f;
	public float activeAngle = -75;
	public float paddleStrength = 10000f;
	public float paddleDamper = 100f;
	[SerializeField] sides side;
	private enum sides { LEFT, RIGHT}

	private HingeJoint hinge;

	void Awake()
	{
		hinge = GetComponent<HingeJoint>();
		hinge.useSpring = true;
	}

	// Update is called once per frame
	void Update()
	{
		TriggePaddle();
	}

	private void TriggePaddle()
	{
		JointSpring spring = new JointSpring();
		spring.spring = paddleStrength;
		spring.damper = paddleDamper;

		if(side == sides.LEFT) 
		{
			if (Input.GetKey(KeyCode.A))
			{
				spring.targetPosition = activeAngle;
			}
			else
			{
				spring.targetPosition = defaultAngle;
			}
		}

		if(side == sides.RIGHT) 
		{
			if (Input.GetKey(KeyCode.D))
			{
				spring.targetPosition = activeAngle;
			}
			else
			{
				spring.targetPosition = defaultAngle;
			}
		}

		
		hinge.spring = spring;
		hinge.useLimits = true;
		JointLimits limits = hinge.limits;
		limits.min = defaultAngle;
		limits.max = activeAngle;
		hinge.limits = limits;
	}
}

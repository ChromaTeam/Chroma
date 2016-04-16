using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
	[SerializeField]
	private float m_Speed;

	[SerializeField]
	private float m_JumpSpeed;

	[SerializeField]
	private Rigidbody2D m_Rigidbody;

	private Vector2 m_Velocity;

	public void Jump()
	{
		m_Velocity.y = m_JumpSpeed;
		m_Rigidbody.velocity = m_Velocity;
	}

	public void Move(Vector2 axisValues)
	{
		//normalize vector if needed
		if (axisValues.magnitude > 1f)
		{
			axisValues.Normalize();
		}

		//only use x value to move 
		m_Velocity.x         = axisValues.x * m_Speed;
		m_Velocity.y         = m_Rigidbody.velocity.y;

		m_Rigidbody.velocity = m_Velocity;
	}
}

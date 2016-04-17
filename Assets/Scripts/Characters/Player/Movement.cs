using UnityEngine;
using System.Collections;

public class Movement : Skill 
{
	[SerializeField]
	private float m_Speed;

	[SerializeField]
	private Rigidbody2D m_Rigidbody;

	private Vector2 m_Velocity;

	public bool move;

	private void OnDisable()
	{
		//script disabled since we lost the power to move, reset velocity to zero
		m_Rigidbody.velocity = Vector2.zero;
	}

	public void Move(Vector2 axisValues)
	{
		if (!enabled)
		{
			return;
		}

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

using UnityEngine;
using System.Collections;

public class Jump : Skill 
{
	[SerializeField]
	private bool m_CanJump;

	[SerializeField]
	private float m_JumpSpeed;

	[SerializeField]
	private Rigidbody2D m_Rigidbody;

	private Vector2 m_Velocity;

	public void OnTerrainTriggerEnter(Collider2D trigger)
	{
		m_CanJump = true;
	}

	public void OnTerrainTriggerExit(Collider2D trigger)
	{
		m_CanJump = false;
	}

	public void DoJump()
	{		
		if (!m_CanJump || !enabled)
		{
			return;
		}

		m_Velocity.y = m_JumpSpeed;
		m_Rigidbody.velocity = m_Velocity;
	}
}

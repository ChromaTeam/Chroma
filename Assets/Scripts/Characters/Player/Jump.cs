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

	[SerializeField]
	private Animator m_Animator;

	public bool HasJumped
	{
		get
		{
			return m_HasJumped;
		}
	}
		
	private bool m_HasJumped;
	private bool m_PrevJump;

	private Vector2 m_Velocity;

	public void OnTerrainTriggerEnter(Collider2D trigger)
	{
		m_CanJump  = true;

		//if landed changed trigger animator
		if (m_HasJumped && (m_PrevJump != m_CanJump))
		{
			m_Animator.SetTrigger("Land");
			m_HasJumped = false;
		}

		m_PrevJump = m_CanJump;
	}

	public void OnTerrainTriggerExit(Collider2D trigger)
	{
		m_CanJump  = false;
		m_PrevJump = m_CanJump;
	}

	public void DoJump()
	{		
		if (!enabled || !m_CanJump)
		{
			return;
		}

		m_HasJumped = true;
		ForceJump();
	}

	public void ForceJump()
	{
		m_Velocity.y = m_JumpSpeed;
		m_Rigidbody.velocity = m_Velocity;

		m_Animator.SetTrigger("Jump");
	}
}

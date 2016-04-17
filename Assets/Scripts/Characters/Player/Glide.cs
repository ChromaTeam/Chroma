using UnityEngine;
using System.Collections;

public class Glide : Skill 
{
	[SerializeField]
	private float m_Speed;

	[SerializeField]
	private Rigidbody2D m_Rigidbody;

	[SerializeField]
	private Jump m_Jump;

	private bool m_IsFalling;
	private bool m_IsButtonDown;
	private bool m_IsGliding;
	private bool m_HasGlided;

	private float m_PrevYVelocity;

	private Vector2 m_Velocity;

	public void Update()
	{
		if (m_IsGliding)
		{
			SetVelocity(m_Rigidbody.velocity.x, m_Speed);
			return;
		}

		bool isDescreasing = m_Rigidbody.velocity.y < 0 && Mathf.Abs(m_Rigidbody.velocity.y - m_PrevYVelocity) > 0;
		m_IsFalling = m_Jump.HasJumped && isDescreasing;

		m_PrevYVelocity = m_Rigidbody.velocity.y;

		DoGlide();
	}

	private void OnDisable()
	{
		GlideButtonUp();
	}

	public void OnTerrainTriggerEnter(Collider2D trigger)
	{
		ResetGlided();
	}

	public void GlideButtonDown()
	{
		m_IsButtonDown = true;
	}

	public void GlideButtonUp()
	{
		m_IsButtonDown = false;	
		m_IsGliding    = false;

		m_PrevYVelocity = m_Rigidbody.velocity.y;
	}

	public void DoGlide() 
	{
		if (!enabled || m_HasGlided || !m_IsButtonDown || !m_IsFalling)
		{
			return;
		}
	
		m_IsGliding = true;
		m_HasGlided = true;

		m_IsFalling = false;
	}

	public void ResetGlided()
	{
		m_HasGlided = false;
	}

	private void SetVelocity(float x, float y)
	{
		m_Velocity.x = x;
		m_Velocity.y = y;

		m_Rigidbody.velocity = m_Velocity;
	}
}

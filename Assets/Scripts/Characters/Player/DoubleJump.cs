using UnityEngine;
using System.Collections;

public class DoubleJump : Skill 
{
	[SerializeField]
	private bool m_AllowGliding;

	[SerializeField]
	private Jump m_Jump;

	[SerializeField]
	private Glide m_Glide;

	private bool m_HasJumped;

	public void OnTerrainTriggerEnter(Collider2D trigger)
	{
		m_HasJumped = false;
	}

	public void DoJump()
	{
		//only do a double jump if we already jumped
		if (!enabled || !m_Jump.HasJumped || m_HasJumped)
		{
			return;
		}

		m_HasJumped = true;

		//do another jump
		m_Jump.ForceJump();

		//if allowed reset gliding state so we can glide again after second jump
		if (m_AllowGliding)
		{
			m_Glide.ResetGlided();
		}
	}
}

using UnityEngine;
using System.Collections;

public class Shield : Skill 
{
	[SerializeField]
	public float m_Delay;

	[SerializeField]
	private Player m_Player;

	[SerializeField]
	private Animator m_Animator;

	private bool m_IsActive;

	private float m_DelayCounter;

	public void Update()
	{
		if (m_IsActive && Time.time - m_DelayCounter > m_Delay)
		{
			ShieldButtonUp();
		}
	}

	public void ShieldButtonDown()
	{
		if (!enabled)
		{
			return;
		}

		m_IsActive = true;
		m_Player.SetInvulnerable(m_IsActive);

		m_DelayCounter = Time.time;

		m_Animator.SetTrigger("Shield_On");
        Debug.Log("Shield on");
	}

	public void ShieldButtonUp()
	{
		if (!enabled)
		{
			return;
		}

		if (m_IsActive)
		{
			m_Animator.SetTrigger("Shield_Off");
		}

		m_IsActive = false;
		m_Player.SetInvulnerable(m_IsActive);

	}
}

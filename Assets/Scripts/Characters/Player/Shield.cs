using UnityEngine;
using System.Collections;

public class Shield : Skill 
{
	[SerializeField]
	public float m_Delay;

	[SerializeField]
	private Player m_Player;

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
	}

	public void ShieldButtonUp()
	{
		if (!enabled)
		{
			return;
		}

		m_IsActive = false;
		m_Player.SetInvulnerable(m_IsActive);
	}
}

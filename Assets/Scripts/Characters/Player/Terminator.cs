using UnityEngine;
using System.Collections;

public class Terminator : Skill 
{
	[SerializeField]
	private PlayerShoot m_Player;

	[SerializeField]
	private Animator m_Animator;

	public void TerminatorButtonDown()
	{
		if (!enabled)
		{
			return;
		}

		m_Player.SetTerminator(true);
	}

	public void TerminatorButtonUp()
	{
		if (!enabled)
		{
			return;
		}

		m_Player.SetTerminator(false);
	}
}

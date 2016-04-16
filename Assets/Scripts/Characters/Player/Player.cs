using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	[SerializeField]
	private Skill[] m_Skills;

	private int m_activeSkillCounter = -1;

	public void GainSkill()
	{
		m_activeSkillCounter = Mathf.Min(m_Skills.Length - 1, m_activeSkillCounter + 1);
		SetSkill(true, m_activeSkillCounter);
	}

	public void LoseSkill()
	{
		if (m_activeSkillCounter == -1)
		{
			return;
		}

		SetSkill(false, m_activeSkillCounter);
		m_activeSkillCounter = Mathf.Max(-1, m_activeSkillCounter - 1);
	}

	private void SetSkill(bool isEnabled, int counter)
	{
		m_Skills[m_activeSkillCounter].enabled = isEnabled;
	}
}

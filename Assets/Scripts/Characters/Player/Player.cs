using UnityEngine;
using UnityEngine.Audio;

using System.Collections;

public class Player : MonoBehaviour 
{
	[SerializeField]
	private Skill[] m_Skills;

	[SerializeField]
	private SetParameter[] m_MusicParameters;

	private int m_activeSkillCounter = -1;

    //Timer between each hit the player receive by staying close to an ennemy
    private int hitTimer = 0;

    void Update()
    {
        hitTimer++;
    }


    public void GainSkill()
	{
		m_activeSkillCounter = Mathf.Min(m_Skills.Length - 1, m_activeSkillCounter + 1);
		SetSkill(true, m_activeSkillCounter);

		m_MusicParameters[m_activeSkillCounter].Play();
	}

	public void LoseSkill()
	{
		if (m_activeSkillCounter == -1)
		{
			return;
		}

		SetSkill(false, m_activeSkillCounter);
		m_MusicParameters[m_activeSkillCounter].Rewind();

		m_activeSkillCounter = Mathf.Max(-1, m_activeSkillCounter - 1);
	}

	private void SetSkill(bool isEnabled, int counter)
	{
		m_Skills[m_activeSkillCounter].enabled = isEnabled;
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Orbe")
        {
            Debug.Log("Just found a new color orbe");
            GainSkill();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Ennemy hit !!!");
            if (hitTimer > 50)
            {
                Debug.Log("Ennemy and stayed enough to be hit !");
                LoseSkill();
                hitTimer = 0;
            }

        }
    }
}

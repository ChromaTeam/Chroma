using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

using System.Collections.Generic;

public class Player : MonoBehaviour 
{
	[SerializeField]
	private float m_AttractSpeed;

	[SerializeField]
	private Transform m_OrbSpawnPosition;

	[SerializeField]
	private List<Orb> m_Orbs;

	[SerializeField]
	private UnityEvent OnHit;

	private int m_activeSkillCounter = -1;

	private bool m_IsInvulnerable;

    //Timer between each hit the player receive by staying close to an ennemy
    private int hitTimer = 0;

    void Update()
    {
        hitTimer++;
    }
		
	public void Attract()
	{		
		int attractOrbIndex = m_activeSkillCounter + 1;
		if (attractOrbIndex == m_Orbs.Count)
		{
			return;
		}

		m_Orbs[attractOrbIndex].AttractTo(m_AttractSpeed, transform.position);
	}

	public void StopAttracting()
	{
		int attractOrbIndex = m_activeSkillCounter + 1;
		if (attractOrbIndex == m_Orbs.Count)
		{
			return;
		}

		m_Orbs[attractOrbIndex].StopAttracting();
	}
		
    public void GainSkill()
	{
		m_activeSkillCounter = Mathf.Min(m_Orbs.Count - 1, m_activeSkillCounter + 1);
		SetSkill(true, m_activeSkillCounter);
	}

	public void LoseSkill()
	{
		if (m_activeSkillCounter == -1)
		{
			return;
		}

		SetSkill(false, m_activeSkillCounter);
		m_Orbs[m_activeSkillCounter].Spawned(m_OrbSpawnPosition.position);

		m_activeSkillCounter = Mathf.Max(-1, m_activeSkillCounter - 1);
	}

	public void SetInvulnerable(bool isInvulnerable)
	{
		m_IsInvulnerable = isInvulnerable;
	}

	private void SetSkill(bool isEnabled, int counter)
	{
		m_Orbs[m_activeSkillCounter].EnableSkill(isEnabled);
	}

	private void Hit()
	{
		if (!m_IsInvulnerable)
		{
			LoseSkill();
		}

		m_IsInvulnerable = false;

		OnHit.Invoke();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Orbe")
        {
            Debug.Log("Just found a new color orbe");
            GainSkill();
            
			//hit an orb
			Orb orb = other.gameObject.GetComponent<Orb>();
			if (orb != null)
			{				
				orb.Collected();
			}
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
				Hit();
                hitTimer = 0;
            }
        }
    }
}

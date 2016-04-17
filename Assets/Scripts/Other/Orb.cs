using UnityEngine;
using System.Collections;

public class Orb : MonoBehaviour 
{
	[SerializeField]
	private Skill m_Skill;

	[SerializeField]
	private SetParameter m_MusicParameter;

	private bool m_IsAttracting;

	private float m_Speed;

	private Vector3 m_Direction;

	private void Update()
	{
		if (m_IsAttracting)
		{
			Move();	
		}
	}

	public void EnableSkill(bool isEnabled)
	{
		m_Skill.enabled = isEnabled;

		if (isEnabled)
		{
			m_MusicParameter.Play();
		}
		else
		{
			m_MusicParameter.Rewind();
		}
	}

	public void AttractTo(float speed, Vector3 position)
	{
		m_Direction = position - transform.position;
		if (m_Direction.magnitude > 1f)
		{
			m_Direction.Normalize();
		}

		m_Speed        = speed;
		m_IsAttracting = true;
	}

	public void StopAttracting()
	{
		m_IsAttracting = false;

		m_Speed     = 0f;
		m_Direction = Vector3.zero;
	}

	public void Collected()
	{
		StopAttracting();
		gameObject.SetActive(false);
	}

	//spawn the orb around the player after getting hit
	public void Spawned(Vector3 orbSpawnPosition)
	{
		//set orb position to spawn position
		transform.position = orbSpawnPosition;

		gameObject.SetActive(true);
	}

	private void Move()
	{
		transform.Translate(m_Direction * m_Speed * Time.deltaTime);
	}
}

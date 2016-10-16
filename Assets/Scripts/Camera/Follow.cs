using UnityEngine;
using System.Collections;
using System;

public class Follow : MonoBehaviour 
{
	[SerializeField]
	private float m_Speed_x;
	
	[SerializeField]
	private float m_Speed_y;

	[SerializeField]
	private Transform m_Target;

	private Vector3 m_Position;
	
	private Vector2 m_Delta = Vector2.one;

	void Update() 
	{
		//only get x coordinate of target
		m_Position.x = m_Target.position.x + Math.Sign(m_Delta.x) * 3.2f;
		m_Position.y = m_Target.position.y + 1.75f;
		m_Position.z = transform.position.z;
		
		m_Delta = new Vector2(m_Position.x - transform.position.x, m_Position.y - transform.position.y);

		transform.position += new Vector3(m_Speed_x * (m_Position.x - transform.position.x), m_Speed_y * (m_Position.y - transform.position.y),0);
	}
}

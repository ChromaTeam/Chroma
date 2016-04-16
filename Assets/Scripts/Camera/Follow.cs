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

	void Update() 
	{
		//only get x coordinate of target
		m_Position.x = m_Target.position.x + 3;
		m_Position.y = m_Target.position.y + 2;
		m_Position.z = transform.position.z;

		transform.position += new Vector3(m_Speed_x * (m_Position.x - transform.position.x), m_Speed_y * (m_Position.y - transform.position.y),0);
	}
}

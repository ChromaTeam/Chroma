using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour 
{
	[SerializeField]
	private float m_Speed;

	[SerializeField]
	private Transform m_Target;

	private Vector3 m_Position;

	void Update() 
	{
		//only get x coordinate of target
		m_Position.x = m_Target.position.x;
		m_Position.y = transform.position.y;
		m_Position.z = transform.position.z;

		transform.position = Vector3.Lerp(transform.position, m_Position, m_Speed * Time.deltaTime);
	}
}

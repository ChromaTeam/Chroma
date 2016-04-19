using UnityEngine;
using System.Collections;

public class DisplayPlayer : MonoBehaviour 
{
	[SerializeField]
	private InputController m_PlayerInput;

	[SerializeField]
	private SpriteRenderer[] m_PlayerRenderers;

	public void Display()
	{
		foreach (var renderer in m_PlayerRenderers)
		{
			renderer.enabled = true;			
		}

		m_PlayerInput.enabled = true;
	}
}

using UnityEngine;
using System.Collections;

public class BossMusic : MonoBehaviour 
{
	[SerializeField]
	private AudioSource m_AudioSource;

	[SerializeField]
	private SetParameter m_MusicParameter;

	public void OnPlayerTriggerEnter2D(Collider2D other)
	{
		if (other.tag.Equals("Player"))
		{
			Play();
		}
	}

	private void Play()
	{
		m_AudioSource.Play();
		m_MusicParameter.Play();
	}
}

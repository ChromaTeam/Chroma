using UnityEngine;
using UnityEngine.Audio;

using System.Collections;

public class SetParameter : MonoBehaviour 
{
	[SerializeField]
	private float m_Speed;

	[SerializeField]
	private Vector2 m_Values; //0 - min value, 1 - max value

	[SerializeField]
	private string m_ParameterName;

	[SerializeField]
	private AnimationCurve m_Curve;

	[SerializeField]
	private AudioMixer m_Mixer;

	private float m_Step;
	private float m_Dir = 1f; //direction of change

	private void Update()
	{
		float curveValue = m_Curve.Evaluate(m_Step);
		curveValue = m_Values.x + curveValue * (m_Values.y - m_Values.x);
			
		m_Mixer.SetFloat(m_ParameterName, curveValue);

		//if end is reached stop updating
		bool isForward = m_Dir == 1f;

		float end = isForward ? 1f : 0f;
		if (m_Step == end)
		{
			enabled = false;
		}

		m_Step = m_Step + m_Dir * m_Speed * Time.deltaTime;
		m_Step = isForward ? Mathf.Min(1f, m_Step) : Mathf.Max(0f, m_Step);
	}

	public void Play()
	{
		//if playing do not reset step
		if (!enabled)
		{
			m_Step  = 0;
		}

		m_Dir   = 1;
		enabled = true;
	}

	public void Rewind()
	{
		//if playing do not reset step
		if (!enabled)
		{
			m_Step  = 1;
		}

		m_Dir   = -1;
		enabled = true;
	}
}

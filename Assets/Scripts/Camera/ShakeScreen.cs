using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class ShakeScreen : MonoBehaviour {
	
	public int times;
	private int m_timesShaken;
	public Animator shakeCamera;
	public UnityEvent OnNext;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Shake () {
		m_timesShaken++;
		
		shakeCamera.SetTrigger("ShakeIt");
		
		if(m_timesShaken >= times) {
			m_timesShaken = 0;
			OnNext.Invoke();
		}
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowText : MonoBehaviour {

	private float m_deltaTime;
	private bool m_writingText;
	private int m_writtenTextLength;
	public Text textUI;
	
	public string text;
	
	public float speed;

	// Use this for initialization
	void Start () {
		m_deltaTime = 0.0f;
		
		m_writingText = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(m_writingText) {
			if(m_deltaTime < 1/speed)
				m_deltaTime += Time.deltaTime;
			else {
				m_deltaTime = 0;
				m_writtenTextLength++;
				
				textUI.text = text.Substring(0, m_writtenTextLength);
				
				if(m_writtenTextLength == text.Length) {
					m_writingText = false;
				}
			}
		}
		else {
			m_writtenTextLength = 0;
		}
	}
	
	public void Play () {
		m_writingText = true;
	}
}

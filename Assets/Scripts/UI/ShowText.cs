using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowText : MonoBehaviour {

	private float m_deltaTime;
	private bool m_writingText;
	private int m_writtenTextLength;
	public Text textUI;
	
	[TextArea(3,10)]
	public string text;
	
	public float speed;

	// Use this for initialization
	void Start () {
		m_deltaTime = 0.0f;
		
		m_writingText = true;
	}
	
	void OnEnable() {
		Play();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(m_writingText) {
			if(m_deltaTime < 1/speed)
				m_deltaTime += Time.deltaTime;
			else {
				m_deltaTime = 0;
				m_writtenTextLength++;
				
				textUI.text = text.Substring(0, m_writtenTextLength);
				
				if(text[m_writtenTextLength - 1] == '.') {
					m_deltaTime -= 1f;
				}
				else if(text[m_writtenTextLength - 1] == '\n') {
					m_deltaTime -= 2;
				}
				
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

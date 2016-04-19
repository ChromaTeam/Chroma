using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowText : MonoBehaviour {

	private float m_deltaTime;
	private float m_pauseDeltaTime;
	private float m_pauseTime;
	private bool m_writingText;
	private int m_writtenTextLength;
	public Text textUI;
	public Button ButtonUI;
	
	[TextArea(3,10)]
	public string text;
	
	public float speed;

	// Use this for initialization
	void Start () {
		m_deltaTime = 0.0f;
		m_pauseDeltaTime = 0.0f;
		m_pauseTime = 0.0f;
		m_writtenTextLength = 0;
		
		m_writingText = true;
		
		ButtonUI.gameObject.SetActive(false);
	}
	
	void OnEnable() {
		Play();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(m_writingText) {
			if(m_pauseTime > 0) {
				if(m_pauseTime > m_pauseDeltaTime) {
					m_pauseDeltaTime += Time.deltaTime;
				}
				else {
					m_pauseDeltaTime = 0.0f;
					m_pauseTime = 0.0f;
				}
			}
			else {
				m_deltaTime += Time.deltaTime;
				m_writtenTextLength = (int) (m_deltaTime * speed);
				
				if(m_writtenTextLength > text.Length)
					m_writtenTextLength = text.Length;
				
				if(m_writtenTextLength > textUI.text.Length) {
					textUI.text = text.Substring(0, m_writtenTextLength);
					
					if(text[m_writtenTextLength - 1] == '.') {
						m_pauseTime = 0.5f;
					}
					else if(text[m_writtenTextLength - 1] == '\n') {
						m_pauseTime = 1f;
					}
					
					if(m_writtenTextLength == text.Length) {
						m_writingText = false;
			
						ButtonUI.gameObject.SetActive(true);
					}
				}
			}
		}
	}
	
	public void Play () {
		m_writingText = true;
		m_deltaTime = 0.0f;
		m_pauseDeltaTime = 0.0f;
		m_pauseTime = 0.0f;
		m_writtenTextLength = 0;
		
		ButtonUI.gameObject.SetActive(false);
	}
}

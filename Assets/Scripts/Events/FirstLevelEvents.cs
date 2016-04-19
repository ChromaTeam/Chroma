using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FirstLevelEvents : MonoBehaviour {
	
	public GameObject Narration1;
	public GameObject Narration2;
	public GameObject Narration3;
	public GameObject Narration4;

	public Animator StatueAnimator;
	public GameObject Music;
	
	void Start() {
		OnNarration1();
	}

	public void OnNarration1 () {
		//Player.SetActive(false);
		Narration1.SetActive(true);
		
		/*ShowText showTextNarration1 = Narration1.GetComponent<ShowText>();
		
		if(showTextNarration1)
			showTextNarration1.Play();*/
	}
	
	public void OnNarration2 () {
		ShowText showTextNarration2 = Narration2.GetComponent<ShowText>();
		
		Narration1.SetActive(false);
		Narration2.SetActive(true);
		
		if(showTextNarration2)
			showTextNarration2.Play();
	}
	
	public void OnNarration3 () {
		ShowText showTextNarration3 = Narration3.GetComponent<ShowText>();
		
		Narration2.SetActive(false);
		Narration3.SetActive(true);
		
		if(showTextNarration3)
			showTextNarration3.Play();
		else
		{
			Debug.Log("No ShowText");
		}
	}
	
	public void OnNarration4 () {
		ShowText showTextNarration4 = Narration4.GetComponent<ShowText>();
		
		Narration3.SetActive(false);
		Narration4.SetActive(true);
		
		if(showTextNarration4)
			showTextNarration4.Play();
	}
	
	public void OnPlay () {
		Narration4.SetActive(false);

		StatueAnimator.enabled = true;
		Music.SetActive(true);
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FirstLevelEvents : MonoBehaviour {
	
	public GameObject Narration1;
	public GameObject Narration2;
	public GameObject Narration3;
	public GameObject Narration4;
	public GameObject Narration5;
	public GameObject SkipButton;

	public Animator StatueAnimator;
	public Animator ShakeCamera;
	public GameObject Music;
	public Follow CameraFollow;
	
	void Start() {
		OnNarration1();
	}

	public void OnNarration1 () {
		//Player.SetActive(false);
		Narration1.SetActive(true);
		Narration2.SetActive(false);
		Narration3.SetActive(false);
		Narration4.SetActive(false);
		Narration5.SetActive(false);
		SkipButton.SetActive(true);
		
		/*ShowText showTextNarration1 = Narration1.GetComponent<ShowText>();
		
		if(showTextNarration1)
			showTextNarration1.Play();*/
	}
	
	public void OnNarration2 () {
		ShowText showTextNarration2 = Narration2.GetComponent<ShowText>();
		
		Narration1.SetActive(false);
		Narration2.SetActive(true);
		Narration3.SetActive(false);
		Narration4.SetActive(false);
		Narration5.SetActive(false);
		SkipButton.SetActive(true);
		
		if(showTextNarration2)
			showTextNarration2.Play();
	}
	
	public void OnNarration3 () {
		ShowText showTextNarration3 = Narration3.GetComponent<ShowText>();
		
		Narration1.SetActive(false);
		Narration2.SetActive(false);
		Narration3.SetActive(true);
		Narration4.SetActive(false);
		Narration5.SetActive(false);
		SkipButton.SetActive(true);
		
		if(showTextNarration3)
			showTextNarration3.Play();
		else
		{
			Debug.Log("No ShowText");
		}
	}
	
	public void OnNarration4 () {
		ShowText showTextNarration4 = Narration4.GetComponent<ShowText>();
		
		Narration1.SetActive(false);
		Narration2.SetActive(false);
		Narration3.SetActive(false);
		Narration4.SetActive(true);
		Narration5.SetActive(false);
		SkipButton.SetActive(true);
		
		if(showTextNarration4)
			showTextNarration4.Play();
	}
	
	public void OnNarration5 () {
		ShowText showTextNarration5 = Narration5.GetComponent<ShowText>();
		
		Narration1.SetActive(false);
		Narration2.SetActive(false);
		Narration3.SetActive(false);
		Narration4.SetActive(false);
		Narration5.SetActive(false);
		SkipButton.SetActive(false);

		StatueAnimator.enabled = true;
		Music.SetActive(true);
			
		ShakeCamera.SetTrigger("ColorsOut");
		
		CameraFollow.enabled = true;
		
		StartCoroutine (LateNarration());
	}
	
	public IEnumerator LateNarration() {
		ShowText showTextNarration5 = Narration5.GetComponent<ShowText>();
		
		yield return new WaitForSeconds(3);
		
		Narration5.SetActive(true);
		
		if(showTextNarration5)
			showTextNarration5.Play();
		
	}
	
	public void OnPlay () {
		Narration1.SetActive(false);
		Narration2.SetActive(false);
		Narration3.SetActive(false);
		Narration4.SetActive(false);
		Narration5.SetActive(false);
		SkipButton.SetActive(false);
	}
}

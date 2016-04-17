using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuEvents : MonoBehaviour {

	public void OnPlay () {
		SceneManager.LoadScene("1stLevel_Mehdi");
	}
	
	public void OnCredits () {
		SceneManager.LoadScene("Credits");
	}
}

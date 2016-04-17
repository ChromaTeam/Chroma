using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreditsEvents : MonoBehaviour {

	public void OnBack () {
		SceneManager.LoadScene("Menu");
	}
}

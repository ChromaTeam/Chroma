using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverEvents : MonoBehaviour {

	public void OnBack () {
		SceneManager.LoadScene("Menu");
	}
}

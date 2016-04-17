using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

    public GameObject player;
    public int bossLives = 1000;

    // Use this for initialization
    void Start () {
        Debug.Log("Boss ready");
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

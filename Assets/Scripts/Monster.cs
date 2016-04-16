using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

    public GameObject player;
    public float distanceToPlayer;

	// Use this for initialization
	void Start () {
        Debug.Log("monster ready");
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log(distanceToPlayer);
        if (distanceToPlayer < 10)
        {
            //monster move to player position
        }
        else
        {
            //monster return to original position
        }
    }
}
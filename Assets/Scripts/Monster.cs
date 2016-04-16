using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

    public GameObject player;
    public float distanceToPlayer;
    private Vector3 v_diff;
    private float atan2;

    // Use this for initialization
    void Start () {
        Debug.Log("monster ready");
        player = GameObject.Find("Player");
        
}
	
	// Update is called once per frame
	void Update () {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log(distanceToPlayer);
        v_diff = (player.transform.position - transform.position);
        atan2 = Mathf.Atan2(v_diff.y, v_diff.x);
        transform.rotation = Quaternion.Euler(0f, 0f, atan2 * Mathf.Rad2Deg);
        if (distanceToPlayer < 10)
        {
            //monster move to player position
            transform.Translate(1*Time.deltaTime, 0, 0);
        }
        else
        {
            //monster return to original position
        }
    }
}
using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

    public GameObject player;
    public GameObject anchor;
    public float distanceToPlayer;
    public float distanceToAnchor;
    private Vector3 v_diff;
    private Vector3 anchorDiff;
    private float atanPlayer;
    private float atanAnchor;

    public Quaternion rotation = Quaternion.identity;

    public Quaternion anchorRotation;

    // Use this for initialization
    void Start () {
        Debug.Log("monster ready");
        player = GameObject.Find("Player");
}
	
	// Update is called once per frame
	void Update () {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        distanceToAnchor = Vector3.Distance(transform.position, anchor.transform.position);
        v_diff = (player.transform.position - transform.position);
        anchorDiff = (anchor.transform.position - transform.position);
        atanPlayer = Mathf.Atan2(v_diff.y, v_diff.x);
        atanAnchor = Mathf.Atan2(anchorDiff.y, anchorDiff.x);
        if (distanceToPlayer < 10 && distanceToPlayer > 2)
        {
            //monster move to player position
            transform.rotation = Quaternion.Euler(0f, 0f, atanPlayer * Mathf.Rad2Deg);
            transform.Translate(2*Time.deltaTime, 0, 0);
        }
        
        else if (distanceToAnchor > 2)
        {
            //monster return to original position
            anchorRotation = Quaternion.Euler(0f, 0f, atanAnchor * Mathf.Rad2Deg);
            if (anchorRotation.z < 0)
            {
                rotation.eulerAngles = new Vector3(0, 180, 0);
                transform.rotation = rotation;
                Debug.Log("droite");
            }
            else
            {
                rotation.eulerAngles = new Vector3(0, -180, 0);
                transform.rotation = rotation;
                Debug.Log("gauche");
            }
            
            transform.Translate(2 * Time.deltaTime, 0, 0);
            
        }
    }
}
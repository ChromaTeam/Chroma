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
    private float direction;

    public Quaternion rotation = Quaternion.identity;

    public Quaternion anchorRotation;

    // Use this for initialization
    void Start () {
        Debug.Log("Classic monster ready");
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
            direction = transform.position.x - player.transform.position.x;
            if (direction > 0)
            {
                rotation.eulerAngles = new Vector3(0, 180, 0);
                transform.rotation = rotation;
            }
            else
            {
                rotation.eulerAngles = new Vector3(0, 0, 0);
                transform.rotation = rotation;
            }

            transform.Translate(4 * Time.deltaTime, 0, 0);
        }
        
        else if (distanceToAnchor > 2)
        {
            direction = transform.position.x - anchor.transform.position.x;
            //monster return to original position
            //anchorRotation = Quaternion.Euler(0f, 0f, atanAnchor * Mathf.Rad2Deg);
            //Debug.Log(anchorRotation.eulerAngles.z);
            if (direction > 0 )
            {
                rotation.eulerAngles = new Vector3(0, 180, 0);
                transform.rotation = rotation;
            }
            else
            {
                rotation.eulerAngles = new Vector3(0, 0, 0);
                transform.rotation = rotation;
            }
            
            transform.Translate(2 * Time.deltaTime, 0, 0);
            
        }
    }
}
using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class Monster : MonoBehaviour {

    public GameObject player;
    public GameObject anchor;
    public float distanceToPlayer;
    public float distanceToAnchor;
    //private Vector3 v_diff;
    //private Vector3 anchorDiff;
    //private float atanPlayer;
    //private float atanAnchor;
    private float direction;

    public Quaternion rotation = Quaternion.identity;

    public Quaternion anchorRotation;

    //audio:
    public AudioClip normalAudio;
    public AudioClip attackAudio;
    public AudioSource source;


    // Use this for initialization
    void Start () {
        Debug.Log("Classic monster ready");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update () {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        distanceToAnchor = Vector3.Distance(transform.position, anchor.transform.position);
        //v_diff = (player.transform.position - transform.position);
        //anchorDiff = (anchor.transform.position - transform.position);
        //atanPlayer = Mathf.Atan2(v_diff.y, v_diff.x);
        //atanAnchor = Mathf.Atan2(anchorDiff.y, anchorDiff.x);

        //Si le monstre n'est pas loin du joueur il se dirige vers lui et lance un son / musique d'attaque
        if (distanceToPlayer < 10 && distanceToPlayer > 2)
        {
            source.clip = attackAudio;
            if (!source.isPlaying)
            {
                source.Play();
            }
            

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
        //Si le monstre n'est pas loin de son ancre il s'arrete et relance son bruitage de base
        else if (distanceToAnchor > 2)
        {
            source.clip = normalAudio;
            if (!source.isPlaying)
            {
                source.Play();
            }

            direction = transform.position.x - anchor.transform.position.x;
            //monster return to original position
            //anchorRotation = Quaternion.Euler(0f, 0.f, atanAnchor * Mathf.Rad2Deg);
            //Debug.Log(anchorRotation.eulerAngles.z);
            if (direction > 1 )
            {
                rotation.eulerAngles = new Vector3(0, 180, 0);
                transform.rotation = rotation;
            }
            else if(direction < 1)
            {
                rotation.eulerAngles = new Vector3(0, 0, 0);
                transform.rotation = rotation;
            }
            
            transform.Translate(2 * Time.deltaTime, 0, 0);
            
        }
    }
}
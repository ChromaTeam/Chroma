using UnityEngine;
using System.Collections;

public class MonsterShoot : MonoBehaviour {

    public GameObject player;
    public float distanceToPlayer;
    //private Vector3 v_diff;
    //private float atanPlayer;
    private float direction;
    //private float blastDirection;

    private Vector2 shootDirection;

    public Quaternion rotation = Quaternion.identity;

    public float propulsionForce = 2f;

    public GameObject shootPrefab;

    //Cadence de tir
    private int timer = 0;

    //audio:
    public AudioClip normalAudio;
    public AudioClip attackAudio;
    public AudioSource source;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Shoot monster ready");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        //v_diff = (player.transform.position - transform.position);
        //atanPlayer = Mathf.Atan2(v_diff.y, v_diff.x);

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
                //blastDirection = -1;
            }
            else
            {
                rotation.eulerAngles = new Vector3(0, 0, 0);
                transform.rotation = rotation;
                //blastDirection = 1;
            }
            timer++;
            if (timer > 100)
            {
                timer = 0;
                Throw();
            }
        }

        else
        {
            //Default animation
            source.clip = normalAudio;
            if (!source.isPlaying)
            {
                source.Play();
            }
        }
    }

    void Throw()
    {
        GameObject go = (GameObject)Instantiate(shootPrefab, transform.TransformPoint(3f, 0, 0), transform.rotation);
        shootDirection = player.transform.position - transform.position;
        go.GetComponent<Rigidbody2D>().AddForce(shootDirection * propulsionForce, ForceMode2D.Impulse);
        Destroy(go, 10);
    }
}
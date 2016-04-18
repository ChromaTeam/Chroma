using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

    private GameObject player;
    public int bossLives = 1000;
    private float direction;
    public Quaternion rotation = Quaternion.identity;

    // Use this for initialization
    void Start () {
        Debug.Log("Boss ready");
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        direction = transform.position.x - player.transform.position.x;
        if (direction < 0)
        {
            rotation.eulerAngles = new Vector3(0, 180, 0);
            transform.rotation = rotation;
        }
        else
        {
            rotation.eulerAngles = new Vector3(0, 0, 0);
            transform.rotation = rotation;
        }

        if (bossLives < 1)
        {
            Destroy(gameObject);
            Application.LoadLevel("Menu");
            //SceneManager.LoadScene("Menu");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Shoot")
        {
            Debug.Log("Boss has been hit");
            bossLives = bossLives - 50;
        }

    }
}

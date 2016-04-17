using UnityEngine;
using System.Collections;

public class BossArm : MonoBehaviour {

    public bool attack1 = true;
    public bool attack2 = false;
    public bool attack3 = false;
    private int timer = 0;
    private GameObject player;
    public GameObject rock;
    private GameObject scene;

    private bool invoked = false;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        scene = GameObject.Find("Scene");
    }
	
	// Update is called once per frame
	void Update () {
        if (attack1)
        {
            if (timer < 15)
            {
                HorizontalAttack(10, 2);
                timer++;
            }
            else if ( timer < 20)
            {
                HorizontalAttack(-30, -6);
                timer++;
            }
            else if (timer < 66.5f)
            {
                HorizontalAttack(-30, 0);
                timer++;
            }
            else if (timer < 160)
            {
                HorizontalAttack(15, 0);
                timer++;
            }
            else
            {
                timer = 0;
                attack1 = false;
                attack2 = true;
            }
        }else if (attack2)
        {
            if (timer < 40)
            {
                HammerAttack(1,25);
                timer++;
            }
            else if (timer < 60)
            {
                HammerAttack(-49,-49);
                timer++;
            }
            else if (timer < 100)
            {
                HammerAttack(25, 0);
                timer++;
            }
            else
            {
                timer = 0;
                attack2 = false;
                attack3 = true;
            }
        }
        else if (attack3)
        {
            if (!invoked)
            {
                InvokeAttack();
                invoked = true;
            }
            if(timer > 300)
            {
                timer = 0;
                attack3 = false;
                attack1 = true;
            }
            else
            {
                timer++;
            }
            
        }


    }

    public void HorizontalAttack(int direction, int hauteur)
    {
        Debug.Log("boss attack 1");
        transform.Translate(direction * Time.deltaTime, hauteur * Time.deltaTime, 0);
    }
    public void HammerAttack(int direction, int hauteur)
    {
        Debug.Log("boss attack 2");
        transform.Translate(direction * Time.deltaTime, hauteur * Time.deltaTime, 0);
    }
    public void InvokeAttack()
    {
        Debug.Log("boss attack 3");
        GameObject childObject = Instantiate(rock, new Vector3(player.transform.position.x, 20, 0), Quaternion.identity) as GameObject;
        childObject.transform.parent = scene.transform;
    }
}
;
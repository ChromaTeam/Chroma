using UnityEngine;
using System.Collections;

public class BossArm : MonoBehaviour {

    //coup de poing rapide
    public bool attack1 = true;
    //coup de poing marteau
    public bool attack2 = false;
    //fausse attaque
    public bool attack3 = false;
    //chute de pierre
    public bool attack4 = false;
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
                transform.localPosition = new Vector3(0, -1, 0);
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
                HammerAttack(-49,-51);
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
                transform.localPosition = new Vector3(0, -1, 0);
            }
        }
        else if (attack3)
        {
            if (timer < 40)
            {
                HammerAttack(1, 6.5f);
                timer++;
            }
            else if (timer < 45)
            {
                HammerAttack(-49, -51);
                timer++;
            }
            else if (timer < 100)
            {
                HammerAttack(2.5f, 0);
                timer++;
            }
            else
            {
                timer = 0;
                attack3 = false;
                attack4 = true;
                transform.localPosition = new Vector3(0, -1, 0);
            }
        }
        else if (attack4)
        {
            if (!invoked)
            {
                InvokeAttack();
                invoked = true;
            }
            if(timer > 300)
            {
                timer = 0;
                attack4 = false;
                attack1 = true;
                invoked = false;
                transform.localPosition = new Vector3(0, -1, 0);
            }
            else
            {
                timer++;
            }
            
        }


    }

    public void HorizontalAttack(float direction, float hauteur)
    {
        Debug.Log("boss attack 1");
        transform.Translate(direction * Time.deltaTime, hauteur * Time.deltaTime, 0);
    }
    public void HammerAttack(float direction, float hauteur)
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
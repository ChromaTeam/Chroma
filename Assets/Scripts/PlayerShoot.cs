using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public GameObject shootPrefab;
	private Transform myTransform;
	public float propulsionForce = 30f;

	// Use this for initialization
	void Start () {
		SetInitialReferences();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")) {
			Throw();
		}
	}
	
	void SetInitialReferences() {
		myTransform = transform;
	}
	
	void Throw() {
		GameObject go = (GameObject) Instantiate(shootPrefab, myTransform.TransformPoint(1f, 0, 0), myTransform.rotation);
		go.GetComponent<Rigidbody2D>().AddForce(Vector2.right * propulsionForce, ForceMode2D.Impulse);
		Destroy(go, 10);
	}
}
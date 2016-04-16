using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour 
{
	public GameObject shootPrefab;
	public Transform projectileParent;
	public Transform shootSpawnPosition;
	public float propulsionForce = 30f;

	public void Throw() {
		GameObject go = (GameObject) Instantiate(shootPrefab, shootSpawnPosition.position, shootSpawnPosition.rotation);
		go.transform.SetParent(projectileParent, false);

		//set projectile to spawn position since parenting resets position
		go.transform.position = shootSpawnPosition.position;

		go.GetComponent<Rigidbody2D>().AddForce(Vector2.right * propulsionForce, ForceMode2D.Impulse);
		Destroy(go, 10);
	}
}
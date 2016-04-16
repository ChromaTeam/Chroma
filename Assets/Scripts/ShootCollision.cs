using UnityEngine;
using System.Collections;

public class ShootCollision : MonoBehaviour {

    public LayerMask hitLayers;
	public GameObject explosionPrefab;
	public AudioClip explosionSound;

	void OnCollisionEnter2D (Collision2D col) {
		Debug.Log("Object hit !");
		ExplosionSound();
		ExplosionWork(col);
		
		Destroy(gameObject);
	}
	
	private void ExplosionSound() {
		AudioSource.PlayClipAtPoint(explosionSound, gameObject.transform.position);
	}

	private void ExplosionWork (Collision2D col) {
		GameObject explosion = (GameObject) Instantiate(explosionPrefab,transform.position,Quaternion.identity);
		Destroy(explosion, 3.0f);
		
		Collider2D collider = col.collider;
		
		if(collider.CompareTag("Enemy")) {
			EnemyDeath enemyDeath = collider.gameObject.GetComponent<EnemyDeath>();
			if(enemyDeath) {
				StartCoroutine(enemyDeath.Dying());
			}
		}
	}
}

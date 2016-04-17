using UnityEngine;
using System.Collections;

public class ShootCollision : MonoBehaviour {

    public LayerMask hitLayers;
	public GameObject explosionPrefab;
	public AudioClip explosionSound;

	public float direction;
	public float propulsionForce = 2f;

	public Rigidbody2D projectileRigidbody;

	public SpriteRenderer[] sprites;

	public void Shoot()
	{
		projectileRigidbody.AddForce(direction * Vector2.right * propulsionForce, ForceMode2D.Impulse);
	}

	public void SetDirection(float shootDirection)
	{
		foreach(var sprite in sprites)
		{
			sprite.flipX = shootDirection < 0;
		}

		direction = shootDirection;
	}

	void OnCollisionEnter2D (Collision2D col) {
		Debug.Log("Object hit !");
		//ExplosionSound();
		//ExplosionWork(col);
        if(col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }
		Destroy(gameObject);
        
	}
	
	private void ExplosionSound() {
		if(explosionSound) {
			AudioSource.PlayClipAtPoint(explosionSound, gameObject.transform.position);
		}
		else {
			Debug.Log("No sound for explosion");
		}
	}

	private void ExplosionWork (Collision2D col) {
		if(explosionPrefab) {
			GameObject explosion = (GameObject) Instantiate(explosionPrefab,transform.position,Quaternion.identity);
			Destroy(explosion, 3.0f);
		}
		else {
			Debug.Log("No object for explosion");
		}
		
		Collider2D collider = col.collider;
		
		if(collider.CompareTag("Enemy")) {
			EnemyDeath enemyDeath = collider.gameObject.GetComponent<EnemyDeath>();
			if(enemyDeath) {
				StartCoroutine(enemyDeath.Dying());
			}
		}
	}
}

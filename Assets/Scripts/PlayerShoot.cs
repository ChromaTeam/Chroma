using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour 
{
	public GameObject shootPrefab;
	public Transform projectileParent;
	public Transform shootSpawnPosition;

	public float direction = 1f;

	public Animator animator;

	public void Move(Vector2 axisValues)
	{
		//direction is x axis sign
		float sign = Mathf.Sign(axisValues.x);
		direction = axisValues.x == 0 ? direction : sign;
	}

	public void Throw() 
	{
		GameObject go = (GameObject) Instantiate(shootPrefab, shootSpawnPosition.position, shootSpawnPosition.rotation);
		go.transform.SetParent(projectileParent, false);

		ShootCollision shoot = go.GetComponent<ShootCollision>();
		if (shoot != null)
		{
			shoot.SetDirection(direction);
		}

		//set projectile to spawn position since parenting resets position
		go.transform.position = shootSpawnPosition.position;
		Destroy(go, 10);
	}

	public void ShootButtonDown()
	{
		animator.SetTrigger("Shoot");
	}

	public void ShootButtonUp()
	{
		animator.SetTrigger("Stop");
	}
}
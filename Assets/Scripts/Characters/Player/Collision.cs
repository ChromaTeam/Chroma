using UnityEngine;
using UnityEngine.Events;

using System.Collections;

[System.Serializable]
public class Collider2DEvent : UnityEvent<Collider2D> {}

public class Collision : MonoBehaviour 
{
	[SerializeField]
	private Collider2DEvent OnTriggerEnter;

	[SerializeField]
	private Collider2DEvent OnTriggerStay;

	[SerializeField]
	private Collider2DEvent OnTriggerExit;

	private void OnTriggerEnter2D(Collider2D other)
	{
		OnTriggerEnter.Invoke(other);
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		OnTriggerStay.Invoke(other);
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		OnTriggerExit.Invoke(other);
	}
}

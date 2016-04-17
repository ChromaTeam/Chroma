using UnityEngine;
using UnityEngine.Events;

public class AnimationEvent : MonoBehaviour 
{
	[SerializeField]
	private UnityEvent OnEvent;

	public void LaunchEvent()
	{
		OnEvent.Invoke();
	}
}

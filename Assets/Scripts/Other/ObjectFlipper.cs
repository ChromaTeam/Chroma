using UnityEngine;
using System.Collections;

public class ObjectFlipper : MonoBehaviour 
{
	[SerializeField]
	private GameObject m_Object;

	public float direction     = 1;
	public float prevDirection = 1;

	private Vector3 scale;
	private Vector3 initialScale;

	private void Awake()
	{
		initialScale = m_Object.transform.localScale;
	}

	public void Move(Vector2 axisValues)
	{
		//direction is x axis sign
		float sign = Mathf.Sign(axisValues.x);
		direction = axisValues.x == 0 ? direction : sign;

		if (direction == prevDirection)
		{
			return;
		}

		prevDirection = direction;

		Flip();
	}

	private void Flip()
	{
		scale.x = direction * initialScale.x;
		scale.y = initialScale.y;
		scale.z = initialScale.z;

		gameObject.transform.localScale = scale;
	}
}

using UnityEngine;
using UnityEngine.Events;

using System;
using System.Collections;

[System.Serializable]
public class FloatEvent : UnityEvent<float> {}

[System.Serializable]
public class Vector2Event : UnityEvent<Vector2> {}

[System.Serializable]
public class ButtonInput
{
	[SerializeField]
	private string m_Name;

	[SerializeField]
	private UnityEvent OnButtonDown;

	[SerializeField]
	private UnityEvent OnButtonUp;

	public void Update()
	{
		bool isKey = Input.GetButtonDown(m_Name);
		if (isKey)
		{
			OnButtonDown.Invoke();
		}

		isKey = Input.GetButtonUp(m_Name);
		if (isKey)
		{
			OnButtonUp.Invoke();
		}
	}
}

[System.Serializable]
public class AxisInput
{
	[SerializeField]
	private string m_Name;

	[SerializeField]
	private FloatEvent OnAxis;

	public void Update()
	{
		float axisValue = Input.GetAxis(m_Name);
		OnAxis.Invoke(axisValue);
	}
}

[System.Serializable]
public class DoubleAxisInput
{
	[SerializeField]
	private string m_FirstAxisName;

	[SerializeField]
	private string m_SecondAxisName;

	[SerializeField]
	private Vector2Event OnAxis;

	private Vector2 m_AxisValues = new Vector2();

	public void Update()
	{
		m_AxisValues.x = Input.GetAxis(m_FirstAxisName);
		m_AxisValues.y = Input.GetAxis(m_SecondAxisName);

		OnAxis.Invoke(m_AxisValues);
	}
}

public class InputController : MonoBehaviour 
{
	[SerializeField]
	private ButtonInput[] m_Buttons;

	[SerializeField]
	private AxisInput[] m_Axes;

	[SerializeField]
	private DoubleAxisInput[] m_DoubleAxes;

	private void Update()
	{
		foreach(var button in m_Buttons)
		{
			button.Update();
		}

		foreach(var axis in m_Axes)
		{
			axis.Update();
		}

		foreach(var doubleAxis in m_DoubleAxes)
		{
			doubleAxis.Update();
		}
	}
}

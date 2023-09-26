using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    #region Parameters
    [SerializeField] private Transform _startPos;
    [SerializeField] private Transform _endPos;
    [SerializeField] private GameObject _sphere;

	public float currentValue = 0;
	public float totalDistance = 0;
	#endregion

	#region Unity Methods

	private void Start()
	{
		//Total distance
		totalDistance = (_startPos.position.x *-1) + (_endPos.position.x);
	}
	void Update()
    {
		//Slider Movement
        ProcessSliderMovement();
    }
	#endregion
	#region General Methods
	private void ProcessSliderMovement()
	{
		//Slider limits
		_sphere.transform.localPosition = new Vector3(_sphere.transform.localPosition.x, 0, 0);
		if (_sphere.transform.localPosition.x <= _startPos.localPosition.x)
		{
			_sphere.transform.localPosition = new Vector3(_startPos.localPosition.x, 0, 0);
		}
		else if (_sphere.transform.localPosition.x >= _endPos.localPosition.x)
		{
			_sphere.transform.localPosition = new Vector3(_endPos.localPosition.x, 0, 0);
		}
		//Slider value
		currentValue = _startPos.localPosition.x * -1 + _sphere.transform.localPosition.x;
	}
	#endregion
}

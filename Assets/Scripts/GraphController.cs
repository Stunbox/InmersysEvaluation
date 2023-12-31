using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GraphController : MonoBehaviour
{
	#region Parameters
	public bool drawLine = false;
	[SerializeField] private Transform sphere;
	[SerializeField] private Slider slider;
	[SerializeField] private LineRenderer graphLine;
	[SerializeField] private GameObject[] lineTrails;
    [SerializeField] private Transform[] points;
	#endregion

	#region Control Variables
	private float _duration;
	private float _elapsedTime;
	private int index;
	#endregion

	#region Unity Methods
	// Start is called before the first frame update
	void Start()
	{
		index = 0;
	}

	// Update is called once per frame
	void Update()
	{
		if (slider.isMoving)
		{
			//Getting Slider values
			_duration = slider.totalDistance;
			_elapsedTime = slider.currentValue;

			//Lerping values w/ points
			var pointA = Vector2.Lerp(points[0].localPosition, points[1].localPosition, _elapsedTime / _duration);
			var pointB = Vector2.Lerp(points[1].localPosition, points[2].localPosition, _elapsedTime / _duration);
			var pointC = Vector2.Lerp(points[2].localPosition, points[3].localPosition, _elapsedTime / _duration);

			var pointD = Vector2.Lerp(pointA, pointB, _elapsedTime / _duration);
			var pointE = Vector2.Lerp(pointB, pointC, _elapsedTime / _duration);

			//Graph Sphere position 
			sphere.localPosition = Vector2.Lerp(pointD, pointE, _elapsedTime / _duration);

			//For draw the function
			if (drawLine) {
				graphLine.SetPosition(index, sphere.localPosition);
				index++;
			}
			//Calculating the scale of trail X
			var value = points[0].localPosition.x * -1 + sphere.localPosition.x;

			//Calculating the position on X of trail X
			var midPoint = (points[0].localPosition.x + sphere.localPosition.x) / 2;
			//Calculating the position on Y of trail Y
			var midPoint2 = (points[0].localPosition.y + sphere.localPosition.y) / 2;

			//X trail
			lineTrails[0].transform.localPosition = new Vector3(midPoint, sphere.localPosition.y, sphere.localPosition.z);
			lineTrails[0].transform.localScale = new Vector3(value, lineTrails[0].transform.localScale.y, lineTrails[0].transform.localScale.z);

			//Y trail
			lineTrails[1].transform.localPosition = new Vector3(sphere.localPosition.x, midPoint2, sphere.localPosition.z);
			lineTrails[1].transform.localScale = new Vector3(lineTrails[1].transform.localScale.x, sphere.localPosition.y, lineTrails[1].transform.localScale.z);
			
		}
	}
	#endregion

}

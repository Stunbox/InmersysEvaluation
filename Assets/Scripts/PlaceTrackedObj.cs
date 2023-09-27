using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class PlaceTrackedObj : MonoBehaviour
{
	#region Parameters
	private ARTrackedImageManager _trackedImagesManager;
	public UILevelsController uILevelsController;
	public GameObject[] ArPrefabs;
	private readonly Dictionary<string, GameObject> _instantiatedPrefabs = new Dictionary<string, GameObject>();
	#endregion

	#region Unity Methods
	// Start is called before the first frame update
	void Awake()
	{
		_trackedImagesManager = GetComponent<ARTrackedImageManager>();
	}

	void OnEnable()
	{
		_trackedImagesManager.trackedImagesChanged += OnTrackedImagesChanged;
	}
	void OnDisable()
	{
		_trackedImagesManager.trackedImagesChanged -= OnTrackedImagesChanged;
	}
	#endregion

	#region General Methods
	private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
	{
		foreach (var trackedImage in eventArgs.added)
		{
			var imageName = trackedImage.referenceImage.name;

			foreach (var curPrefab in ArPrefabs)
			{
				if (imageName == curPrefab.name && !_instantiatedPrefabs.ContainsKey(imageName))
				{
					var newPrefab = Instantiate(curPrefab, trackedImage.transform);
					_instantiatedPrefabs.Add(imageName, newPrefab);
					Debug.Log(newPrefab.transform.position);
				}
			}
		}

		foreach (var trackedImage in eventArgs.updated)
		{
			_instantiatedPrefabs[trackedImage.referenceImage.name].SetActive(trackedImage.trackingState == TrackingState.Tracking);
		}
		foreach (var trackedImage in eventArgs.removed)
		{
			Destroy(_instantiatedPrefabs[trackedImage.referenceImage.name]);
			_instantiatedPrefabs.Remove(trackedImage.referenceImage.name);

		}
	}
	#endregion
}

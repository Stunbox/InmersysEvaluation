using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    #region Parameters
    [SerializeField] private Transform _startPos;
    [SerializeField] private Transform _endPos;
    [SerializeField] private GameObject _sphere;

    public float value = 0;
	#endregion

	#region Unity Methods
	void Update()
    {
        _sphere.transform.localPosition = new Vector3(_sphere.transform.localPosition.x, 0, 0);
        if(_sphere.transform.localPosition.x <= _startPos.localPosition.x)
        {
			_sphere.transform.localPosition = new Vector3(_startPos.localPosition.x, 0, 0);
        }
        else if(_sphere.transform.localPosition.x >= _endPos.localPosition.x)
        {
			_sphere.transform.localPosition = new Vector3(_endPos.localPosition.x, 0, 0);
		}
    }
	#endregion
}

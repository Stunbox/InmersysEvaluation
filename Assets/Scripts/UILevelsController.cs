using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UILevelsController : MonoBehaviour
{
	#region Parameters
	public Button graphBtn,rotatorBtn;
	public TMP_Text titleLvl;
	public GameObject lvlsPanel;
	public GameObject lvlsBtn;

	public bool graphActive = false;
	public bool rotatorActive = false;
	#endregion

	private void Start()
	{
		if(graphBtn != null && rotatorBtn != null)
		{
			graphBtn.onClick.AddListener(OnClickGraphImage);
			rotatorBtn.onClick.AddListener(OnClickRotatorImage);
		}
	}

	private void OnClickGraphImage()
	{
		graphActive = true;
		rotatorActive = false;
		SetCurrentLvl("Graph lvl Selected");
	}
	private void OnClickRotatorImage()
	{
		graphActive = false;
		rotatorActive = true;
		SetCurrentLvl("Rotator lvl Selected");
	}
	private void SetCurrentLvl(string value)
	{
		titleLvl.text = value;
		lvlsPanel.SetActive(false);
		lvlsBtn.SetActive(true);
	}
}

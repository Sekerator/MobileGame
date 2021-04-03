using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marketing : MonoBehaviour
{
	public GameObject thisPanel, mainPanel, errorText;
	private GlobalParam globalParametrs;

	private void Awake()
	{
		globalParametrs = mainPanel.GetComponent<GlobalParam>();
		if (!PlayerPrefs.HasKey("marketing"))
			PlayerPrefs.SetString("marketing", "0");
	}
	
	public void closeButt()
	{
		thisPanel.SetActive(false);
	}

	public void newspaper_butt()
	{
		if (Convert.ToDouble(globalParametrs.money.text) >= 1000)
		{
			errorText.SetActive(false);
			PlayerPrefs.SetString("marketing", (Convert.ToInt32(PlayerPrefs.GetString("marketing")) + 5).ToString());
			globalParametrs.money.text =
				(Convert.ToDouble(globalParametrs.money.text) - 1000).ToString();
		}
		else
			errorText.SetActive(true);
	}
	public void radio_butt()
	{
		if (Convert.ToDouble(globalParametrs.money.text) >= 2000)
		{
			errorText.SetActive(false);
			PlayerPrefs.SetString("marketing", (Convert.ToInt32(PlayerPrefs.GetString("marketing")) + 10).ToString());
			globalParametrs.money.text =
				(Convert.ToDouble(globalParametrs.money.text) - 2000).ToString();
		}
		else
			errorText.SetActive(true);
	}
	public void tv_butt()
	{
		if (Convert.ToDouble(globalParametrs.money.text) >= 5000)
		{
			errorText.SetActive(false);
			PlayerPrefs.SetString("marketing", (Convert.ToInt32(PlayerPrefs.GetString("marketing")) + 15).ToString());
			globalParametrs.money.text =
				(Convert.ToDouble(globalParametrs.money.text) - 5000).ToString();
		}
		else 
			errorText.SetActive(true);
	}

	public void nextSeason()
	{
		if (PlayerPrefs.HasKey("marketing"))
		{
			globalParametrs.marketing.text = (Convert.ToInt32(globalParametrs.marketing.text) +
			                                  Convert.ToInt32(PlayerPrefs.GetString("marketing"))).ToString();
			PlayerPrefs.SetString("marketing", "0");
		}
	}
}

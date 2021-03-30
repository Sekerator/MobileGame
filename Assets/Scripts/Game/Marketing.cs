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
	}
	
	public void closeButt()
	{
		thisPanel.SetActive(false);
	}

	public void newspaper_butt()
	{
		if (Convert.ToInt32(globalParametrs.money.text) >= 1000)
		{
			errorText.SetActive(false);
			globalParametrs.marketing.text =
				(Convert.ToInt32(globalParametrs.marketing.text) + 5).ToString();
			globalParametrs.money.text =
				(Convert.ToInt32(globalParametrs.money.text) - 1000).ToString();
		}
		else
			errorText.SetActive(true);
	}
	public void radio_butt()
	{
		if (Convert.ToInt32(globalParametrs.money.text) >= 2000)
		{
			errorText.SetActive(false);
			globalParametrs.marketing.text =
				(Convert.ToInt32(globalParametrs.marketing.text) + 10).ToString();
			globalParametrs.money.text =
				(Convert.ToInt32(globalParametrs.money.text) - 2000).ToString();
		}
		else
			errorText.SetActive(true);
	}
	public void tv_butt()
	{
		if (Convert.ToInt32(globalParametrs.money.text) >= 5000)
		{
			errorText.SetActive(false);
			globalParametrs.marketing.text =
				(Convert.ToInt32(globalParametrs.marketing.text) + 15).ToString();
			globalParametrs.money.text =
				(Convert.ToInt32(globalParametrs.money.text) - 5000).ToString();
		}
		else 
			errorText.SetActive(true);
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Body : MonoBehaviour
{
	public GameObject thisPanel;

	public double power { get; set; }
	public int model { get; set; }
	public int materialsWasted { get; set; }
	public double price { get; set; }
	public int count { get; set; }


	/**
	 * Close Panel
	 */
	public void closeButt()
	{
		thisPanel.SetActive(false);
		
	}
}

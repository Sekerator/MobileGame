using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Engine : MonoBehaviour
{
	public GameObject thisPanel;
	public double Power { get; set; }
	public int Lvl { get; set; }
	public int Materials { get; set; }
	public double Price { get; set; }


	/**
	 * Close Panel
	 */
	public void closeButt()
	{
		thisPanel.SetActive(false);
	}
}

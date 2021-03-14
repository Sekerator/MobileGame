using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Engine : MonoBehaviour
{
	public GameObject thisPanel;
	public double power { get; set; }
	public string model { get; set; }
	public int materialsWasted { get; set; }
	public double price { get; set; }


	/**
	 * Close Panel
	 */
	public void closeButt()
	{
		thisPanel.SetActive(false);
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Market : MonoBehaviour
{
	public GameObject thisPanel, errorText, mainPanel;
	public Button closeButton;
	private GlobalParam globalParametrs;
	// Materials
	public GameObject materialBuyPanel;
	public InputField amountMaterials;

	private void Awake()
	{
		globalParametrs = mainPanel.GetComponent<GlobalParam>();
	}

	/**
	 * Закрытие панели маркета
	 */
	public void closeButt()
	{
		thisPanel.SetActive(false);
	}

	/**
	 * Нажатие кнопки "Материалы" на панели маркет
	 */
	public void materialBuyButt()
	{
		closeButton.interactable = false;
		materialBuyPanel.SetActive(true);
	}

	/**
	 * Нажатие кнопки "Купить" на панели покупки материалов
	 */
	public void materialBuyButt_FromPanel()
	{
		if (Convert.ToInt32(globalParametrs.money.text) >= (Convert.ToInt32(amountMaterials.text) * 4))
		{
			errorText.SetActive(false);
			closeButton.interactable = true;
			materialBuyPanel.SetActive(false);
			globalParametrs.money.text =
				(Convert.ToInt32(globalParametrs.money.text) - (Convert.ToInt32(amountMaterials.text) * 4)).ToString();
			globalParametrs.materials.text = amountMaterials.text;
		}
		else
			errorText.SetActive(true);
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Market : MonoBehaviour
{
	public GameObject errorText, mainPanel;
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
		if (Convert.ToInt64(globalParametrs.money.text) >= (Convert.ToInt64(amountMaterials.text) * 4))
		{
			errorText.SetActive(false);
			closeButton.interactable = true;
			materialBuyPanel.SetActive(false);
			globalParametrs.money.text =
				(Convert.ToInt64(globalParametrs.money.text) - (Convert.ToInt64(amountMaterials.text) * 4)).ToString();
			globalParametrs.materials.text = (Convert.ToInt32(globalParametrs.materials.text) + Convert.ToInt32(amountMaterials.text)).ToString();
		}
		else
		{
			errorText.SetActive(true);
			closeButton.interactable = true;
			materialBuyPanel.SetActive(false);
		}

	}
}

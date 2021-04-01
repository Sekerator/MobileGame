using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.SpriteAssetUtilities;
using UnityEngine;
using UnityEngine.UI;

public class Components : MonoBehaviour
{
	public double power { get; set; }
	public string model { get; set; }
	public int materialsWasted { get; set; }
	public double price { get; set; }
	public int count { get; set; }
	private string element;
	private GlobalParam globalParametrs;
	public List<Components> engine = new List<Components>();
	public List<Components> body = new List<Components>();
	public List<Components> chassis = new List<Components>();
	
	// Инфо при создании
	public Text powerText, materialText, priceText;
	public Dropdown levelDropdown;
	public InputField countInputField, modelInputField;
	
	// Инфо при просмотре
	public Text modelTextView, powerTextView, priceTextView, countTextView, upgradePrice;
	public Button rightView, leftView, upgrade;
	private int numberObject;

	private void Awake()
	{
		globalParametrs = gameObject.GetComponent<GlobalParam>();
	}

	public void createComponent_butt(string el)
	{
		element = el;
		infoTextForCreatePanel();
	}

	/**
	 * Функция при изменении dropdown листа
	 */
	public void changeDropdown()
	{
		infoTextForCreatePanel();
	}

	/**
	 * Функция для вывода мощности, количества материалов и цены
	 */
	private void infoTextForCreatePanel()
	{
		if (element == "Двигатель")
		{
			if (levelDropdown.value == 0)
				getLevelInfo("100", "500", "500");
			else if (levelDropdown.value == 1)
				getLevelInfo("200", "800", "800");
			else if (levelDropdown.value == 2)
				getLevelInfo("300", "1000", "1000");
		}
		else if (element == "Корпус")
		{
			if (levelDropdown.value == 0)
				getLevelInfo("50", "300", "300");
			else if (levelDropdown.value == 1)
				getLevelInfo("100", "500", "500");
			else if (levelDropdown.value == 2)
				getLevelInfo("150", "800", "800");
		}
		else
		{
			if (levelDropdown.value == 0)
				getLevelInfo("30", "200", "200");
			else if (levelDropdown.value == 1)
				getLevelInfo("60", "300", "300");
			else if (levelDropdown.value == 2)
				getLevelInfo("100", "500", "500");
		}
	}

	/**
	 * Определение уровня
	 */
	private void getLevelInfo(string pow, string mat, string pay)
	{
		powerText.text = pow;
		materialText.text = mat;
		priceText.text = pay;
	}

	/**
	 * Создание компонентов
	 */
	public void create_butt()
	{
		if ((Convert.ToInt32(countInputField.text) * Convert.ToInt32(priceText.text) <=
		    Convert.ToDouble(globalParametrs.money.text)) && (Convert.ToInt32(countInputField.text) * Convert.ToInt32(materialText.text) <=
		                                                      Convert.ToDouble(globalParametrs.materials.text)))
		{
			if (element == "Двигатель")
			{
				Components dataObj = new Components();
				dataObj.model = modelInputField.text;
				dataObj.power = Convert.ToDouble(powerText.text);
				dataObj.materialsWasted = Convert.ToInt32(materialText.text);
				dataObj.price = Convert.ToDouble(priceText.text);
				dataObj.count = Convert.ToInt32(countInputField.text);
				engine.Add(dataObj);
			}
			else if (element == "Корпус")
			{
				Components dataObj = new Components();
				dataObj.model = modelInputField.text;
				dataObj.power = Convert.ToDouble(powerText.text);
				dataObj.materialsWasted = Convert.ToInt32(materialText.text);
				dataObj.price = Convert.ToDouble(priceText.text);
				dataObj.count = Convert.ToInt32(countInputField.text);
				body.Add(dataObj);
			}
			else if (element == "Шасси")
			{
				Components dataObj = new Components();
				dataObj.model = modelInputField.text;
				dataObj.power = Convert.ToDouble(powerText.text);
				dataObj.materialsWasted = Convert.ToInt32(materialText.text);
				dataObj.price = Convert.ToDouble(priceText.text);
				dataObj.count = Convert.ToInt32(countInputField.text);
				chassis.Add(dataObj);
			}

			globalParametrs.money.text = (Convert.ToDouble(globalParametrs.money.text) -
			                              Convert.ToInt32(countInputField.text) * Convert.ToInt32(priceText.text)).ToString();
			
			globalParametrs.materials.text = (Convert.ToDouble(globalParametrs.materials.text) -
			                              Convert.ToInt32(countInputField.text) * Convert.ToInt32(materialText.text)).ToString();
			
		}
	}

	public void viewComponent_butt(string el)
	{
		if (engine.Count > 1)
		{
			leftView.interactable = false;
			rightView.interactable = true;
		}
		else
		{
			leftView.interactable = false;
			rightView.interactable = false;
		}
		upgrade.interactable = true;
		element = el;
		numberObject = 0;
		if (element == "Двигатель" && engine.Count != 0)
				viewInfo(engine[numberObject]);
		else if (element == "Корпус" && body.Count != 0)
				viewInfo(body[numberObject]);
		else if (element == "Шасси" && chassis.Count != 0)
			viewInfo(chassis[numberObject]);
		else
		{
			modelTextView.text = "Нету компонентов";
			powerTextView.text = "";
			priceTextView.text = "";
			countTextView.text = "";
			upgradePrice.text = "";
			upgrade.interactable = false;
		}
	}
	public void view_butt(bool right = false)
	{
		if (right)
		{
			if (element == "Двигатель")
			{
				if (engine.Count > numberObject + 1)
				{
					numberObject++;
					if (leftView.interactable == false)
						leftView.interactable = true;
				}
				viewInfo(engine[numberObject]);
				if (numberObject == engine.Count - 1)
					rightView.interactable = false;
			}
			else if (element == "Корпус")
			{
				if (body.Count > numberObject + 1)
				{
					numberObject++;
					if (leftView.interactable == false)
						leftView.interactable = true;
				}
				viewInfo(body[numberObject]);
				if (numberObject == body.Count - 1)
					rightView.interactable = false;
			}
			else if (element == "Шасси")
			{
				if (chassis.Count > numberObject + 1)
				{
					numberObject++;
					if (leftView.interactable == false)
						leftView.interactable = true;
				}
				viewInfo(chassis[numberObject]);
				if (numberObject == chassis.Count - 1)
					rightView.interactable = false;
			}
		}
		else
		{
			if (element == "Двигатель")
			{
				if (0 < numberObject)
				{
					numberObject--;
					if (rightView.interactable == false)
						rightView.interactable = true;
				}
				viewInfo(engine[numberObject]);
				if (numberObject == 0)
					leftView.interactable = false;
			}
			else if (element == "Корпус")
			{
				if (0 < numberObject)
				{
					numberObject--;
					if (rightView.interactable == false)
						rightView.interactable = true;
				}
				viewInfo(body[numberObject]);
				if (numberObject == 0)
					leftView.interactable = false;
			}
			else if (element == "Шасси")
			{
				if (0 < numberObject)
				{
					numberObject--;
					if (rightView.interactable == false)
						rightView.interactable = true;
				}
				viewInfo(chassis[numberObject]);
				if (numberObject == 0)
					leftView.interactable = false;
			}
		}
	}

	private void viewInfo(Components obj)
	{
		modelTextView.text = obj.model;
		powerTextView.text = obj.power.ToString();
		priceTextView.text = ((obj.materialsWasted * 4) + obj.price).ToString();
		countTextView.text = obj.count.ToString();
		upgradePrice.text = (Convert.ToDouble(priceTextView.text) / 10).ToString();
	}

	public void upgrade_butt()
	{
		if (Convert.ToDouble(globalParametrs.money.text) >= Convert.ToDouble(upgradePrice.text))
		{
			globalParametrs.money.text =
				(Convert.ToDouble(globalParametrs.money.text) - Convert.ToDouble(upgradePrice.text)).ToString();
			powerTextView.text = (Convert.ToDouble(powerTextView.text) + (Convert.ToDouble(powerTextView.text) / 10)).ToString();
			priceTextView.text =
				(Convert.ToDouble(priceTextView.text) + Convert.ToDouble(upgradePrice.text)).ToString();
			upgradePrice.text = (Convert.ToDouble(priceTextView.text) / 10).ToString();
			if (element == "Двигатель")
			{
				engine[numberObject].power = Convert.ToDouble(powerTextView.text);
				engine[numberObject].price = Convert.ToDouble(priceTextView.text);
			}
			else if (element == "Корпус")
			{
				body[numberObject].power = Convert.ToDouble(powerTextView.text);
				body[numberObject].price = Convert.ToDouble(priceTextView.text);
			}
			else if (element == "Шасси")
			{
				chassis[numberObject].power = Convert.ToDouble(powerTextView.text);
				chassis[numberObject].price = Convert.ToDouble(priceTextView.text);
			}
		}
	}
}

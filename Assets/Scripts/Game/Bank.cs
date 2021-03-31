using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bank : MonoBehaviour
{
	public GameObject mainPanel;
	private GlobalParam globalParametrs;

	private double sumCredit = 0;
	public Text period, percent, seasonPay, remainderCredit;
	
	// Take
	public InputField takeCredit;

	// Repay
	public InputField repayCredit;


	private void Awake()
	{
		globalParametrs = mainPanel.GetComponent<GlobalParam>();
		remainderCredit.text = "0";
	}

	/**
	 * расчёт процента по кредиту
	 */
	void getPercent()
	{
		if ((sumCredit > 0) && (sumCredit <= 100000))
			percent.text = "10";
		else if ((sumCredit > 100000) && (sumCredit <= 500000))
			percent.text = "20";
		else if ((sumCredit > 500000) && (sumCredit <= 1000000))
			percent.text = "30";
		else
			percent.text = "50";
	}
	
	/**
	 * расчёт периода по кредиту
	 */
	void getPeriod()
	{
		if ((sumCredit > 0) && (sumCredit <= 100000))
			period.text = "4";
		else if ((sumCredit > 100000) && (sumCredit <= 500000))
			period.text = "12";
		else if ((sumCredit > 500000) && (sumCredit <= 1000000))
			period.text = "20";
		else
			period.text = "40";
	}

	public void takeCredit_butt()
	{
		sumCredit += Convert.ToDouble(takeCredit.text);
		globalParametrs.money.text = (Convert.ToDouble(globalParametrs.money.text) + Convert.ToDouble(takeCredit.text)).ToString();

		getPercent();
		sumCredit = sumCredit + sumCredit * Convert.ToDouble(percent.text) / 100.00f;
		getPeriod();
		seasonPay.text = (sumCredit / Convert.ToDouble(period.text)).ToString();
		remainderCredit.text = sumCredit.ToString();
	}
	
	public void repayCredit_butt()
	{
		if (Convert.ToDouble(globalParametrs.money.text) >= Convert.ToDouble(repayCredit.text) &&
		    Convert.ToDouble(repayCredit.text) <= sumCredit)
		{
			sumCredit -= Convert.ToDouble(repayCredit.text);
			globalParametrs.money.text = (Convert.ToDouble(globalParametrs.money.text) - Convert.ToDouble(repayCredit.text)).ToString();

			getPercent();
			getPeriod();
			seasonPay.text = (sumCredit / Convert.ToDouble(period.text)).ToString();
			remainderCredit.text = sumCredit.ToString();
		}
	}

	public void seasonNext()
	{
		if (Convert.ToInt32(period.text) > 0)
		{
			sumCredit -= Convert.ToDouble(seasonPay.text);
			if (sumCredit < 0)
				sumCredit = 0;
			globalParametrs.money.text = (Convert.ToDouble(globalParametrs.money.text) - Convert.ToDouble(seasonPay.text)).ToString();

			period.text = (Convert.ToInt32(period.text) - 1).ToString();
			seasonPay.text = (sumCredit / Convert.ToDouble(period.text)).ToString();
			remainderCredit.text = sumCredit.ToString();
		}
	}
}

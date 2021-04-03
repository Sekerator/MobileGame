using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bank : MonoBehaviour
{
	public GameObject mainPanel;
	private GlobalParam globalParametrs;
	
	// Credit
	private double sumCredit = 0;
	public Text periodCredit, percentCredit, seasonPayCredit, remainderCredit;
	// Take
	public InputField takeCredit;
	// Repay
	public InputField repayCredit;
	
	
	// Deposit
	private double sumDeposit = 0;
	public Text periodDeposit, percentDeposit, seasonProfitDeposit, remainderDeposit;
	// Take
	public InputField setDeposit;
	// Repay
	public InputField getDeposit;

	private void Awake()
	{
		globalParametrs = mainPanel.GetComponent<GlobalParam>();
		remainderCredit.text = "0";
		remainderDeposit.text = "0";
	}

	/**
	 * расчёт процента по кредиту
	 */
	void getPercentCredit()
	{
		if ((sumCredit > 0) && (sumCredit <= 100000))
			percentCredit.text = "10";
		else if ((sumCredit > 100000) && (sumCredit <= 500000))
			percentCredit.text = "20";
		else if ((sumCredit > 500000) && (sumCredit <= 1000000))
			percentCredit.text = "30";
		else
			percentCredit.text = "50";
	}
	
	/**
	 * расчёт процента по вкладу
	 */
	void getPercentDeposit()
	{
		if ((sumDeposit > 0) && (sumDeposit <= 100000))
			percentDeposit.text = "1";
		else if ((sumDeposit > 100000) && (sumDeposit <= 500000))
			percentCredit.text = "3";
		else if ((sumDeposit > 500000) && (sumDeposit <= 1000000))
			percentDeposit.text = "5";
		else
			percentDeposit.text = "10";
	}
	
	/**
	 * расчёт периода по кредиту
	 */
	void getPeriodCredit()
	{
		if ((sumCredit > 0) && (sumCredit <= 100000))
			periodCredit.text = "4";
		else if ((sumCredit > 100000) && (sumCredit <= 500000))
			periodCredit.text = "12";
		else if ((sumCredit > 500000) && (sumCredit <= 1000000))
			periodCredit.text = "20";
		else
			periodCredit.text = "40";
	}

	/**
	 * расчёт периода по вкладу
	 */
	void getPeriodDeposit()
	{
		if ((sumDeposit > 0) && (sumDeposit <= 100000))
			periodDeposit.text = "4";
		else if ((sumDeposit > 100000) && (sumDeposit <= 500000))
			periodDeposit.text = "12";
		else if ((sumDeposit > 500000) && (sumDeposit <= 1000000))
			periodDeposit.text = "20";
		else
			periodDeposit.text = "40";
	}
	
	/**
	 * кнопка взять кредит
	 */
	public void takeCredit_butt()
	{
		sumCredit += Math.Round(Convert.ToDouble(takeCredit.text), 2);
		globalParametrs.money.text = (Convert.ToDouble(globalParametrs.money.text) + Convert.ToDouble(takeCredit.text)).ToString();

		getPercentCredit();
		sumCredit = Math.Round((sumCredit + sumCredit * Convert.ToDouble(percentCredit.text) / 100.00f), 2);
		getPeriodCredit();
		seasonPayCredit.text = Math.Round((sumCredit / Convert.ToDouble(periodCredit.text)), 2).ToString();
		//seasonPayCredit.text = Math.Round((sumCredit * Convert.ToDouble(percentCredit.text) / 100.00f) / Convert.ToDouble(periodCredit.text), 2).ToString();
		remainderCredit.text = sumCredit.ToString();
	}
	
	/**
	 * кнопка внести вклад
	 */
	public void setDeposit_butt()
	{
		if (Convert.ToDouble(setDeposit.text) <= Convert.ToDouble(globalParametrs.money.text))
		{
			sumDeposit += Math.Round(Convert.ToDouble(setDeposit.text), 2);
			globalParametrs.money.text =
				(Convert.ToDouble(globalParametrs.money.text) - Convert.ToDouble(setDeposit.text)).ToString();

			getPercentDeposit();
			getPeriodDeposit();
			seasonProfitDeposit.text =
				Math.Round((sumDeposit * Convert.ToDouble(percentDeposit.text) / 100.00f), 2).ToString();
			remainderDeposit.text = sumDeposit.ToString();
		}
	}
	
	/**
	 * кнопка погасить кредит
	 */
	public void repayCredit_butt()
	{
		if (Convert.ToDouble(globalParametrs.money.text) >= Convert.ToDouble(repayCredit.text) &&
		    Convert.ToDouble(repayCredit.text) <= sumCredit)
		{
			sumCredit -= Math.Round(Convert.ToDouble(repayCredit.text), 2);
			globalParametrs.money.text = (Convert.ToDouble(globalParametrs.money.text) - Convert.ToDouble(repayCredit.text)).ToString();

			getPercentCredit();
			getPeriodCredit();
			seasonPayCredit.text = Math.Round((sumCredit / Convert.ToDouble(periodCredit.text)), 2).ToString();
			remainderCredit.text = sumCredit.ToString();
		}
	}
	
	/**
	 * кнопка забрать вклад
	 */
	public void getDeposit_butt()
	{
		if (Convert.ToDouble(getDeposit.text) <= sumDeposit)
		{
			sumDeposit -= Math.Round(Convert.ToDouble(getDeposit.text), 2);
			globalParametrs.money.text = (Convert.ToDouble(globalParametrs.money.text) + Convert.ToDouble(getDeposit.text)).ToString();
			
			remainderDeposit.text = sumDeposit.ToString();
		}
		else
		{
			globalParametrs.money.text = (Convert.ToDouble(globalParametrs.money.text) + sumDeposit).ToString();
			sumDeposit = 0;
			remainderDeposit.text = sumDeposit.ToString();
			seasonProfitDeposit.text = "0";
			periodDeposit.text = "0";
			percentDeposit.text = "0";
		}
	}
	
	/**
	 * кнопка перехода на следующий ход
	 */
	public void nextSeason()
	{
		if (sumCredit != 0)
		{
			if (Convert.ToInt32(periodCredit.text) > 0)
			{
				sumCredit -= Convert.ToDouble(seasonPayCredit.text);
				

				globalParametrs.money.text =
					(Convert.ToDouble(globalParametrs.money.text) - Convert.ToDouble(seasonPayCredit.text)).ToString();

				periodCredit.text = (Convert.ToInt32(periodCredit.text) - 1).ToString();
				seasonPayCredit.text = Math.Round((sumCredit / Convert.ToDouble(periodCredit.text)), 2).ToString();
				remainderCredit.text = Math.Round(sumCredit, 2).ToString();
				
				if (sumCredit <= 0)
				{
					sumCredit = 0;
					seasonPayCredit.text = "0";
				}
			}
		}

		if (sumDeposit != 0)
		{
			if (Convert.ToInt32(periodDeposit.text) > 0)
			{
				sumDeposit += Math.Round(Convert.ToDouble(seasonProfitDeposit.text), 2);

				periodDeposit.text = (Convert.ToInt32(periodDeposit.text) - 1).ToString();
				remainderDeposit.text = sumDeposit.ToString();
			}
		}
	}
}

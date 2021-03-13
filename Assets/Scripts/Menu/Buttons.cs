using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
	public string url = "http://mopsnet.tk/";
	public Button play;
	public GameObject autorizationPanel, profilePanel;
	private void Start()
	{
		//Если пользователь не выполнил вход
		if (!PlayerPrefs.HasKey("id"))
		{
			play.GetComponent<Button>().image.color = Color.gray;
		}
	}

	/**
	 * Функция для кнопки играть
	 */
    public void playButt()
	{
		if(PlayerPrefs.HasKey("id"))
			SceneManager.LoadScene("Game");
		else
			autorizationPanel.SetActive(true);
	}

	/**
	 * Функция закрытия панели авторизации
	 */
	public void closeAutoButt()
	{
		autorizationPanel.SetActive(false);
	}
	
	/**
	 * Функция закрытия панели профиля
	 */
	public void closeProfileButt()
	{
		profilePanel.SetActive(false);
	}
	
	/**
	 * Функция для кнопки профиля
	 */
	public void profileButt()
	{
		if (!PlayerPrefs.HasKey("id"))
			autorizationPanel.SetActive(true);
		else
		{
			profilePanel.SetActive(true);
			gameObject.GetComponent<Profile>().selectInfo();
		}
	}

	public void loginButt()
	{
		gameObject.GetComponent<Autorization>().login();
	}

	public void logOutButt()
	{
		PlayerPrefs.DeleteKey("id");
		profilePanel.SetActive(false);
	}

	public void updateButt()
	{
		gameObject.GetComponent<Profile>().updateInfo();
	}

	public void registrationButt()
	{
		gameObject.GetComponent<Autorization>().registration();
	}
}

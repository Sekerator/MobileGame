using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
	public InputField nickname;
	private string url = "http://mopsnet.tk/startGame.php";
	public Button playButton;
	public GameObject loadingPanel;
	public Text loadingText;
	private int countPlayers = 1;
	private string layout = "Пожалуйста ожидайте\nПользователей в очереди: ";

	private void Awake()
	{
		PlayerPrefs.SetString("url", url);
	}

	/**
	 * Нажатие на кнопку играть
	 */
    public void playButt()
	{
		StartCoroutine(loading());
	}

	private void FixedUpdate()
	{
		StartCoroutine(countPlayer());
	}

	/**
	 * Проверка количества игроков и начало игры, если игроков 
	 */
	IEnumerator countPlayer()
	{
		WWWForm form = new WWWForm();
		form.AddField("request", "count_users");
		WWW www = new WWW(url, form);
		yield return www;
		loadingText.text = layout + www.text;
		if (Convert.ToInt32(www.text) >= countPlayers)
		{
			form = new WWWForm();
			form.AddField("request", "start_game");
			www = new WWW(url, form);
			yield return www;
			if (www.text != "Error")
			{
				SceneManager.LoadScene("Game");
			}
		}
	}

	/**
	 * Создание пользователя в таблице users
	 */
	IEnumerator loading()
	{
		WWWForm form = new WWWForm();
		form.AddField("request", "add_user");
		form.AddField("nickname", nickname.text);
		WWW www = new WWW(url, form);
		yield return www;
		if (www.text != "Error")
		{
			playButton.enabled = false;
			loadingPanel.SetActive(true);
			loadingText.text += www.text;
			PlayerPrefs.SetString("nickname", nickname.text);
		}
		else
		{
			Debug.Log(www.text);
		}
	}

	/**
	 * Нажатие на кнопку выхода на панели
	 */
	public void exitButt()
	{
		StartCoroutine(loadingExit());
	}
	
	/**
	 * Удаление пользователя из таблицы users
	 */
	IEnumerator loadingExit()
	{
		loadingText.text = layout;
		playButton.enabled = true;
		loadingPanel.SetActive(false);
		WWWForm form = new WWWForm();
		form.AddField("request", "delete_user");
		form.AddField("nickname", nickname.text);
		if(PlayerPrefs.HasKey("nickname"))
			PlayerPrefs.DeleteKey("nickname");
		WWW www = new WWW(url, form);
		yield return www;
	}

	private void OnApplicationQuit()
	{
		StartCoroutine(loadingExit());
	}
}

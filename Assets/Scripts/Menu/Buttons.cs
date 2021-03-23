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
	public string url = "http://mopsnet.bk/index.php";
	public Button playButton;
	public GameObject loadingPanel;
	public Text loadingText;
	/**
	 * Функция для кнопки играть
	 */
    public void playButt()
	{
		StartCoroutine(loading());
	}

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
			if (www.text == "5")
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
		else
		{
			Debug.Log(www.text);
		}
	}

	public void exitButt()
	{
		StartCoroutine(loadingExit());
	}
	IEnumerator loadingExit()
	{
		loadingText.text = "Пожалуйста ожидайте\nПользователей в очереди:";
		playButton.enabled = true;
		loadingPanel.SetActive(false);
		WWWForm form = new WWWForm();
		form.AddField("request", "delete_user");
		form.AddField("nickname", nickname.text);
		WWW www = new WWW(url, form);
		yield return www;
	}
	
}

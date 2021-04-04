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
    //private string url = "http://dev.mobile.game/startGame.php";
    //private string url = "http://localhost/startGame.php";
    public Button playButton;
    public GameObject loadingPanel;
    public Text loadingText;
    private int countPlayers = 3;
    private float timeRemaining = 5f;
    private string layout = "Пожалуйста ожидайте\nПользователей в очереди: ";

    private void Awake()
    {
        PlayerPrefs.SetString("url", url);
        if (PlayerPrefs.HasKey("nickname"))
        {
            nickname.text = PlayerPrefs.GetString("nickname");
            loadingExit();
            nickname.text = "";
            PlayerPrefs.DeleteKey("nickname");
        }
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
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            StartCoroutine(countPlayer());
            timeRemaining = 5f;
        }
    }

    /**
	 * Проверка количества игроков и начало игры, если игроков 
	 */
    IEnumerator countPlayer()
    {
        // Получение количества пользователей в очереди
        WWWForm form = new WWWForm();
        form.AddField("request", "count_users");
        WWW www = new WWW(url, form);
        yield return www;

        // Получение номера комнаты
        WWWForm forms = new WWWForm();
        forms.AddField("request", "get_room");
        forms.AddField("nickname", PlayerPrefs.GetString("nickname"));
        WWW wwws = new WWW(url, forms);
        yield return wwws;

        loadingText.text = layout + www.text;
        if (www.text == countPlayers.ToString())
        {
            form = new WWWForm();
            form.AddField("request", "start_game");
            www = new WWW(url, form);
            yield return www;
        }
        if ((wwws.text != "-1") && (wwws.text != "Error"))
        {
            SceneManager.LoadScene("Game");
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
        if (PlayerPrefs.HasKey("nickname"))
            PlayerPrefs.DeleteKey("nickname");
        WWW www = new WWW(url, form);
        yield return www;
    }

    private void OnApplicationQuit()
    {
        StartCoroutine(loadingExit());
        PlayerPrefs.DeleteAll();
    }

    private void OnApplicationPause(bool status)
    {
        if (status == true)
        {
            StartCoroutine(loadingExit());
            PlayerPrefs.DeleteAll();
            Application.Quit();
        }
    }
    
    private void OnApplicationFocus(bool status)
    {
        if (status == false)
        {
            StartCoroutine(loadingExit());
            PlayerPrefs.DeleteAll();
            Application.Quit();
        }
    }
}
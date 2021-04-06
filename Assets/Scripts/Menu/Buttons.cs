using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    //private string url = "http://mopsnet.tk/startGame.php";
    private string url = "http://dev.mobile.game/startGame.php";

    //private string url = "http://localhost/startGame.php";
    public GameObject loadingPanel;
    public Text loadingText;
    private int countPlayers = 3;
    private float timeRemaining = 5f;
    private string layout = "Пожалуйста ожидайте\nПользователей в очереди: ";

    // Profile
    public GameObject ProfilePanel;
    public InputField nickname, password, updateNickname;
    public GameObject loginedObj, unloginedObj, errorText;

    public void Awake()
    {
        if (PlayerPrefs.HasKey("nickname"))
            logined(true);
    }

    /**
     * Переключение панели 
     */
    private void logined(bool log = false)
    {
        loginedObj.SetActive(!log);
        unloginedObj.SetActive(log);
    }
    
    public void login()
    {
        StartCoroutine(log_in());
    }

    public void registration()
    {
        StartCoroutine(registrat_ion());
    }

    IEnumerator log_in()
    {
        WWWForm add = new WWWForm();
        add.AddField("request", "login_user");
        add.AddField("nickname", nickname.text);
        add.AddField("password", password.text);
        WWW a = new WWW(url, add);
        yield return a;
        if (a.text == "Good")
        {
            PlayerPrefs.SetString("nickname", nickname.text);
            logined(true);
            errorText.SetActive(false);
        }
        else
        {
            errorText.SetActive(true);
            errorText.GetComponent<Text>().text = "Неправильный логин или пароль";
        }
    }

    IEnumerator registrat_ion()
    {
        WWWForm add = new WWWForm();
        add.AddField("request", "add_user");
        add.AddField("nickname", nickname.text);
        add.AddField("password", password.text);
        WWW a = new WWW(url, add);
        yield return a;
        if (a.text == "Good")
        {
            PlayerPrefs.SetString("nickname", nickname.text);
            logined(true);
            errorText.SetActive(false);
        }
        else
        {
            errorText.SetActive(true);
            errorText.GetComponent<Text>().text = "Пользователь с таким именем уже существует";
        }
    }

    public void update()
    {
        StartCoroutine(updateNick());
    }
    
    IEnumerator updateNick()
    {
        WWWForm add = new WWWForm();
        add.AddField("request", "update_user");
        add.AddField("nicknameNew", updateNickname.text);
        add.AddField("nicknameOld", PlayerPrefs.GetString("nickname"));
        WWW a = new WWW(url, add);
        yield return a;
        if (a.text == "Good")
        {
            PlayerPrefs.SetString("nickname", updateNickname.text);
            logined(true);
            errorText.SetActive(false);
        }
        else
        {
            errorText.SetActive(true);
            errorText.GetComponent<Text>().text = "Пользователь с таким именем уже существует";
        }
    }

    public void exitProfile()
    {
        if(PlayerPrefs.HasKey("nickname"))
            PlayerPrefs.DeleteKey("nickname");
        logined();
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    private void FixedUpdate()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            timeRemaining = 5f;
        }
    }
}
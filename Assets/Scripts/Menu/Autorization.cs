using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class Autorization : MonoBehaviour
{
    public InputField loginInput, passwordInput;
    private string url;

    private void Awake()
    {
        Buttons butt = new Buttons();
        url = butt.url;
    }

    public void login()
    {
        StartCoroutine(autoLog("login.php"));
    }

    public void registration()
    {
        StartCoroutine(autoReg("registration.php"));
    }

    IEnumerator autoLog(string operation)
    {
        WWWForm login = new WWWForm();
        login.AddField("nickname", loginInput.text);
        login.AddField("password", passwordInput.text);
        WWW data = new WWW(url + operation, login);
        yield return data;
        JSONArray result = JSON.Parse(data.text) as JSONArray;
        JSONArray sas = JSON.Parse(data.text) as JSONArray;
        if (result == null)
        {
            loginInput.text = "";
            passwordInput.text = "";
            loginInput.placeholder.GetComponent<Text>().text = "Ошибка";
            passwordInput.placeholder.GetComponent<Text>().text = "ввода";
        }
        else
        {
            PlayerPrefs.SetInt("id", result[0]["id"]);
            gameObject.GetComponent<Buttons>().closeAutoButt();
        }
    }
    
    IEnumerator autoReg(string operation)
    {
        WWWForm login = new WWWForm();
        login.AddField("nickname", loginInput.text);
        login.AddField("password", passwordInput.text);
        WWW data = new WWW(url + operation, login);
        yield return data;
        if (data.text != "Успешно")
        {
            loginInput.text = "";
            passwordInput.text = "";
            loginInput.placeholder.GetComponent<Text>().text = "Ошибка";
            passwordInput.placeholder.GetComponent<Text>().text = "ввода";
        }
        else
        {
            loginInput.text = "";
            passwordInput.text = "";
            loginInput.placeholder.GetComponent<Text>().text = "Регистрация";
            passwordInput.placeholder.GetComponent<Text>().text = "успешна";
        }
    }
}

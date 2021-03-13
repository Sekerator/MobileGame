using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class Profile : MonoBehaviour
{
    private string url;
    public InputField loginInput, passwordInput;

    private void Awake()
    {
        Buttons butt = new Buttons();
        url = butt.url;
    }
    
    public void selectInfo()
    {
        StartCoroutine(profileSelectOperation("select.php"));
    }
    
    public void updateInfo()
    {
        StartCoroutine(profileUpdateOperation("update.php"));
    }

    IEnumerator profileUpdateOperation(string operation)
    {
        WWWForm login = new WWWForm();
        login.AddField("nickname", loginInput.text);
        login.AddField("password", passwordInput.text);
        WWW data = new WWW(url + operation, login);
        yield return data;
        Debug.Log(data.text);
        JSONArray result = JSON.Parse(data.text) as JSONArray;
        loginInput.text = result[0]["nickname"];
        passwordInput.text = "";
    }
    
    IEnumerator profileSelectOperation(string operation)
    {
        WWWForm login = new WWWForm();
        login.AddField("id", PlayerPrefs.GetInt("id"));
        WWW data = new WWW(url + operation, login);
        yield return data;
        JSONArray result = JSON.Parse(data.text) as JSONArray;
        loginInput.text = result[0]["nickname"];
        passwordInput.text = "";
    }
}

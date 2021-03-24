using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class GlobalParam : MonoBehaviour
{
    public int materials { get; set; }
    public double money { get; set; }
    public int marketing { get; set; }
    public int research { get; set; }
    public int time { get; set; }
}


/* Пример работы с PHP
 
public class GlobalParam : MonoBehaviour
{
    public int materials { get; set; }
    public double money { get; set; }
    public int marketing { get; set; }
    public int research { get; set; }
    public int machineToolCount { get; set; }
    public int time { get; set; }
    private void Start()
    {
        StartCoroutine(sss());
    }

    IEnumerator sss()
    {
        WWWForm add = new WWWForm();
        add.AddField("age", "12");
        add.AddField("name", "tolik");
        add.AddField("pass", "add");
        WWW a = new WWW("test.ru/test.php", add);
        yield return a;
        //sss lol = JsonUtility.FromJson<sss>("{\"users\":" + a.text + "}");
        JSONArray lol = JSON.Parse(a.text) as JSONArray;
        Debug.Log(lol[1]["id"]);
    }
}

[Serializable]
public class sss
{
public ss[] kek;
}

[Serializable]
public class ss
{
public string name { get; set; }
public int age { get; set; }
public string pass { get; set; }
}
*/
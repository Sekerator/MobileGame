using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  SimpleJSON;
using UnityEngine.UI;

public class Rating : MonoBehaviour
{
    private string url = "http://mopsnet.tk/game.php";
    public Text infoP1Nickname, infoP2Nickname, infoP3Nickname,infoP4Nickname, infoP5Nickname,
        infoP1Money, infoP2Money, infoP3Money,infoP4Money, infoP5Money,
        infoP1Marketing, infoP2Marketing, infoP3Marketing,infoP4Marketing, infoP5Marketing,
        infoP1Research, infoP2Research, infoP3Research,infoP4Research, infoP5Research;
    
    public void Awake()
    {
        StartCoroutine(createRating());
        StartCoroutine(getJSON());
    }

    IEnumerator createRating()
    {
        WWWForm add = new WWWForm();
        add.AddField("request", "createRating");
        add.AddField("nickname", PlayerPrefs.GetString("nickname"));
        add.AddField("room_number", PlayerPrefs.GetString("room_number"));
        add.AddField("money", gameObject.GetComponent<GlobalParam>().money.text);
        add.AddField("marketing", gameObject.GetComponent<GlobalParam>().marketing.text);
        add.AddField("research", gameObject.GetComponent<GlobalParam>().research.text);
        WWW a = new WWW(url, add);
        yield return a;
        
        if(a.text != "Good")
            Debug.Log(a.text);
    }

    IEnumerator updateReating()
    {
        WWWForm add = new WWWForm();
        add.AddField("request", "setRating");
        add.AddField("nickname", PlayerPrefs.GetString("nickname"));
        add.AddField("room_number", PlayerPrefs.GetString("room_number"));
        add.AddField("money", gameObject.GetComponent<GlobalParam>().money.text);
        add.AddField("marketing", gameObject.GetComponent<GlobalParam>().marketing.text);
        add.AddField("research", gameObject.GetComponent<GlobalParam>().research.text);
        WWW a = new WWW(url, add);
        yield return a;
        
        if(a.text != "Good")
            Debug.Log(a.text);
    }
    
    IEnumerator getJSON()
    {
        StartCoroutine(updateReating());
        
        WWWForm add = new WWWForm();
        add.AddField("request", "getRating");
        add.AddField("room_number", PlayerPrefs.GetString("room_number"));
        WWW a = new WWW(url, add);
        yield return a;

        var array = JSON.Parse(a.text);

        infoP1Nickname.text = array[0]["nickname"];
        infoP2Nickname.text = array[1]["nickname"];
        infoP3Nickname.text = array[2]["nickname"];
        infoP4Nickname.text = array[3]["nickname"];
        infoP5Nickname.text = array[4]["nickname"];
        
        infoP1Money.text = array[0]["money"];
        infoP2Money.text = array[1]["money"];
        infoP3Money.text = array[2]["money"];
        infoP4Money.text = array[3]["money"]; 
        infoP5Money.text = array[4]["money"];
        
        infoP1Marketing.text = array[0]["marketing"]; 
        infoP2Marketing.text = array[1]["marketing"]; 
        infoP3Marketing.text = array[2]["marketing"]; 
        infoP4Marketing.text = array[3]["marketing"];
        infoP5Marketing.text = array[4]["marketing"];
        
        infoP1Research.text = array[0]["research"]; 
        infoP2Research.text = array[1]["research"];  
        infoP3Research.text = array[2]["research"]; 
        infoP4Research.text = array[3]["research"];  
        infoP5Research.text = array[4]["research"];
    }

    public void nextSeason()
    {
        StartCoroutine(getJSON());
    }
}

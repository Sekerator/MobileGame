using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using Random = System.Random;
using UnityEngine.SceneManagement;

public class GlobalParam : MonoBehaviour
{
    public Text materials, money, marketing, research, time;
    private string[] season = {"Зима","Весна","Лето","Осень"};
    private string year = "1900";
    private int thisSeason = 0;
    private float timeRemaining = 3f;
    private string url = "http://mopsnet.tk/game.php";
    private bool allReady = false;
    public GameObject readyPanel, buttons, gameOverPanel;

    public Text winnerNickname;
    private void Awake()
    {
        StartCoroutine(createReady());
        materials.text = "0";
        money.text = "100000";
        marketing.text = "1";
        research.text = "0";
        time.text = season[thisSeason] + " " + year;
    }

    private void nextSeason()
    {
        if (thisSeason == 3)
        {
            thisSeason = 0;
            year = (Convert.ToInt32(year) + 1).ToString();
        }
        else
            thisSeason++;
    }
    
    private void nextSeason_butt()
    {
        gameObject.GetComponent<Bank>().nextSeason();
        gameObject.GetComponent<Marketing>().nextSeason();
        gameObject.GetComponent<Components>().nextSeason();
        gameObject.GetComponent<Assembly>().nextSeason();
        gameObject.GetComponent<Rating>().nextSeason();
        buttons.SetActive(true);
        nextSeason();
        time.text = season[thisSeason] + " " + year;
        
        if(year == "1925")
            gameOver();
    }

    IEnumerator createReady()
    {
        WWWForm add = new WWWForm();
        add.AddField("request", "createReady");
        add.AddField("nickname", PlayerPrefs.GetString("nickname"));
        add.AddField("room_number", PlayerPrefs.GetString("room_number"));
        WWW a = new WWW(url, add);
        yield return a;
        
        if(a.text == "Error")
            Debug.Log(a.text);
    }

    IEnumerator readyNextSeason()
    {
        gameObject.GetComponent<Rating>().nextSeason();
        
        WWWForm add = new WWWForm();
        add.AddField("request", "nextSeason");
        add.AddField("nickname", PlayerPrefs.GetString("nickname"));
        add.AddField("room_number", PlayerPrefs.GetString("room_number"));
        if(thisSeason < 3)
            add.AddField("this_season", season[thisSeason+1]);
        else
            add.AddField("this_season", season[0]);
        WWW a = new WWW(url, add);
        yield return a;

        if (a.text == "Good")
        {
            readyPanel.SetActive(false);
            nextSeason_butt();
        }
        else
        {
            Debug.Log(a.text);
        }
    }

    public void gameOver()
    { 
        buttons.SetActive(false);
        gameOverPanel.SetActive(true);
        
        winnerNickname.text = gameObject.GetComponent<Rating>().infoP1Nickname.text;
    }

    IEnumerator Over()
    {
        WWWForm add = new WWWForm();
        add.AddField("request", "gameOver");
        add.AddField("nickname", PlayerPrefs.GetString("nickname"));
        add.AddField("password", PlayerPrefs.GetString("password"));
        WWW a = new WWW(url, add);
        yield return a;
        
        if(a.text != "Error")
            SceneManager.LoadScene("Menu");
        else
            Debug.Log(a.text);
    }
    
    public void gameOverButt()
    {
        StartCoroutine(Over());
        if(PlayerPrefs.HasKey("room_number"))
            PlayerPrefs.DeleteKey("room_number");
        if (PlayerPrefs.HasKey("marketing"))
            PlayerPrefs.DeleteKey("marketing");
    }
        
    private void FixedUpdate()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            if (readyPanel.activeSelf == true)
            {
                StartCoroutine(readyNextSeason());
            }
            timeRemaining = 3f;
        }
    }

    private void OnApplicationQuit()
    {
        gameOver();
        gameOverButt();
    }
}
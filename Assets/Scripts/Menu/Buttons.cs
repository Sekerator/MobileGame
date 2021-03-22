using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
	public string url = "http://mopsnet.tk/";
	/**
	 * Функция для кнопки играть
	 */
    public void playButt()
	{
		SceneManager.LoadScene("Game");
	}
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
	/**
	 * Функция для кнопки play 
	 */
    public void playButt()
	{
		SceneManager.LoadScene("Game");
	}
}

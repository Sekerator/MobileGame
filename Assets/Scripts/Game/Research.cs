using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Research : MonoBehaviour
{
	public GameObject EngineOne,
		EngineTwo,
		EngineThree,
		ChassisOne,
		ChassisTwo,
		ChassisThree,
		BodyOne,
		BodyTwo,
		BodyThree,
		AssemblyOne,
		AssemblyTwo,
		AssemblyThree;

	public Sprite check;

	public void researchButtons(string researchName)
	{
		if (researchName == "EngineOne")
		{
			PlayerPrefs.SetString("EngineOne", "true");
			EngineOne.GetComponent<Image>().color = Color.white;
		}
		else if (researchName == "EngineTwo")
		{
			PlayerPrefs.SetString("EngineTwo", "true");
			EngineTwo.GetComponent<Image>().color = Color.white;
		}
		else if (researchName == "EngineThree")
		{
			PlayerPrefs.SetString("EngineThree", "true");
			EngineThree.GetComponent<Image>().color = Color.white;
		}
		else if (researchName == "ChassisOne")
		{
			PlayerPrefs.SetString("ChassisOne", "true");
			ChassisOne.GetComponent<Image>().color = Color.white;
		}
		else if (researchName == "ChassisTwo")
		{
			PlayerPrefs.SetString("ChassisTwo", "true");
			ChassisTwo.GetComponent<Image>().color = Color.white;
		}
		else if (researchName == "ChassisThree")
		{
			PlayerPrefs.SetString("ChassisThree", "true");
			ChassisThree.GetComponent<Image>().color = Color.white;
		}
		else if (researchName == "BodyOne")
		{
			PlayerPrefs.SetString("BodyOne", "true");
			BodyOne.GetComponent<Image>().color = Color.white;
		}
		else if (researchName == "BodyTwo")
		{
			PlayerPrefs.SetString("BodyTwo", "true");
			BodyTwo.GetComponent<Image>().color = Color.white;
		}
		else if (researchName == "BodyThree")
		{
			PlayerPrefs.SetString("BodyThree", "true");
			BodyThree.GetComponent<Image>().color = Color.white;
		}
		else if (researchName == "AssemblyOne")
		{
			PlayerPrefs.SetString("AssemblyOne", "true");
			AssemblyOne.GetComponent<Image>().color = Color.white;
		}
		else if (researchName == "AssemblyTwo")
		{
			PlayerPrefs.SetString("AssemblyTwo", "true");
			AssemblyTwo.GetComponent<Image>().color = Color.white;
		}
		else if (researchName == "AssemblyThree")
		{
			PlayerPrefs.SetString("AssemblyThree", "true");
			AssemblyThree.GetComponent<Image>().color = Color.white;
		}
	}
	
	public void nextSeason()
	{
		int a;
	}
}

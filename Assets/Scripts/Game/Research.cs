using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Research : MonoBehaviour
{
	public void researchButtons(string researchName)
	{
		if (researchName == "EngineOne")
		{
			PlayerPrefs.SetString("EngineOne", "true");
		}
		else if (researchName == "EngineTwo")
		{
			PlayerPrefs.SetString("EngineTwo", "true");
		}
		else if (researchName == "EngineThree")
		{
			PlayerPrefs.SetString("EngineThree", "true");
		}
		else if (researchName == "ChassisOne")
		{
			PlayerPrefs.SetString("ChassisOne", "true");
		}
		else if (researchName == "ChassisTwo")
		{
			PlayerPrefs.SetString("ChassisTwo", "true");
		}
		else if (researchName == "ChassisThree")
		{
			PlayerPrefs.SetString("ChassisThree", "true");
		}
		else if (researchName == "BodyOne")
		{
			PlayerPrefs.SetString("BodyOne", "true");
		}
		else if (researchName == "BodyTwo")
		{
			PlayerPrefs.SetString("BodyTwo", "true");
		}
		else if (researchName == "BodyThree")
		{
			PlayerPrefs.SetString("BodyThree", "true");
		}
		else if (researchName == "AssemblyOne")
		{
			PlayerPrefs.SetString("AssemblyOne", "true");
		}
		else if (researchName == "AssemblyTwo")
		{
			PlayerPrefs.SetString("AssemblyTwo", "true");
		}
		else if (researchName == "AssemblyThree")
		{
			PlayerPrefs.SetString("AssemblyThree", "true");
		}
	}
	
	public void nextSeason()
	{
		int a;
	}
}

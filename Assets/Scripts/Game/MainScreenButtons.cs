using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainScreenButtons : MonoBehaviour
{
    public GameObject marketingPanel, assemblyPanel, bankPanel, researchPanel, marketPanel, storagePanel, componentsPanel;

    public void marketingButt()
	{
		marketingPanel.SetActive(true);
	}
	public void assemblyButt()
	{
		assemblyPanel.SetActive(true);
	}
	public void bankButt()
	{
		bankPanel.SetActive(true);
	}
	public void researchButt()
	{
		researchPanel.SetActive(true);
	}
	public void marketButt()
	{
		marketPanel.SetActive(true);
	}
	public void storageButt()
	{
		storagePanel.SetActive(true);
	}
	public void componentsButt()
	{
		componentsPanel.SetActive(true);
	}

	IEnumerator loadingExit()
	{
		WWWForm form = new WWWForm();
		form.AddField("request", "delete_user");
		form.AddField("nickname", PlayerPrefs.GetString("nickname"));
		WWW www = new WWW(PlayerPrefs.GetString("url"), form);
		yield return www;
	}

	private void OnApplicationQuit()
	{
		StartCoroutine(loadingExit());
		PlayerPrefs.DeleteAll();
	}
}

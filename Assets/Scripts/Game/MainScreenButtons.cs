using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainScreenButtons : MonoBehaviour
{
    public GameObject marketingPanel, assemblyPanel, bankPanel, researchPanel, marketPanel, storagePanel, bodyPanel, enginePanel, chassisPanel;

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
	public void bodyButt()
	{
		bodyPanel.SetActive(true);
	}
	public void engineButt()
	{
		enginePanel.SetActive(true);
	}
	public void chassisButt()
	{
		chassisPanel.SetActive(true);
	}
}

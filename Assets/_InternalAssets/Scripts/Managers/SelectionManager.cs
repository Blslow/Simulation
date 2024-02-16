using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : Singleton<SelectionManager>
{
    [SerializeField]
    private TMP_Text nameText;
    [SerializeField]
    private TMP_Text healthText;
    [SerializeField]
    private GameObject selectionPanel;
    [SerializeField]
    private Button deselectButton;

    private AgentController selectedAgent;

    public TMP_Text NameText { get => nameText; }
    public TMP_Text HealthText { get => healthText; }
    public AgentController SelectedAgent
    {
        get => selectedAgent;
        set
        {
            selectedAgent = value;
            NameText.text = selectedAgent.AgentName;
        }
    }

    public Button DeselectButton { get => deselectButton; set => deselectButton = value; }

    public void UpdateHealthText()
    {
        HealthText.text = "Health: " + SelectedAgent.GetComponent<AgentHealth>().HealthPoints;
    }

    public void DisablePanel()
    {
        selectionPanel.SetActive(false);
    }
    public void EnablePanel()
    {
        selectionPanel.SetActive(true); 
    }
}

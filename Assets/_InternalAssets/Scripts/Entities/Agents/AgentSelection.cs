using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSelection : MonoBehaviour
{
    [SerializeField]
    private Material agentBaseMaterial;
    [SerializeField]
    private Material agentHoveredMaterial;
    [SerializeField]
    private Material agentSelectedMaterial;
    [SerializeField]
    private MeshRenderer agentMeshRenderer;

    private bool isSelected = false;

    private void OnMouseEnter()
    {
        if (isSelected)
            return;

        agentMeshRenderer.material = agentHoveredMaterial;
    }
    private void OnMouseExit()
    {
        if (isSelected)
            return;

        agentMeshRenderer.material = agentBaseMaterial;
    }
    private void OnMouseDown()
    {
        if (isSelected)
        {
            Deselect();
            return;
        }

        if (SelectionManager.Instance.SelectedAgent != null)
        {
            SelectionManager.Instance.SelectedAgent.GetComponent<AgentSelection>().Deselect();
        }
        SelectionManager.Instance.HealthText.text = "Health: " + GetComponent<AgentHealth>().HealthPoints;

        agentMeshRenderer.material = agentSelectedMaterial;
        isSelected = true;

        GetComponent<AgentHealth>().OnHit.AddListener(SelectionManager.Instance.UpdateHealthText);
        GetComponent<AgentHealth>().OnDeath.AddListener(Deselect);

        SelectionManager.Instance.SelectedAgent = GetComponent<AgentController>();
        SelectionManager.Instance.EnablePanel();

        SelectionManager.Instance.DeselectButton.onClick.AddListener(Deselect);
    }
    public void Deselect()
    {
        agentMeshRenderer.material = agentBaseMaterial;
        isSelected = false;

        GetComponent<AgentHealth>().OnHit.RemoveListener(SelectionManager.Instance.UpdateHealthText);
        GetComponent<AgentHealth>().OnDeath.RemoveListener(Deselect);

        //SelectionManager.Instance.SelectedAgent = null;
        SelectionManager.Instance.DisablePanel();

        SelectionManager.Instance.DeselectButton.onClick.RemoveListener(Deselect);
    }
}

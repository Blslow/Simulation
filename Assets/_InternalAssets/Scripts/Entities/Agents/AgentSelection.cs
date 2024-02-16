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
        agentMeshRenderer.material = agentSelectedMaterial;

        isSelected = true;
    }
    public void Deselect()
    {
        isSelected = false;

        agentMeshRenderer.material = agentBaseMaterial;
    }
}

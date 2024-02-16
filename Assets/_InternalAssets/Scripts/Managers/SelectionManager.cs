using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectionManager : Singleton<SelectionManager>
{
    [SerializeField]
    private TMP_Text nameText;
    [SerializeField]
    private TMP_Text healthText;
}

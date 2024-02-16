using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CountToHundred : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textField;

    public void DoMath()
    {
        for (int i = 1; i <= 100; i++)
        {
            int result = i;
            if (result == 1)
                textField.text = result.ToString();
            else if (result % 3 == 0 && result % 5 == 0)
                textField.text += "MarkoPolo";
            else if (result % 3 == 0)
                textField.text += "Marko";
            else if (result % 5 == 0)
                textField.text += "Polo";
            else
                textField.text += result.ToString();

            textField.text += "\n";
        }
    }
}

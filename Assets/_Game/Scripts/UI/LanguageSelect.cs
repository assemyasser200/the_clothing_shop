using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using I2.Loc;

public class LanguageSelect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI arabicBtnTextUI;
    private string arabicBtnText;

    private void Start()
    {
        // arabicBtnTextUI.text = I2.Loc.RTLFixer.Fix(arabicBtnTextUI.text);
    }

    public void RTLFix(TextMeshProUGUI textUI)
    {
        if (string.IsNullOrEmpty(arabicBtnText))
            arabicBtnText = textUI.text;

        Debug.Log(arabicBtnText);

        // textUI.isRightToLeftText = true;
        textUI.text = I2.Loc.RTLFixer.Fix(arabicBtnText);

        Debug.Log(textUI.text);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text[] pageTexts; // Assign in the inspector, each text corresponds to a page

    // Call this method when a page is collected
    public void UpdatePageUI(PageType pageType, bool collected)
    {
        string message = collected ? "Collected! Press {0} to activate." : "Not Collected";

        switch (pageType)
        {
            case PageType.Physics:
                pageTexts[0].text = string.Format(message, "1");
                break;
            case PageType.Chemistry:
                pageTexts[1].text = string.Format(message, "2");
                break;
            case PageType.Math:
                pageTexts[2].text = string.Format(message, "3");
                break;
                // Add cases for other PageTypes as needed
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour


{

    private Dictionary<PageType, bool> collectedPages = new Dictionary<PageType, bool>();
    void Start()
    {
        // Initialize all page types as not collected
        foreach (PageType page in System.Enum.GetValues(typeof(PageType)))
        {
            collectedPages.Add(page, false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && collectedPages[PageType.Physics]) ActivatePhysicsPower();
        if (Input.GetKeyDown(KeyCode.Alpha2) && collectedPages[PageType.Chemistry]) ActivateChemistryPower();
        // Add checks for other powers
    }

    public void CollectPage(PageType pageType)
    {
        if (collectedPages.ContainsKey(pageType))
        {
            collectedPages[pageType] = true;
            UpdateUI();
        }
    }

    void ActivatePhysicsPower()
    {
        // Implement physics power-up activation
    }

    void ActivateChemistryPower()
    {
        // Implement chemistry power-up activation
    }

    void UpdateUI()
    {
        // Update the UI to reflect collected pages and available powers
    }
}

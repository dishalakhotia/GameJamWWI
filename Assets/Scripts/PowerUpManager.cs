using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{
    public PageConfiguration levelPages;
    private Dictionary<int, GameObject> keyToPageMap = new Dictionary<int, GameObject>();
    private Dictionary<PageType, bool> collectedPages = new Dictionary<PageType, bool>();
    public GameObject[] pageUIElements;
    public UIManager uiManager;

    void Start()
    {
        SetupLevelPages();

        collectedPages.Add(PageType.Physics, false);
        collectedPages.Add(PageType.Pop, false);
        collectedPages.Add(PageType.Chemistry, false);
        collectedPages.Add(PageType.Math, false);
        collectedPages.Add(PageType.MarvelComic, false);
        collectedPages.Add(PageType.DCComic, false);
        collectedPages.Add(PageType.Jazz, false);
        collectedPages.Add(PageType.Rock, false);
        collectedPages.Add(PageType.AnimePage, false);

    }

    void SetupLevelPages()
    {
        keyToPageMap.Clear();
        for (int i = 0; i < levelPages.pagesForThisLevel.Length; i++)
        {
            // Assuming keys 1, 2, 3 correspond to indexes 0, 1, 2
            keyToPageMap.Add(i + 1, levelPages.pagesForThisLevel[i]);
        }
    }
    /*private void UpdatePageUI(PageType collectedPage)
    {
        int index = -1;
        // Find the index for the collected page based on current level configuration
        for (int i = 0; i < levelPages.pagesForThisLevel.Length; i++)
        {
            if (levelPages.pagesForThisLevel[i] == collectedPage)
            {
                index = i;
                break;
            }
        }
        if (index != -1)
        {
            // Activate the UI element and update its text or appearance
            pageUIElements[index].SetActive(true);
            Debug.Log("UI UPDATED");
            // Assuming each UI element has a Text component to indicate how to activate the power
            pageUIElements[index].GetComponentInChildren<Text>().text = $"Press {index + 1} to activate {collectedPage}";
        }
    }*/
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { ActivatePower(keyToPageMap[1]); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { ActivatePower(keyToPageMap[2]); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { ActivatePower(keyToPageMap[3]); }
    }

    public void CollectPage(PageType pageType)
    {
        Debug.Log(pageType + " check is the colepages containts the given key: " + collectedPages.ContainsKey(pageType));
        if (collectedPages.ContainsKey(pageType))
        {
            collectedPages[pageType] = true;
            Debug.Log("Page Collected");
            UpdateUI();
      
            Debug.Log("UI updated");
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

    void ActivatePower(GameObject type)
    {
        // Check if the page has been collected and activate the power
    }

    void UpdateUI()
    {
        // Update the UI to reflect collected pages and available powers
    }
}

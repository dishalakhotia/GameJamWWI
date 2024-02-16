using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageCollector : MonoBehaviour
{
    private PageAttributes currentPage;

    public void CollectPage(PageAttributes page)
    {
        currentPage = page;
        // Optional: Trigger VFX or UI update to show the collected page.
    }

    // Call this method to apply the page's effect.
    public void UsePage()
    {
        // Instantiate the VFX at the desired location.
        if (currentPage.vfxPrefab != null)
        {
            Instantiate(currentPage.vfxPrefab, transform.position, Quaternion.identity);
        }

        // Apply damage or motion based on the page's attributes.
        // This might involve adjusting the player's attack logic to use currentPage.damage and currentPage.motionPattern.
    }
}

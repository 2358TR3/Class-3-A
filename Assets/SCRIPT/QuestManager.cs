using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public Image horizontalProgressBar;
    public GameObject winningCanvas;

    [SerializeField] private int totalItems = 5;
    private int itemsCollected = 0;

    private bool isQuestActive = false;
    private bool hasTalkedToNPC = false; // Tracks if the player has talked to the NPC

    private void Start()
    {
        if (horizontalProgressBar != null)
            horizontalProgressBar.gameObject.SetActive(false);

        if (winningCanvas != null)
            winningCanvas.SetActive(false);
    }

    // Called when the player interacts with the NPC
    public void TalkToNPC()
    {
        hasTalkedToNPC = true;
        ActivateQuest();
        Debug.Log("Player has talked to the NPC. Quest is now active!");
    }

    public void ActivateQuest()
    {
        if (horizontalProgressBar == null) return;

        isQuestActive = true;
        itemsCollected = 0;
        horizontalProgressBar.fillAmount = 0;
        horizontalProgressBar.gameObject.SetActive(true);
        Debug.Log("Quest activated: Find the missing items!");
    }

    public bool IsQuestActive()
    {
        return isQuestActive;
    }

    public void CollectItem()
    {
        if (!hasTalkedToNPC)
        {
            Debug.Log("You must talk to the NPC before collecting items.");
            return;
        }

        if (!isQuestActive)
        {
            Debug.Log("The quest is not active yet.");
            return;
        }

        itemsCollected++;
        float progress = (float)itemsCollected / totalItems;
        horizontalProgressBar.fillAmount = progress;

        Debug.Log($"Items collected: {itemsCollected}/{totalItems}");

        if (itemsCollected >= totalItems)
        {
            CompleteQuest();
        }
    }

    public bool AreAllItemsCollected()
    {
        return itemsCollected >= totalItems;
    }

    private void CompleteQuest()
    {
        Debug.Log("Quest complete! All items collected.");
        isQuestActive = false;

        if (horizontalProgressBar != null)
            horizontalProgressBar.gameObject.SetActive(false);

        ShowWinningScreen();
    }

    private void ShowWinningScreen()
    {
        if (winningCanvas != null)
        {
            winningCanvas.SetActive(true); // Show the winning screen
            StartCoroutine(HideWinningScreenAfterDelay(3f)); // Hide after 5 seconds
        }
    }

    // Coroutine to hide the winning screen after a delay
    private IEnumerator HideWinningScreenAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified time
        if (winningCanvas != null)
            winningCanvas.SetActive(false); // Hide the winning screen
    }
}

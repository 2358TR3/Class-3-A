
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public int trashCount = 0; // Count of collected trash
    public Text trashCountText; // Reference to the UI Text component

    public void CollectTrash()
    {
        trashCount++;
        UpdateTrashUI();
    }

    private void UpdateTrashUI()
    {
        if (trashCountText != null)
        {
            trashCountText.text = "Trash Collected: " + trashCount;
        }
    }
}


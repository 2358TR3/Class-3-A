using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest2 : MonoBehaviour
{
    public int totalItems = 5; // Total items to collect
    private int itemsDestroyed = 0; // Counter for collected items

    public void DestroyedItem()
    {
        itemsDestroyed++;
        Debug.Log("Items Destroyed: " + itemsDestroyed + "/" + totalItems);

        if (itemsDestroyed >= totalItems)
        {
            CompleteQuest();
        }
    }

    private void CompleteQuest()
    {
        Debug.Log("Quest Complete! You collected all the items.");
        // Add additional logic here, like showing a completion screen or rewards
    }
}


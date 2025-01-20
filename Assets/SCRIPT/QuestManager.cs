using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    [System.Serializable]
    public class Quest
    {
        public string description;
        public bool requiresTrashCollection;
        public int trashRequired;
    }

    public Text questText;
    public List<Quest> quests;
    private int currentQuestIndex = 0;
    private int trashCollected = 0;

    void Start()
    {
        UpdateQuestText();
    }

    void UpdateQuestText()
    {
        if (questText != null && currentQuestIndex < quests.Count)
        {
            Quest currentQuest = quests[currentQuestIndex];
            questText.text = currentQuest.description;

            if (currentQuest.requiresTrashCollection)
            {
                questText.text += $"\nTrash Collected: {trashCollected}/{currentQuest.trashRequired}";
            }
        }
        else if (questText != null)
        {
            questText.text = "All quests completed! Congratulations!";
        }
    }

    public void CollectTrash()
    {
        if (currentQuestIndex < quests.Count && quests[currentQuestIndex].requiresTrashCollection)
        {
            trashCollected++;
            UpdateQuestText();

            if (trashCollected >= quests[currentQuestIndex].trashRequired)
            {
                CompleteCurrentQuest();
            }
        }
    }

    public void CompleteCurrentQuest()
    {
        if (currentQuestIndex < quests.Count)
        {
            currentQuestIndex++;
            trashCollected = 0; // Reset trash count for the next quest
            UpdateQuestText();
        }
        else
        {
            Debug.Log("All quests completed.");
        }
    }
}

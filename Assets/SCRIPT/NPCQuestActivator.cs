using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCQuestActivator : MonoBehaviour
{
    public QuestManager questManager; // Reference to the QuestManager

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided with NPC. Quest activated!");
            questManager.TalkToNPC(); // Start the quest
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogBox;
    private bool isPlayerNearby = false;

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            ShowDialog();
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            HideDialog();
        }
    }

    private void ShowDialog()
    {
        if (dialogBox != null)
        {
            dialogBox.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Dialog box is not assigned.");
        }
    }

    private void HideDialog()
    {
        if (dialogBox != null)
        {
            dialogBox.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Dialog box is not assigned.");
        }
    }
}

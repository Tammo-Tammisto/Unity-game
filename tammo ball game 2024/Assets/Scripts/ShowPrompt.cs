using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPrompt : MonoBehaviour
{
    public Canvas EPromptCanvas;
    public Canvas TutorialCanvas;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            EPromptCanvas.enabled = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            EPromptCanvas.enabled = false;
            TutorialCanvas.enabled = false;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(Input.GetKey(KeyCode.E))
            {
                Debug.Log("E key pressed");
                EPromptCanvas.enabled = false;
                TutorialCanvas.enabled = true;
            }
            if(Input.GetKey(KeyCode.X))
            {
                TutorialCanvas.enabled = false;
                EPromptCanvas.enabled = true;
            }
        }
    }
}

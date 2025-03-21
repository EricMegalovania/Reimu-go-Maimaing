using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public DialogueLine[] dialogues;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueManager.StartDialogue(dialogues);
        }
    }
}
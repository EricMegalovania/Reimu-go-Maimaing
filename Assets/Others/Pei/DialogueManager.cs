using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DialogueLine
{
    public string characterName;  // 角色名字
    public Sprite characterImage; // 角色图像
    public string sentence;       // 对话内容
}

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;  // 对话框面板
    public Text nameText;             // 角色名字 UI
    public Text dialogueText;         // 对话文本 UI
    public Image characterImage;      // 角色图像 UI
    public Button nextButton;         // "下一句" 按钮

    private System.Collections.Generic.Queue<DialogueLine> dialogueQueue = new System.Collections.Generic.Queue<DialogueLine>();

    void Start()
    {
        dialoguePanel.SetActive(false);
        nextButton.onClick.AddListener(DisplayNextSentence);
    }

    public void StartDialogue(DialogueLine[] dialogues)
    {
        Time.timeScale = 0f; // 暂停游戏
        dialoguePanel.SetActive(true);
        dialogueQueue.Clear();

        foreach (DialogueLine line in dialogues)
        {
            dialogueQueue.Enqueue(line);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine line = dialogueQueue.Dequeue();
        nameText.text = line.characterName;
        dialogueText.text = line.sentence;
        characterImage.sprite = line.characterImage;
    }

    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        Time.timeScale = 1f; // 恢复游戏
    }
}

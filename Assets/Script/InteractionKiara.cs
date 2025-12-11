using TMPro;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.UI;

public class InteractionKiara : MonoBehaviour
{
    public InteractionNPC KiaraInt;
    public GameObject dialoguePanel;
    public TMP_Text talkText, nameText;
    public Image profileImage;

    private int dialogueIndex;
    private bool istyping, isActiveDialogue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool CanInteract()
    {
        return !isActiveDialogue;
    }

    public void Interact()
    {
        if (KiaraInt == null)
            return;
        if (isActiveDialogue)
        {
            NextLine();
        }
        else
        {
            StartDialouge();
        }

    }
    void StartDialouge()
    {
        isActiveDialogue = true;
        dialogueIndex = 0;
            nameText.SetText(KiaraInt.npcName);
            profileImage.sprite = KiaraInt.profile;
            dialoguePanel.SetActive(true);
            StartCoroutine(TypeLine());
        

    }
    void NextLine()
    {
        if (istyping)
        {
            StopAllCoroutines();
            talkText.SetText(KiaraInt.dialogueLines[dialogueIndex]);
            istyping = false;
        }
        else
        {
            dialogueIndex++;
            if (dialogueIndex < KiaraInt.dialogueLines.Length)
            {
                StartCoroutine(TypeLine());
            }
            else
            {
                isActiveDialogue = false;
                dialoguePanel.SetActive(false);
            }
        }
    }
    System.Collections.IEnumerator TypeLine()
    {
        istyping = true;
        talkText.SetText("");
        foreach (char c in KiaraInt.dialogueLines[dialogueIndex].ToCharArray())
        {
            talkText.text += c;
            yield return new WaitForSeconds(0.02f);
        }
        istyping = false;
    }
    public void EndDialouge()
    {
        StopAllCoroutines();
        isActiveDialogue = false;
        talkText.SetText("");
        dialoguePanel.SetActive(false);
        
    }
}

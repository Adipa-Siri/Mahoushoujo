using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.UI;

public class InteractionKiara : MonoBehaviour,Interactable
{
    public InteractionNPC KiaraInt;
    public GameObject dialoguePanel;
    public TMP_Text talkText, nameText;
    public Image profileImage;
    public bool destroy = true;
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
        destroy = false;
        
        
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
        else if (++dialogueIndex < KiaraInt.dialogueLines.Length)
        {
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialouge();
        }

    }
    IEnumerator TypeLine()
    {
        istyping = true;
            talkText.SetText("");
            foreach (char letter in KiaraInt.dialogueLines[dialogueIndex])
            {
                talkText.text += letter;
                yield return new WaitForSeconds(KiaraInt.dialogSpeed);
            }
            istyping = false;
            if (KiaraInt.autoProgress.Length > dialogueIndex && KiaraInt.autoProgress[dialogueIndex])
            {
                yield return new WaitForSeconds(KiaraInt.autoProgressDelay);
                NextLine();

            }
        }
        
    public void EndDialouge()
    {
        StopAllCoroutines();
            isActiveDialogue = false;
            talkText.SetText("");
            dialoguePanel.SetActive(false);
            return;
        
        
    }
}

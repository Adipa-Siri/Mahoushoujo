using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCScript : MonoBehaviour, Interaction
{
    public InteractionNPC Dialouge;
    public InteractionNPC complete;
    public GameObject dialogBox;
    public GameObject irisPanel;
    public TMP_Text dialogText , Textname;
    public Image pfp;
    public knifeManage iris;

    private int DialogIndex = 0;
    public bool isActive;
    private bool isTyping;
    private int requiredIris = 3;
   
    


    public bool CanInteract()
    {
        return !isActive;
    }

    public void Interact()
    {
        if (Dialouge == null)
        return;
        if (isActive)
        {
            Next();
        }
        else
        {
            StartDialouge();
        }
    }
    void StartDialouge()
    {
        isActive = true;
        DialogIndex = 0;
        if (iris.iris < requiredIris) //first time dialouge
        { 
        Textname.SetText(Dialouge.npcName);
        pfp.sprite = Dialouge.profile;
        dialogBox.SetActive(true);
        
        }
        if (iris.iris >= requiredIris)//completed dialouge
        {
            Textname.SetText(complete.npcName);
            pfp.sprite = complete.profile;
            dialogBox.SetActive(true);
            irisPanel.SetActive(false);
        }

        StartCoroutine(Type());
    }
    public void EndDialouge()
    {
        StopAllCoroutines();
        if (iris.iris < requiredIris)
        {
            irisPanel.SetActive(true);
        }
        isActive = false;
        dialogBox.SetActive(false);
        dialogText.SetText("");
    }

    void Next()
    {
        if (isTyping)
        {
            //skip typing effect
            StopAllCoroutines();
            if (iris.iris < requiredIris)
            {
                dialogText.SetText(Dialouge.dialogueLines[DialogIndex]);
                isTyping = false;
            }
            if (iris.iris >= requiredIris)
            {
                dialogText.SetText(complete.dialogueLines[DialogIndex]);
                isTyping = false;
            }
            return;
        }
        else if (++DialogIndex < Dialouge.dialogueLines.Length - 1)
        {
           
            StartCoroutine(Type());
        }
        else
        {
            EndDialouge();
        }


    }
    IEnumerator Type()
    {
        isTyping = true;
        dialogText.SetText("");
        if (iris.iris < requiredIris)
        {
            foreach (char letter in Dialouge.dialogueLines[DialogIndex])
            {
                dialogText.text += letter;
                yield return new WaitForSeconds(Dialouge.dialogSpeed);
            }
            isTyping = false;
            //auto progress
            if (Dialouge.autoProgress.Length > DialogIndex && Dialouge.autoProgress[DialogIndex])
            {
                yield return new WaitForSeconds(Dialouge.autoProgressDelay);
                Next();
            }
        }
        else if (iris.iris >= requiredIris)
        {
            foreach (char letter in complete.dialogueLines[DialogIndex])
            {
                dialogText.text += letter;
                yield return new WaitForSeconds(complete.dialogSpeed);
            }
            isTyping = false;
            //auto progress
            if (complete.autoProgress.Length > DialogIndex && complete.autoProgress[DialogIndex])
            {
                yield return new WaitForSeconds(complete.autoProgressDelay);
                Next();
            }
        }
    }



}

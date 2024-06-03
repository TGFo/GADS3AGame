using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueUI : MonoBehaviour
{
    public TMP_Text NPCDialogueText;
    public DialogueManager DialogueManager;
    public Dialogue currentDialogue;
    public Dialogue nextDialogue;
    public string currentDialogueTrigger;
    public string nextDialogueTrigger;
    public Dialogue choiceDialogue1;
    public Dialogue choiceDialogue2;
    public string firstLineTrigger;
    public GameObject ButtonChoice1;
    public GameObject ButtonChoice2;
    public TMP_Text choiceText1;
    public TMP_Text choiceText2;
    public string nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        currentDialogue = DialogueManager.GetNextLine(firstLineTrigger);
        NPCDialogueText.text = currentDialogue.line;
        nextDialogue = DialogueManager.GetNextLine(currentDialogue.nextLineTrigger);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ProgressDialogue()
    {
        if(currentDialogue.nextLineTrigger == "end")
        {
            return;
        }
        if(currentDialogue.nextLineTrigger == "chapterEnd")
        {
            SceneManager.LoadScene(nextLevel);
            return;
        }
        if(currentDialogue.nextLineTrigger == "chapterFail")
        {
            SceneManager.LoadScene("MainMenu");
            return;
        }
        if(nextDialogue.choice == false)
        {
            NPCDialogueText.text = nextDialogue.line;
            currentDialogue = nextDialogue;
            nextDialogue = DialogueManager.GetNextLine(currentDialogue.nextLineTrigger);
        }
        else
        {
            choiceDialogue1 = nextDialogue;
            choiceDialogue2 = DialogueManager.GetNextLine(choiceDialogue1.animTrigger);
            ButtonChoice1.SetActive(true);
            ButtonChoice2.SetActive(true);
            choiceText1.text = choiceDialogue1.line;
            choiceText2.text = choiceDialogue2.line;
        }
        //currentDialogueTrigger = currentDialogue.lineTrigger;
        //nextDialogueTrigger = nextDialogue.lineTrigger;
    }
    public void Choice1()
    {
        currentDialogue = choiceDialogue1;
        ButtonChoice1.SetActive(false);
        ButtonChoice2.SetActive(false);
        nextDialogue = DialogueManager.GetNextLine(choiceDialogue1.nextLineTrigger);
        ProgressDialogue();
    }
    public void Choice2()
    {
        currentDialogue = choiceDialogue2;
        ButtonChoice1.SetActive(false);
        ButtonChoice2.SetActive(false);
        nextDialogue = DialogueManager.GetNextLine(choiceDialogue2.nextLineTrigger);
        ProgressDialogue();
    }
}

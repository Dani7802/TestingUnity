using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

#if __DEBUG_AVAILABLE__

using UnityEditor;

#endif

public class GameManager : MonoBehaviour
{
    public Transform[] dialogCommon;
    public Transform[] dialogCharacters;
    public Transform dialogText;

    [System.Serializable]
    public struct DialogData
    {
        public int character;
        public string text;
    }

    public DialogData[] dialogsData;

    bool showingDialogue;

    TextMeshPro dialogTextC;

    int dialogIndex;

    KeyCode[] debugKey = { KeyCode.S, KeyCode.T, KeyCode.A, KeyCode.R };
    int debugKeyProgress = 0;

    // Start is called before the first frame update
    void Start()
    {
        showingDialogue = false;

        dialogTextC = dialogText.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        #if __DEBUG_AVAILABLE__
        if(Swtiches.debugmode && Swtiches.debugDialogs)
        {
            if(Input.GetKeyDown(KeyCode.k))
            {
                showingDialogue = true;
                dialogIndex = 0;
            }

            if(Input.)
            {

            }
        }
        #endif

        if(showingDialogue)
        {
            for(int i = 0; i < dialogCommon.Length; i++)
            {
                dialogCommon[i].gameObject.SetActive(true);
            }

            for (int i = 0; i < dialogCharacters.Length; i++)
            {
                dialogCharacters[i].gameObject.SetActive(false);
            }

            int character = dialogsData[dialogIndex].character;
            string text = dialogsData[dialogIndex].text;

            dialogCharacters[character].gameObject.SetActive(true);
            dialogTextC.text = text;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                showingDialogue = false;
            }
        }
        else
        {
            for (int i = 0; i < dialogCommon.Length; i++)
            {
                dialogCommon[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < dialogCharacters.Length; i++)
            {
                dialogCharacters[i].gameObject.SetActive(false);
            }
        }

        #if __DEBUG_AVAILABLE__
        if(!Swtiches.debugmode)
        {
            if(Input.GetKeyDown(debugKey[debugKeyProgress]))
            {
                debugKeyProgress++;
                if (Input.GetKeyDown(debugKey[debugKeyProgress]))
                {
                    Swtiches.debugmode = true;
                    Debug.Log("Debug mode on");
                }
            }
        }
        #endif
    }
    public void OnTriggerDialog(int index)
    {
        showingDialogue = true;
        dialogIndex = index;
    }
}

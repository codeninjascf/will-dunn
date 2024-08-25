using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Serializable]
    public struct Interaction
    {
        public GameObject dialogue;
        public TextMeshProUGUI

        public int currrentMessage;
        public string[] messages;

        public Interaction[] interactions;

        private Interaction _activeInteraction;
    }

    void NextMessage
    {
        if (_activeInteraction.dialogue == null) return;

        if (_activeInteraction.currrentMessage >= _activeInteraction.messages.Length)
        {
            _activeInteraction.dialogue.SetActive(false);
            return;
        }
        _activeInteraction.mainText.text =
            _activeInteraction.messages[_activeInteraction.currrentMessage];
        _activeInteraction.currrentMessage++;
    }

    void Start()

    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

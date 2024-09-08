using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStarter : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public int interaction;

    private bool _activated;
    void Start()
    {
        _activated = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (_activated || !other.CompareTag("Player")) return; 

        _activated = true;
        dialogueManager.StartInteraction(interaction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

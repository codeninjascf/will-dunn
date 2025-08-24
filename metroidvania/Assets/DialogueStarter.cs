using System;
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

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("yes");
       if(_activated || other.gameObject.tag != "Player") return;
        _activated = true;
        dialogueManager.StartInteraction(interaction);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

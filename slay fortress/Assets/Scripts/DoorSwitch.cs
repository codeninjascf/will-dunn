using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    public GameObject enabledObject;
    public GameObject disabledObject;

    public AudioClip enabledSound;
    public AudioClip disabledSound;

    private AudioSource _audioSource;
    void Start()
    {
        enabledObject.SetActive(false);
      disabledObject.SetActive(true);
        SwitchEnabled = false;

        _audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerExit(Collider other)
    {
        enabledObject.SetActive(false);
        disabledObject.SetActive(true);
        SwitchEnabled = false;

        _audioSource.clip = disabledSound;
        _audioSource.Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        enabledObject.SetActive(true);
        disabledObject.SetActive(false);

        SwitchEnabled = true;

        _audioSource.clip = enabledSound;
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool SwitchEnabled
    {
        get;
        private set;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    public GameObject enabledObject;
    public GameObject disabledObject;
    void Start()
    {
        enabledObject.SetActive(false);
      disabledObject.SetActive(true);
        SwitchEnabled = false;
    }
    private void OnTriggerExit(Collider other)
    {
        enabledObject.SetActive(false);
        disabledObject.SetActive(true);
        SwitchEnabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        enabledObject.SetActive(true);
        disabledObject.SetActive(false);

        SwitchEnabled = true;
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

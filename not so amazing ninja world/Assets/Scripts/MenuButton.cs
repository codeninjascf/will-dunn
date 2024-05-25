using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public int previousLevelNumber;
    public string levelName;
    
    public Sprite unlockedSprite;
    public Sprite lockedSprite;
    private bool _locked;
    private Image _image; 
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

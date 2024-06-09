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
       _image = GetComponent<Image>();

       if (previousLevelNumber == 0 || PlayerPrefs.GetInt("Level" + previousLevelNumber + 
       "_Complete", 0) ==1 ) 
       {
           _locked = false;
           _image.sprite = unlockedSprite;
       }
       else
       {
           _locked = true;
           _image.sprite = lockedSprite;
       }
    }

    public void OnClick()
    {
        if (_locked) return;

        SceneManager.LoadScene(levelName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

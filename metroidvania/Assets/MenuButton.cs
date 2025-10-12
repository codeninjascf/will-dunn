using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
public class MenuButton : MonoBehaviour
{
    public int previousLevelNumber;
    public string levelName;
    public Sprite unlockedSprite;
    public Sprite lockedSprite;

    private bool _locked;
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();

        if(previousLevelNumber == 0 || LevelCompleteMenu.GetInt("levelNumber")
        + previousLevelNumber + "_Complete", 0) == 1)
            {
                _locked = false;
                _image.sprite = unlockedSprite;
            }
        
        
    }
}

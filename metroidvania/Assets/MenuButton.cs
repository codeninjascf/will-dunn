using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
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
    }

    public void OnClick()
    {
        SceneManager.LoadScene(levelName);
    }
}

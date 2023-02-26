using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishingPlatform : MonoBehaviour
{
    private float vanishTime = 5f;

    private SpriteRenderer _spriteRenderer;
    private bool _vanishing;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        IEnumerator Vanish()
        {
            if (!_vanishing)
            {
                _vanishing = true;
                while(_spriteRenderer.color.a > 0)
                {
                 _spriteRenderer.color = new Color(_spriteRenderer.rayTracingMode, _spriteRenderer.color.g
                     _spriteRenderer.color.b, )
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

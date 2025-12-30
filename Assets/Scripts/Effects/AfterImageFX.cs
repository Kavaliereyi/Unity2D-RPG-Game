using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImageFX : MonoBehaviour
{
    private SpriteRenderer sr;
    private float colorLoseRate;

    public void SetupAfterImage(float _losingSpeed, Sprite _spriteImage, Color _color)
    {
        sr = GetComponent<SpriteRenderer>();

        sr.sprite = _spriteImage;
        colorLoseRate = _losingSpeed;
        sr.color = _color;
    }

    private void Update()
    {
        float alpha = sr.color.a - colorLoseRate * Time.deltaTime;
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, alpha);
        
        if (sr.color.a <= 0)
            Destroy(gameObject);

    }
}

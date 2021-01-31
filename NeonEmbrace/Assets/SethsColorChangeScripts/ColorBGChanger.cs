using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBGChanger : MonoBehaviour
{
    public SpriteRenderer SR;

    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    public void ColorShift(Colors color)
    {
        switch (color)
        {
            case Colors.Red:
                {
                    SR.color = new Color(100f, 4.3f, 4.3f);
                    break;
                }
            case Colors.Green:
                {
                    SR.color = new Color(11f, 212f, 30);
                    break;
                }
            case Colors.Blue:
                {
                    SR.color = new Color(0.0f,11f,255f);
                    break;
                }
            case Colors.Pink:
                {
                    SR.color = new Color(255f, 0f, 219f);
                    break;
                }
        }
    }
}

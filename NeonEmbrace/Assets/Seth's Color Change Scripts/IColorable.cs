using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Written By Seth DeZwart
 * Interface for color operation standardization
 */
public interface IColorable
{
    // Should be used to turn off a color
    void ColorSwapOff();

    // Should be used to turn on a color
    void ColorSwapOn();
}

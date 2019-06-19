using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionFunctions
{
    public static float ToAngle(this Vector2 dir)
    {
        return -Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
    }
}

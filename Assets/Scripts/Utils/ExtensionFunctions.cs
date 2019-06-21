using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class ExtensionFunctions
{
    public static float ToAngle(this Vector2 dir)
    {
        return -Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
    }

    public static T RandomElement<T>(this IEnumerable<T> input)
    {
        var a = input.ElementAt(Random.Range(0,input.Count()));
        return (T)System.Convert.ChangeType(a, typeof(T));
    }
}

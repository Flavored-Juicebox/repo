using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class tools
{
    #region distance
    public static float Distance(Vector2 a, Vector2 b)
    {
        return Mathf.Sqrt(Mathf.Pow(b.x - a.x, 2f) + Mathf.Pow(b.y - a.y, 2f));
    }
    public static float Distance(Vector3 a, Vector3 b)
    {
        return Mathf.Sqrt(Mathf.Pow(b.x - a.x, 2f) + Mathf.Pow(b.y - a.y, 2f) + Mathf.Pow(b.z - a.z, 2f));
    }
    public static float Distance(Vector2 a, Vector2 b, out float c)
    {
        c = Mathf.Sqrt(Mathf.Pow(b.x - a.x, 2f) + Mathf.Pow(b.y - a.y, 2f));
        return c;
    }
    public static float Distance(Vector3 a, Vector3 b, out float c)
    {
        c = Mathf.Sqrt(Mathf.Pow(b.x - a.x, 2f) + Mathf.Pow(b.y - a.y, 2f) + Mathf.Pow(b.z - a.z, 2f));
        return c;
    }

    #endregion


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static int IntRepeat(this int position, int maxValue)
    {
        while (position>=maxValue)
        {
            position -= maxValue;
        }

        while (position < 0)
        {
            position += maxValue;
        }

        return position;
    }
}

using System;
using UnityEngine;

abstract public class RawCSVLoader {

    private static readonly string[] FieldSeperator = { "\",\"" };

    public static string[][] LoadCSV(TextAsset textAsset)
    {
        string[] lines = textAsset.text.Split('\n');

        string[][] result = new string[lines.Length][];

        for (int i = 0; i < lines.Length; i++)
        {
            result[i] = lines[i].Trim().Trim('"').Split(FieldSeperator, StringSplitOptions.None);
        }

        return result;
    }
}
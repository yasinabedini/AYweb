﻿namespace AYweb.Core.Convertors;

public static class StringConvertToStringArray
{
    public static string[] CommaSeparator(string text)
    {
        var textArray = text.Split("،");
        return textArray;
    }
}
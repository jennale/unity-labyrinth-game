using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelperExtensions {
    public static string ToTimestamp(this float scoreFloat)
    {
        var milliseconds = (scoreFloat * 100 % 60).ToString("00");
        var seconds = (Math.Floor(scoreFloat % 60)).ToString("00:");
        var minutes = (Math.Floor(scoreFloat / 60) % 60).ToString("00:");
        //var hours = (Math.Floor(scoreFloat / 60 / 60)).ToString("00:");

        return minutes + seconds + milliseconds;
    }
}
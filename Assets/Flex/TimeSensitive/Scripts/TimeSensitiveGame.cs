using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flex.TimeSensitive
{
    enum ActivityType { Daily, Weekly, Battlepass, Event };
    enum TimeType { Hour, Day, Week };

    [System.Serializable]
    internal class TimeSensitiveActivity
    {
        [SerializeField] internal string ActivityTitle;
        [SerializeField] internal ActivityType ActivityType;
        [SerializeField] internal int TimeLeft;
        [SerializeField] internal TimeType TimeType;
        [SerializeField] internal Vector2 Battlepass;
        [SerializeField] internal string Description;
    }

    [System.Serializable]
    public class TimeSensitiveGame
    {
        [SerializeField] internal string GameTitle;
        [SerializeField] internal Sprite GameLogo;
        [SerializeField] internal TimeSensitiveActivity[] TimeSensitiveActivities;
    }
}
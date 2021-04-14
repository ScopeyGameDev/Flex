using System.Collections.Generic;
using UnityEngine;
using Flex.TimeSensitive;

namespace Flex.Games
{
    [System.Serializable]
    internal class TimeSensitiveActivities
    {
        [SerializeField] internal string ActivityTitle;
        [SerializeField] internal ActivityType ActivityType;
        [SerializeField] internal int TimeLeft;
        [SerializeField] internal TimeType TimeType;
        [SerializeField] internal Vector2 Battlepass;
        [SerializeField] internal string Description;
    }

    [System.Serializable]
    internal class Achievements
    {
        [SerializeField] internal string AchievementName;
        [SerializeField] internal Sprite AchievementLogo;
        [SerializeField] internal float AchievementProgress;
        [SerializeField] internal string AchievementShortDescription;
        [SerializeField] internal bool AchievementDone;
        [SerializeField] internal bool Missable;
    }

    [System.Serializable]
    internal class Guides
    {
        
    }

    [System.Serializable]
    internal class GroupFinder
    {
        
    }

    [System.Serializable]
    internal class GameInfo
    {
        [SerializeField] internal string GameName;
        [SerializeField] internal Sprite GameLogo;
        [SerializeField] internal List<TimeSensitiveActivities> TimeSensitiveActivities;
        [SerializeField] internal List<Achievements> Achievements;
        [SerializeField] internal List<Guides> Guides;
        [SerializeField] internal List<GroupFinder> GroupFinder;
    }

    public class Games : MonoBehaviour
    {
        [SerializeField] internal List<GameInfo> GamesList;
    }
}
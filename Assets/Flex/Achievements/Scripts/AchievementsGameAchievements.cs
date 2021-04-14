using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Flex.Games;

namespace Flex.Achievements
{
    public class AchievementsGameAchievements : MonoBehaviour
    {
        Games.Achievements Achievement;
        [SerializeField] Image AchievementLogoImage;
        [SerializeField] TMP_Text AchievementTitleText;
        [SerializeField] TMP_Text AchievementShortDescriptionText;
        [SerializeField] TMP_Text AchievementProgressText;
        [SerializeField] GameObject MissableImage;

        internal void Create(Games.Achievements NewAchievement)
		{
            Achievement = NewAchievement;
            AchievementLogoImage.sprite = Achievement.AchievementLogo;
            AchievementTitleText.text = Achievement.AchievementName;
            AchievementShortDescriptionText.text = Achievement.AchievementShortDescription;
            AchievementProgressText.text = Mathf.RoundToInt(Achievement.AchievementProgress) + "%";
            MissableImage.SetActive(Achievement.Missable);
		}
    }
}
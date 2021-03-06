using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Flex.Games;

namespace Flex.Achievements
{
    public class AchievementsGame : MonoBehaviour
    {
        [SerializeField] AchievementsManager AchievementsManager;

        [SerializeField] TMP_Text GameTitleText;
        [SerializeField] Image GameLogoImage;
        [SerializeField] TMP_Text AchievementsProgressText;

        GameInfo GameInfo;

        internal void Create(GameInfo NewGameInfo, AchievementsManager NewAchievementsManager)
        {
            AchievementsManager = NewAchievementsManager;
            GameInfo = NewGameInfo;
            GameTitleText.text = GameInfo.GameName;
            GameLogoImage.sprite = GameInfo.GameLogo;

            int AchievementsDone = 0;
            foreach (Games.Achievements Achievement in GameInfo.Achievements)
            {
                if (Achievement.AchievementDone)
                    AchievementsDone++;
            }
            AchievementsProgressText.text = AchievementsDone + "/" + GameInfo.Achievements.Count;

            GetComponent<Button>().onClick.AddListener(delegate { AchievementsManager.ShowAchievements(GameInfo); });
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flex.Navigation;
using Flex.Games;
using Flex.Guides;
using TMPro;
using UnityEngine.UI;

namespace Flex.Achievements
{
    public class AchievementsManager : MonoBehaviour
    {
        [Header("Managers")]
        [SerializeField] NavigationManager NavigationManager;
        [SerializeField] Games.Games Games;

        [Header("Achievements General")]
        [SerializeField] Transform AchievementsGeneralParent;
        [SerializeField] Transform AchievementsGeneralTransform;
        [SerializeField] AchievementsGame AchievementsGame;
        GameInfo CurrentGame;

        [Header("Achievements Game")]
        [SerializeField] Transform AchievementsGameParent;
        [SerializeField] Transform AchievementsGameTransform;
        [SerializeField] AchievementsGameAchievements AchievementsGameAchievements;
        [SerializeField] Image GameLogo;
        [SerializeField] TMP_Text GameTitleText;

        [Header("Achievements Game Achievements")]
        [SerializeField] Transform AchievementsGameAchievementsParent;
        [SerializeField] Transform AchievementsGameAchievementsTransform;
        [SerializeField] Image AchievementLogo;
        [SerializeField] TMP_Text AchievementNameText;
        [SerializeField] TMP_Text AchievementsDescriptionText;
        [SerializeField] GameObject Missable;
        [SerializeField] GuidesInfo GuidesInfo;

        void Start()
        {
            foreach (GameInfo Game in Games.GamesList)
            {
                if (Game.Achievements.Count > 0)
                {
                    AchievementsGame CreatedAchievementsGame = Instantiate(AchievementsGame, AchievementsGeneralTransform);
                    CreatedAchievementsGame.Create(Game, this);
                }
            }
        }

        internal void ShowAchievements(GameInfo Game)
		{
            NavigationManager.SetBackButton(ShowGames);
            CurrentGame = Game;
            AchievementsGeneralParent.gameObject.SetActive(false);
            AchievementsGameAchievementsParent.gameObject.SetActive(false);
            AchievementsGameParent.gameObject.SetActive(true);

            GameLogo.sprite = Game.GameLogo;
            GameTitleText.text = Game.GameName;
            
            foreach (Games.Achievements Achievement in Game.Achievements)
			{
                if (!Achievement.AchievementDone)
				{
                    AchievementsGameAchievements CreatedAchievementsGameAchievements = Instantiate(AchievementsGameAchievements, AchievementsGameTransform);
                    CreatedAchievementsGameAchievements.Create(Achievement, this);
                }
			}
		}

        internal void ShowAchievementsInfo(Games.Achievements Achievement)
		{
            NavigationManager.SetBackButton(delegate { ShowAchievements(CurrentGame); });
            AchievementsGameParent.gameObject.SetActive(false);
            AchievementsGameAchievementsParent.gameObject.SetActive(true);

            AchievementLogo.sprite = Achievement.AchievementLogo;
            AchievementNameText.text = Achievement.AchievementName;
            AchievementsDescriptionText.text = Achievement.AchievementShortDescription;
            Missable.SetActive(Achievement.Missable);

            foreach (Games.Guides Guide in Achievement.Guides)
			{
                GuidesInfo CreatedGuide = Instantiate(GuidesInfo, AchievementsGameAchievementsTransform);
                CreatedGuide.Create(Guide);
			}
		}

        internal void ShowGuideInfo(Games.Guides Guide)
		{

		}

        internal void ShowGames()
		{
            AchievementsGameParent.gameObject.SetActive(false);
            AchievementsGeneralParent.gameObject.SetActive(true);
            AchievementsGameAchievementsParent.gameObject.SetActive(false);
        }
    }
}
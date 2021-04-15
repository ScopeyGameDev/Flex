using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flex.Navigation;
using Flex.Games;
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

        [Header("Achievements Game")]
        [SerializeField] Transform AchievementsGameParent;
        [SerializeField] Transform AchievementsGameTransform;
        [SerializeField] AchievementsGameAchievements AchievementsGameAchievements;
        [SerializeField] Image GameLogo;
        [SerializeField] TMP_Text GameTitleText;


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
            AchievementsGeneralParent.gameObject.SetActive(false);
            AchievementsGameParent.gameObject.SetActive(true);

            GameLogo.sprite = Game.GameLogo;
            GameTitleText.text = Game.GameName;
            
            foreach (Games.Achievements Achievement in Game.Achievements)
			{
                if (!Achievement.AchievementDone)
				{
                    AchievementsGameAchievements CreatedAchievementsGameAchievements = Instantiate(AchievementsGameAchievements, AchievementsGameTransform);
                    CreatedAchievementsGameAchievements.Create(Achievement);
                }                
			}
		}

        internal void ShowGames()
		{
            AchievementsGameParent.gameObject.SetActive(false);
            AchievementsGeneralParent.gameObject.SetActive(true);
        }
    }
}
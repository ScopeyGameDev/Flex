using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flex.Navigation;

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

        void Start()
        {
            foreach (Games.GameInfo Game in Games.GamesList)
            {
                if (Game.Achievements.Count > 0)
                {
                    AchievementsGame CreatedAchievementsGame = Instantiate(AchievementsGame, AchievementsGeneralTransform);
                    CreatedAchievementsGame.Create(Game);
                }
            }
        }
    }
}
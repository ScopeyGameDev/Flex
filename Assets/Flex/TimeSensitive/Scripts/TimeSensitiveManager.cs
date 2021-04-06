using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flex.Navigation;
using TMPro;
using UnityEngine.UI;

namespace Flex.TimeSensitive
{
    public class TimeSensitiveManager : MonoBehaviour
    {
        [SerializeField] NavigationManager NavigationManager;

        [SerializeField] List<TimeSensitiveGame> TimeSensitiveGames;

        [Header("Time Sensitive General")]
        [SerializeField] Transform TimeSensitiveGeneralParent;
        [SerializeField] Transform TimeSensitiveGeneralTransform;

        [Header("Time Sensitive Game")]
        [SerializeField] Transform TimeSensitiveGameParent;
        [SerializeField] Transform TimeSensitiveGameTransform;
        [SerializeField] TimeSensitiveContent TimeSensitiveContent;
        [SerializeField] TMP_Text GameTitleText;
        [SerializeField] Image GameLogoImage;
        [SerializeField] TimeSensitiveActivity EventActivity;
        [SerializeField] TimeSensitiveActivity DailyActivity;
        [SerializeField] TimeSensitiveActivity WeeklyActivity;
        [SerializeField] TimeSensitiveActivity BattlepassActivity;
        [SerializeField] TimeSensitiveActivityInformation TimeSensitiveActivityInformation;

        void Start() 
        {
            TimeSensitiveGeneralParent.gameObject.SetActive(true);
            TimeSensitiveGameParent.gameObject.SetActive(false);
            
            foreach (TimeSensitiveGame Game in TimeSensitiveGames)
            {
                TimeSensitiveContent CreatedTimeSensitiveContent = Instantiate(TimeSensitiveContent, TimeSensitiveGeneralTransform);
                CreatedTimeSensitiveContent.Create(Game, this);
            }
        }

        internal void GameSelected(TimeSensitiveGame SelectedGame)
        {
            if (!EventActivity.gameObject.activeInHierarchy)
                EventActivity.gameObject.SetActive(true);
            if (!DailyActivity.gameObject.activeInHierarchy)
                DailyActivity.gameObject.SetActive(true);
            if (!WeeklyActivity.gameObject.activeInHierarchy)
                WeeklyActivity.gameObject.SetActive(true);
            if (!BattlepassActivity.gameObject.activeInHierarchy)
                BattlepassActivity.gameObject.SetActive(true);

            EventActivity.ResetFill();
            DailyActivity.ResetFill();
            WeeklyActivity.ResetFill();
            BattlepassActivity.ResetFill();

            TimeSensitiveGeneralParent.gameObject.SetActive(false);
            TimeSensitiveGameParent.gameObject.SetActive(true);
            NavigationManager.SetBackButton(delegate {ShowGames();});
            GameTitleText.text = SelectedGame.GameTitle;
            GameLogoImage.sprite = SelectedGame.GameLogo;      

            int Events = 0, Dailies = 0, Weeklies = 0, Battlepass = 0;

            foreach (TimeSensitiveActivityPref Activity in SelectedGame.TimeSensitiveActivities)
            {
                switch (Activity.ActivityType)
                {
                    case ActivityType.Event:
                        EventActivity.AddActivity(Activity, Events == 0);
                        Events++;
                        break;
                    case ActivityType.Daily:
                        DailyActivity.AddActivity(Activity, Dailies == 0);
                        Dailies++;
                        break;
                    case ActivityType.Weekly:
                        WeeklyActivity.AddActivity(Activity, Weeklies == 0);
                        Weeklies++;
                        break;
                    case ActivityType.Battlepass:
                        BattlepassActivity.AddActivity(Activity, Battlepass == 0);
                        Battlepass++;
                        break;
                }
            }

            if (Events == 0)
                EventActivity.gameObject.SetActive(false);
            if (Dailies == 0)
                DailyActivity.gameObject.SetActive(false);
            if (Weeklies == 0)
                WeeklyActivity.gameObject.SetActive(false);
            if (Battlepass == 0)
                BattlepassActivity.gameObject.SetActive(false);
        }

        void ShowGames()
        {
            TimeSensitiveGeneralParent.gameObject.SetActive(true);
            TimeSensitiveGameParent.gameObject.SetActive(false);
        }

        internal void ShowActivityInformation(TimeSensitiveActivityPref ActivityPref)
        {
            TimeSensitiveActivityInformation.AssignActivity(ActivityPref);
        }
    }
}
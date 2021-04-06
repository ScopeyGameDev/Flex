using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Flex.TimeSensitive
{
    public class TimeSensitiveContent : MonoBehaviour
    {
        TimeSensitiveManager TimeSensitiveManager;
        TimeSensitiveGame TimeSensitiveGame;
        [SerializeField] Transform ContentTransform;
        [SerializeField] TimeSensitiveContentActivity TimeSensitiveContentActivity;

        [SerializeField] RectTransform ParentTransform;
        [SerializeField] Image GameLogoImage;
        [SerializeField] TMP_Text GameTitleText;
        [SerializeField] Button GameButton;

        void Start() 
        {
            GameButton.onClick.AddListener(delegate {TimeSensitiveManager.GameSelected(TimeSensitiveGame);});
        }

        internal void Create(TimeSensitiveGame NewTimeSensitiveGame, TimeSensitiveManager NewTimeSensitiveManager)
        {
            TimeSensitiveManager = NewTimeSensitiveManager;
            TimeSensitiveGame = NewTimeSensitiveGame;
            GameLogoImage.sprite = TimeSensitiveGame.GameLogo;
            GameTitleText.text = TimeSensitiveGame.GameTitle;

            foreach(TimeSensitiveActivityPref Activity in TimeSensitiveGame.TimeSensitiveActivities)
            {
                CreateActivity(Activity);
            }
        }

        void CreateActivity(TimeSensitiveActivityPref Activity)
        {
            TimeSensitiveContentActivity CreatedTimeSensitiveActivity = Instantiate(TimeSensitiveContentActivity, ContentTransform);
            CreatedTimeSensitiveActivity.Create(Activity, false);

            float Offset = 90;
            if (Activity.ActivityType == ActivityType.Battlepass)
                Offset += 50;

            ParentTransform.sizeDelta = new Vector2(ParentTransform.rect.width, ParentTransform.rect.height + Offset);
        }
    }
}
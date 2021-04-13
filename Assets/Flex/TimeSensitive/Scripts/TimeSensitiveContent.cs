using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Flex.Games;

namespace Flex.TimeSensitive
{
    public class TimeSensitiveContent : MonoBehaviour
    {
        TimeSensitiveManager TimeSensitiveManager;
        GameInfo GameInfo;
        [SerializeField] Transform ContentTransform;
        [SerializeField] TimeSensitiveContentActivity TimeSensitiveContentActivity;

        [SerializeField] RectTransform ParentTransform;
        [SerializeField] Image GameLogoImage;
        [SerializeField] TMP_Text GameTitleText;
        [SerializeField] Button GameButton;

        void Start() 
        {
            GameButton.onClick.AddListener(delegate {TimeSensitiveManager.GameSelected(GameInfo);});
        }

        internal void Create(GameInfo NewGameInfo, TimeSensitiveManager NewTimeSensitiveManager)
        {
            TimeSensitiveManager = NewTimeSensitiveManager;
            GameInfo = NewGameInfo;
            GameLogoImage.sprite = GameInfo.GameLogo;
            GameTitleText.text = GameInfo.GameName;

            foreach(TimeSensitiveActivities Activity in GameInfo.TimeSensitiveActivities)
            {
                CreateActivity(Activity);
            }
        }

        void CreateActivity(TimeSensitiveActivities Activity)
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
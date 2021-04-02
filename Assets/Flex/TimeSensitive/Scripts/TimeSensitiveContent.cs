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

        internal void Create(TimeSensitiveGame NewTimeSensitiveGame)
        {
            TimeSensitiveGame = NewTimeSensitiveGame;
            GameLogoImage.sprite = TimeSensitiveGame.GameLogo;
            GameTitleText.text = TimeSensitiveGame.GameTitle;

            foreach(TimeSensitiveActivity Activity in TimeSensitiveGame.TimeSensitiveActivities)
            {
                CreateActivity(Activity);
            }
        }

        void CreateActivity(TimeSensitiveActivity Activity)
        {
            TimeSensitiveContentActivity CreatedTimeSensitiveActivity = Instantiate(TimeSensitiveContentActivity, ContentTransform);
            CreatedTimeSensitiveActivity.Create(Activity);

            float Offset = 90;
            if (Activity.ActivityType == ActivityType.Battlepass)
                Offset += 50;

            ParentTransform.sizeDelta = new Vector2(ParentTransform.rect.width, ParentTransform.rect.height + Offset);
        }
    }
}
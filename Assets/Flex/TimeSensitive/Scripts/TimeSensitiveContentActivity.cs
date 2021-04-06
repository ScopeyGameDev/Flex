using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Flex.TimeSensitive
{
    public class TimeSensitiveContentActivity : MonoBehaviour
    {
        TimeSensitiveActivityPref TimeSensitiveActivity;
        [SerializeField] TMP_Text ActivityTitleText;
        [SerializeField] TMP_Text ActivityTimeLeftText;
        [SerializeField] GameObject BattlepassPanel;
        [SerializeField] Button ActivityButton;

        internal void Create(TimeSensitiveActivityPref NewTimeSensitiveActivity, bool ShowAdditionalInformation)
        {
            TimeSensitiveActivity = NewTimeSensitiveActivity;
            ActivityTitleText.text = TimeSensitiveActivity.ActivityTitle;
            
            string TimeTypeText = "";
            switch (TimeSensitiveActivity.TimeType)
            {
                case TimeType.Hour:
                    if (TimeSensitiveActivity.TimeLeft > 1)
                        TimeTypeText = "hrs";
                    else
                        TimeTypeText = "hr";
                    break;
                
                case TimeType.Day:
                    if (TimeSensitiveActivity.TimeLeft > 1)
                        TimeTypeText = "days";
                    else
                        TimeTypeText = "day";
                    break;
                
                case TimeType.Week:
                    if (TimeSensitiveActivity.TimeLeft > 1)
                        TimeTypeText = "weeks";
                    else
                        TimeTypeText = "week";
                    break;
            }
            ActivityTimeLeftText.text = TimeSensitiveActivity.TimeLeft + TimeTypeText;

            if(TimeSensitiveActivity.ActivityType == ActivityType.Battlepass)
            {
                ActivityTitleText.text = TimeSensitiveActivity.ActivityTitle + " " + TimeSensitiveActivity.Battlepass.x + "/" + TimeSensitiveActivity.Battlepass.y;
                
                RectTransform Rect = GetComponent<RectTransform>();
                Rect.sizeDelta = new Vector2(Rect.rect.width, 145);
                BattlepassPanel.SetActive(true);
                for (int i = 0; i < TimeSensitiveActivity.Battlepass.y; i++)
                {
                    GameObject Section = new GameObject();
                    Section.transform.SetParent(BattlepassPanel.transform);
                    Image SectionImage = Section.AddComponent<Image>();
                    if (i < TimeSensitiveActivity.Battlepass.x)
                        SectionImage.color = Color.green;
                    else
                        SectionImage.color = Color.red;
                }
            }

            if (ShowAdditionalInformation)
            {
                ActivityButton.enabled = true;
                ActivityButton.onClick.AddListener(delegate {FindObjectOfType<TimeSensitiveManager>().ShowActivityInformation(TimeSensitiveActivity);});
            }
            
        }
    }
}
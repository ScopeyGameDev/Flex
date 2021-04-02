using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Flex.TimeSensitive
{
    public class TimeSensitiveContentActivity : MonoBehaviour
    {
        TimeSensitiveActivity TimeSensitiveActivity;
        [SerializeField] TMP_Text ActivityTitleText;
        [SerializeField] TMP_Text ActivityTimeLeftText;
        [SerializeField] GameObject BattlepassPanel;

        internal void Create(TimeSensitiveActivity NewTimeSensitiveActivity)
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

                GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().rect.width, 145);
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
        }
    }
}
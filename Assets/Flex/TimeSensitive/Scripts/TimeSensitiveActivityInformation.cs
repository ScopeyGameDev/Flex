using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Flex.Games;

namespace Flex.TimeSensitive
{
    public class TimeSensitiveActivityInformation : MonoBehaviour
    {
        [SerializeField] TMP_Text ActivityTitleText;
        [SerializeField] TMP_Text DescriptionText;
        [SerializeField] TMP_Text TimeLeftText;
        [SerializeField] Button CloseButton;
        [SerializeField] GameObject BattlepassPanel;
        TimeSensitiveActivities ActivityPref;
        List<GameObject> Sections = new List<GameObject>();

        void Start()
        {
            gameObject.SetActive(false);
            CloseButton.onClick.AddListener(delegate {Close();});
        }

        internal void AssignActivity(TimeSensitiveActivities ActivityPrefToAssign)
        {
            ActivityPref = ActivityPrefToAssign;
            ActivityTitleText.text = ActivityPref.ActivityTitle;
            DescriptionText.text = ActivityPref.Description;
            
            string TimeTypeText = "";
            switch (ActivityPref.TimeType)
            {
                case TimeType.Hour:
                    if (ActivityPref.TimeLeft > 1)
                        TimeTypeText = "hrs";
                    else
                        TimeTypeText = "hr";
                    break;
                
                case TimeType.Day:
                    if (ActivityPref.TimeLeft > 1)
                        TimeTypeText = "days";
                    else
                        TimeTypeText = "day";
                    break;
                
                case TimeType.Week:
                    if (ActivityPref.TimeLeft > 1)
                        TimeTypeText = "weeks";
                    else
                        TimeTypeText = "week";
                    break;
            }
            TimeLeftText.text = ActivityPref.TimeLeft + TimeTypeText;

            gameObject.SetActive(true);

            if (ActivityPref.ActivityType == ActivityType.Battlepass)
            {
				ActivityTitleText.text = ActivityPref.ActivityTitle + " " + ActivityPref.Battlepass.x + "/" + ActivityPref.Battlepass.y;

				// RectTransform Rect = GetComponent<RectTransform>();
				// Rect.sizeDelta = new Vector2(Rect.rect.width, 145);
				BattlepassPanel.SetActive(true);
                if (Sections.Count > 0)
				{
                    foreach (GameObject Section in Sections)
					{
                        Destroy(Section);
					}
                    Sections.Clear();
				}

                for (int i = 0; i < ActivityPref.Battlepass.y; i++)
                {
                    GameObject Section = new GameObject();
                    Sections.Add(Section);
                    Section.transform.SetParent(BattlepassPanel.transform);
                    Image SectionImage = Section.AddComponent<Image>();
                    if (i < ActivityPref.Battlepass.x)
                        SectionImage.color = Color.green;
                    else
                        SectionImage.color = Color.red;
                }
            }
            else
			{
                if (BattlepassPanel.activeInHierarchy)
                    BattlepassPanel.SetActive(false);
			}
        }

        void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
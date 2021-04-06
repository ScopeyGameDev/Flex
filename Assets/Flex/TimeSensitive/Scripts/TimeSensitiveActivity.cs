using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Flex.TimeSensitive
{
    public class TimeSensitiveActivity : MonoBehaviour
    {
        [SerializeField] RectTransform Rect;
        float StartingHeight;
        [SerializeField] Transform FillTransform;
        [SerializeField] TimeSensitiveContentActivity TimeSensitiveContentActivity;
        List<TimeSensitiveContentActivity> CreatedActivities = new List<TimeSensitiveContentActivity>();

        void Start() 
        {
            StartingHeight = 150;
        }

        internal void AddActivity(TimeSensitiveActivityPref TimeSensitiveActivityPref, bool First)
        {
            TimeSensitiveContentActivity CreatedTimeSensitiveContentActivity = Instantiate(TimeSensitiveContentActivity, FillTransform);
            CreatedTimeSensitiveContentActivity.Create(TimeSensitiveActivityPref, true);
            CreatedActivities.Add(CreatedTimeSensitiveContentActivity);

            if (!First)
            {   
                float Offset = 90;
                if (TimeSensitiveActivityPref.ActivityType == ActivityType.Battlepass)
                    Offset += 55;

                Rect.sizeDelta = new Vector2(Rect.rect.width, Rect.rect.height + Offset);
            }
            else if (TimeSensitiveActivityPref.ActivityType == ActivityType.Battlepass)
            {
                Rect.sizeDelta = new Vector2(Rect.rect.width, Rect.rect.height + 55);
            }
        }

        internal void ResetFill()
        {
            if (CreatedActivities.Count == 0)
                return;

            while (CreatedActivities.Count > 0)
            {
                TimeSensitiveContentActivity ActivityToDelete = CreatedActivities[0];
                CreatedActivities.RemoveAt(0);
                Destroy(ActivityToDelete.gameObject);
            }

            Rect.sizeDelta = new Vector2(Rect.rect.width, StartingHeight);
        }
    }
}
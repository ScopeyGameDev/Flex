using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

namespace Flex.Navigation
{
    enum PageType { TimeSensitive, Achievements, Guides, GroupFinder, Profile };

    public class NavigationManager : MonoBehaviour
    {
        [Header("TopPanel")]
        [SerializeField] TMP_Text PageTitle;

        PageType SelectedPage;

        [SerializeField] Sprite OpenBox;
        [SerializeField] Sprite ClosedBox;

        [Header("TimeSensitive")]
        [SerializeField] Button TimeSensitiveNavButton;
        [SerializeField] Image TimeSensitiveNavButtonBorder;
        [SerializeField] GameObject TimeSensitiveContentPanel;
        [SerializeField] Button TimeSensitiveBackButton;
        bool EventAttachedToTimeSensitiveButton;

        [Header("Achievements")]
        [SerializeField] Button AchievementsNavButton;
        [SerializeField] Image AchievementsNavButtonBorder;
        [SerializeField] GameObject AchievementsContentPanel;
        [SerializeField] Button AchievementsBackButton;
        bool EventAttachedToAchievementsButton;

        [Header("Guides")]
        [SerializeField] Button GuidesNavButton;
        [SerializeField] Image GuidesNavButtonBorder;
        [SerializeField] GameObject GuidesContentPanel;
        [SerializeField] Button GuidesBackButton;
        bool EventAttachedToGuidesButton;

        [Header("GroupFinder")]
        [SerializeField] Button GroupFinderNavButton;
        [SerializeField] Image GroupFinderNavButtonBorder;
        [SerializeField] GameObject GroupFinderContentPanel;
        [SerializeField] Button GroupFinderBackButton;
        bool EventAttachedToGroupFinderButton;

        [Header("Profile")]
        [SerializeField] Button ProfileNavButton;
        [SerializeField] GameObject ProfileContentPanel;
        [SerializeField] Button ProfileBackButton;
        bool EventAttachedToProfileButton;

        // Start is called before the first frame update
        void Start()
        {
            TimeSensitiveNavButton.onClick.AddListener(delegate {SwitchPage(PageType.TimeSensitive);} );
            AchievementsNavButton.onClick.AddListener(delegate {SwitchPage(PageType.Achievements);} );
            GuidesNavButton.onClick.AddListener(delegate {SwitchPage(PageType.Guides);} );
            GroupFinderNavButton.onClick.AddListener(delegate {SwitchPage(PageType.GroupFinder);} );
            ProfileNavButton.onClick.AddListener(delegate {SwitchPage(PageType.Profile);} );

            TimeSensitiveBackButton.gameObject.SetActive(false);
            AchievementsBackButton.gameObject.SetActive(false);
            GuidesBackButton.gameObject.SetActive(false);
            GroupFinderBackButton.gameObject.SetActive(false);
            ProfileBackButton.gameObject.SetActive(false);

            SwitchPage(PageType.TimeSensitive);
        }

        internal void SetBackButton(UnityAction Event)
        {
            switch (SelectedPage)
            {
                case PageType.TimeSensitive:
                    TimeSensitiveBackButton.onClick.AddListener(Event);
                    TimeSensitiveBackButton.gameObject.SetActive(true);
                    EventAttachedToTimeSensitiveButton = true;
                    TimeSensitiveBackButton.onClick.AddListener(delegate { BackButtonPressed(); });
                    break;
                case PageType.Achievements:
                    AchievementsBackButton.onClick.AddListener(Event);
                    AchievementsBackButton.gameObject.SetActive(true);
                    EventAttachedToAchievementsButton = true;
                    AchievementsBackButton.onClick.AddListener(delegate { BackButtonPressed(); });
                    break;
                case PageType.Guides:
                    GuidesBackButton.onClick.AddListener(Event);
                    GuidesBackButton.gameObject.SetActive(true);
                    EventAttachedToGuidesButton = true;
                    GuidesBackButton.onClick.AddListener(delegate { BackButtonPressed(); });
                    break;
                case PageType.GroupFinder:
                    GroupFinderBackButton.onClick.AddListener(Event);
                    GroupFinderBackButton.gameObject.SetActive(true);
                    EventAttachedToGroupFinderButton = true;
                    GroupFinderBackButton.onClick.AddListener(delegate { BackButtonPressed(); });
                    break;
                case PageType.Profile:
                    ProfileBackButton.onClick.AddListener(Event);
                    ProfileBackButton.gameObject.SetActive(true);
                    EventAttachedToProfileButton = true;
                    ProfileBackButton.onClick.AddListener(delegate { BackButtonPressed(); });
                    break;
            }
        }

        void BackButtonPressed()
        {
            switch (SelectedPage)
            {
                case PageType.TimeSensitive:
                    TimeSensitiveBackButton.onClick.RemoveAllListeners();
                    EventAttachedToTimeSensitiveButton = false;
                    TimeSensitiveBackButton.gameObject.SetActive(false);
                    break;
                case PageType.Achievements:
                    AchievementsBackButton.onClick.RemoveAllListeners();
                    EventAttachedToAchievementsButton = false;
                    AchievementsBackButton.gameObject.SetActive(false);
                    break;
                case PageType.Guides:
                    GuidesBackButton.onClick.RemoveAllListeners();
                    EventAttachedToGuidesButton = false;
                    GuidesBackButton.gameObject.SetActive(false);
                    break;
                case PageType.GroupFinder:
                    GroupFinderBackButton.onClick.RemoveAllListeners();
                    EventAttachedToGroupFinderButton = false;
                    GroupFinderBackButton.gameObject.SetActive(false);
                    break;
                case PageType.Profile:
                    ProfileBackButton.onClick.RemoveAllListeners();
                    EventAttachedToProfileButton = false;
                    ProfileBackButton.gameObject.SetActive(false);
                    break;
            }
		}

        internal void SwitchPage(PageType NewPageType)
        {
            switch (SelectedPage)
            {
                case PageType.TimeSensitive:
                    TimeSensitiveNavButtonBorder.sprite = ClosedBox;
                    TimeSensitiveContentPanel.SetActive(false);
                    TimeSensitiveBackButton.gameObject.SetActive(false);
                    break;
                case PageType.Achievements:
                    AchievementsNavButtonBorder.sprite = ClosedBox;
                    AchievementsContentPanel.SetActive(false);
                    AchievementsBackButton.gameObject.SetActive(false);
                    break;
                case PageType.Guides:
                    GuidesNavButtonBorder.sprite = ClosedBox;
                    GuidesContentPanel.SetActive(false);           
                    GuidesBackButton.gameObject.SetActive(false);
                    break;
                case PageType.GroupFinder:
                    GroupFinderNavButtonBorder.sprite = ClosedBox;
                    GroupFinderContentPanel.SetActive(false);
                    GroupFinderBackButton.gameObject.SetActive(false);
                    break;
                case PageType.Profile:
                    ProfileContentPanel.SetActive(false);
                    ProfileBackButton.gameObject.SetActive(false);
                    break; 
            }

            switch (NewPageType)
            {
                case PageType.TimeSensitive:
                    PageTitle.text = "Time Sensitive";
                    TimeSensitiveNavButtonBorder.sprite = OpenBox;
                    TimeSensitiveContentPanel.SetActive(true);

                    if (EventAttachedToTimeSensitiveButton)
                        TimeSensitiveBackButton.gameObject.SetActive(true);
                    break;
                case PageType.Achievements:
                    PageTitle.text = "Achievements";
                    AchievementsNavButtonBorder.sprite = OpenBox;
                    AchievementsContentPanel.SetActive(true);

                    if (EventAttachedToAchievementsButton)
                        AchievementsBackButton.gameObject.SetActive(true);
                    break;
                case PageType.Guides:
                    PageTitle.text = "Guides";
                    GuidesNavButtonBorder.sprite = OpenBox;
                    GuidesContentPanel.SetActive(true);

                    if (EventAttachedToGuidesButton)
                        GuidesBackButton.gameObject.SetActive(true);
                    break;
                case PageType.GroupFinder:
                    PageTitle.text = "GroupFinder";
                    GroupFinderNavButtonBorder.sprite = OpenBox;
                    GroupFinderContentPanel.SetActive(true);

                    if (EventAttachedToGroupFinderButton)
                        GroupFinderBackButton.gameObject.SetActive(true);
                    break;
                case PageType.Profile:
                    PageTitle.text = "Profile";
                    ProfileContentPanel.SetActive(true);

                    if (EventAttachedToProfileButton)
                        ProfileBackButton.gameObject.SetActive(true);
                    break; 
            }

            SelectedPage = NewPageType;
        }
    }
}
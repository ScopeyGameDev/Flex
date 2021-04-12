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
        [SerializeField] Button BackButton;

        [Header("TopPanel")]
        [SerializeField] TMP_Text PageTitle;

        PageType SelectedPage;

        [SerializeField] Sprite OpenBox;
        [SerializeField] Sprite ClosedBox;

        [Header("TimeSensitive")]
        [SerializeField] Button TimeSensitiveNavButton;
        [SerializeField] Image TimeSensitiveNavButtonBorder;
        [SerializeField] GameObject TimeSensitiveContentPanel;

        [Header("Achievements")]
        [SerializeField] Button AchievementsNavButton;
        [SerializeField] Image AchievementsNavButtonBorder;
        [SerializeField] GameObject AchievementsContentPanel;

        [Header("Guides")]
        [SerializeField] Button GuidesNavButton;
        [SerializeField] Image GuidesNavButtonBorder;
        [SerializeField] GameObject GuidesContentPanel;

        [Header("GroupFinder")]
        [SerializeField] Button GroupFinderNavButton;
        [SerializeField] Image GroupFinderNavButtonBorder;
        [SerializeField] GameObject GroupFinderContentPanel;

        [Header("Profile")]
        [SerializeField] Button ProfileNavButton;
        [SerializeField] GameObject ProfileContentPanel;

        // Start is called before the first frame update
        void Start()
        {
            BackButton.gameObject.SetActive(false);
            TimeSensitiveNavButton.onClick.AddListener(delegate {SwitchPage(PageType.TimeSensitive);} );
            AchievementsNavButton.onClick.AddListener(delegate {SwitchPage(PageType.Achievements);} );
            GuidesNavButton.onClick.AddListener(delegate {SwitchPage(PageType.Guides);} );
            GroupFinderNavButton.onClick.AddListener(delegate {SwitchPage(PageType.GroupFinder);} );
            ProfileNavButton.onClick.AddListener(delegate {SwitchPage(PageType.Profile);} );

            SwitchPage(PageType.TimeSensitive);
        }

        internal void SetBackButton(UnityAction Event)
        {
            BackButton.gameObject.SetActive(true);
            BackButton.onClick.AddListener(Event);
            BackButton.onClick.AddListener(delegate {BackButtonPressed();});
        }

        void AddEventToBackButton(UnityAction Event)
        {
            BackButton.onClick.AddListener(Event);
        }

        void BackButtonPressed()
        {
            BackButton.onClick.Invoke();
            BackButton.onClick.RemoveAllListeners();
            BackButton.gameObject.SetActive(false);
        }

        internal void SwitchPage(PageType NewPageType)
        {
            // AddEventToBackButton(delegate {SwitchPage(SelectedPage);});

            switch (SelectedPage)
            {
                case PageType.TimeSensitive:
                    TimeSensitiveNavButtonBorder.sprite = ClosedBox;
                    TimeSensitiveContentPanel.SetActive(false);
                    break;
                case PageType.Achievements:
                    AchievementsNavButtonBorder.sprite = ClosedBox;
                    AchievementsContentPanel.SetActive(false);
                    break;
                case PageType.Guides:
                    GuidesNavButtonBorder.sprite = ClosedBox;
                    GuidesContentPanel.SetActive(false);
                    break;
                case PageType.GroupFinder:
                    GroupFinderNavButtonBorder.sprite = ClosedBox;
                    GroupFinderContentPanel.SetActive(false);
                    break;
                case PageType.Profile:
                    ProfileContentPanel.SetActive(false);
                    break; 
            }

            switch (NewPageType)
            {
                case PageType.TimeSensitive:
                    PageTitle.text = "Time Sensitive";
                    TimeSensitiveNavButtonBorder.sprite = OpenBox;
                    TimeSensitiveContentPanel.SetActive(true);
                    break;
                case PageType.Achievements:
                    PageTitle.text = "Achievements";
                    AchievementsNavButtonBorder.sprite = OpenBox;
                    AchievementsContentPanel.SetActive(true);
                    break;
                case PageType.Guides:
                    PageTitle.text = "Guides";
                    GuidesNavButtonBorder.sprite = OpenBox;
                    GuidesContentPanel.SetActive(true);
                    break;
                case PageType.GroupFinder:
                    PageTitle.text = "GroupFinder";
                    GroupFinderNavButtonBorder.sprite = OpenBox;
                    GroupFinderContentPanel.SetActive(true);
                    break;
                case PageType.Profile:
                    PageTitle.text = "Profile";
                    ProfileContentPanel.SetActive(true);
                    break; 
            }

            SelectedPage = NewPageType;
        }
    }
}
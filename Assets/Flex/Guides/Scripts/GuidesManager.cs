using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flex.Navigation;
using UnityEngine.UI;
using TMPro;

namespace Flex.Guides
{
    public class GuidesManager : MonoBehaviour
    {
        [SerializeField] Games.Games Games;
        [SerializeField] NavigationManager NavigationManager;

        [Header("Guides General")]
        [SerializeField] Transform GuidesGeneralParent;
        [SerializeField] Transform GuidesGeneralTransform;
        [SerializeField] GuidesGeneral GuidesGeneral;

        [Header("Guides Game")]
        [SerializeField] Transform GuidesGameParent;
        [SerializeField] Transform GuidesGameTransform;
        [SerializeField] GuidesInfo GuidesInfo;
        [SerializeField] Image GameLogoImage;
        [SerializeField] TMP_Text GameTitleText;

        List<GuidesInfo> Guides = new List<GuidesInfo>();


        void Start()
        {
            foreach (Games.GameInfo Game in Games.GamesList)
			{
                if (Game.Guides.Count > 0)
				{
                    GuidesGeneral CreatedGuidesGeneral = Instantiate(GuidesGeneral, GuidesGeneralTransform);
                    CreatedGuidesGeneral.Create(Game, Game.Guides, this);
				}
			}
        }

        internal void ShowGames()
		{
            GuidesGameParent.gameObject.SetActive(false);
            GuidesGeneralParent.gameObject.SetActive(true);
		}

        internal void ShowGuides(Games.GameInfo Game)
		{
            GuidesGeneralParent.gameObject.SetActive(false);
            GuidesGameParent.gameObject.SetActive(true);

            GameLogoImage.sprite = Game.GameLogo;
            GameTitleText.text = Game.GameName;

            NavigationManager.SetBackButton(ShowGames);

            if (Guides.Count > 0)
			{
                foreach (GuidesInfo Guide in Guides)
				{
                    Destroy(Guide);
				}
                Guides.Clear();
			}

            foreach (Games.Guides Guide in Game.Guides)
			{
                GuidesInfo CreatedGuidesInfo = Instantiate(GuidesInfo, GuidesGameTransform);
                CreatedGuidesInfo.Create(Guide);
                Guides.Add(CreatedGuidesInfo);
			}
		}
    }
}
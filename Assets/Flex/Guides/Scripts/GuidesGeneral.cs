using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flex.Games;
using UnityEngine.UI;
using TMPro;

namespace Flex.Guides
{
    public class GuidesGeneral : MonoBehaviour
    {
        [SerializeField] Image GameLogo;
        [SerializeField] TMP_Text GameTitleText;
        [SerializeField] RectTransform GuidesPanel;
        [SerializeField] GuidesContent GuidesContent;

        internal void Create(GameInfo GameInfo, List<Games.Guides> Guides, GuidesManager GuidesManager)
        {
            GameLogo.sprite = GameInfo.GameLogo;
            GameTitleText.text = GameInfo.GameName;

            foreach (Games.Guides Guide in Guides)
			{
                GuidesContent CreatedGuidesContent = Instantiate(GuidesContent, GuidesPanel);
                CreatedGuidesContent.Create(Guide, GuidesManager);
                GuidesPanel.sizeDelta = new Vector2(GuidesPanel.rect.width, GuidesPanel.rect.height + 90);
			}
        }
    }
}
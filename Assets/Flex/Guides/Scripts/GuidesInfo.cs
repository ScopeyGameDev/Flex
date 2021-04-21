using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flex.Games;
using Flex.Achievements;
using UnityEngine.UI;
using TMPro;

namespace Flex.Guides
{
    public class GuidesInfo : MonoBehaviour
    {
        [SerializeField] internal TMP_Text GuideTitleText;
        [SerializeField] internal TMP_Text GuideDescriptionText;
        [SerializeField] internal TMP_Text AuthorText;

        internal void Create(Games.Guides Guide)
        {
            GuideTitleText.text = Guide.GuideTitle;
            GuideDescriptionText.text = Guide.GuideDescription;
            AuthorText.text = Guide.GuideAuthor;
        }
    }
}
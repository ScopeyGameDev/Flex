using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Flex.GroupFinder
{
    public class GroupFinderJoin : MonoBehaviour
    {
        [SerializeField] TMP_Text ActivityNameText;
        [SerializeField] TMP_Text ActivityDescriptionText;

        internal void Assign(string ActivityName, string ActivityDescription)
		{
            ActivityNameText.text = ActivityName;
            ActivityDescriptionText.text = ActivityDescription;
		}
    }
}
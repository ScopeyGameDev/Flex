using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

namespace Flex.GroupFinder
{
	public class GroupFinderPanel : MonoBehaviour
	{
		[SerializeField] Button GroupFinderButton;
		[SerializeField] GameObject SelectionPanel;
		[SerializeField] TMP_Text SelectionText;

		internal void Assign(UnityAction Event, string SelectionName)
		{
			GroupFinderButton.onClick.RemoveAllListeners();
			GroupFinderButton.onClick.AddListener(Event);
			GroupFinderButton.onClick.AddListener(UnAssign);
			SelectionText.text = SelectionName;
		}

		internal void UnAssign()
		{
			GroupFinderButton.onClick.RemoveAllListeners();
			SelectionText.text = "";
		}
	}
}
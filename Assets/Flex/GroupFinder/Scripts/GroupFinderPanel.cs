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

		internal void Assign(UnityAction Event)
		{
			GroupFinderButton.onClick.RemoveAllListeners();
			GroupFinderButton.onClick.AddListener(Event);
		}

		internal void UnAssign()
		{
			GroupFinderButton.onClick.RemoveAllListeners();
		}
	}
}
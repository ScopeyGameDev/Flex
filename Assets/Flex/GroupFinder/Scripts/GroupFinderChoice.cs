using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

namespace Flex.GroupFinder
{
    public class GroupFinderChoice : MonoBehaviour
    {
        [SerializeField] TMP_Text ChoiceText;

        internal void Create(string ChoiceString, UnityAction Event, int i)
		{
            ChoiceText.text = ChoiceString;
            GetComponent<Button>().onClick.AddListener(Event);
            Debug.Log(i);
		}

        internal void CreateGameChoice(Games.GameInfo Game, GroupFinderManager GroupFinderManager)
		{
            ChoiceText.text = Game.GameNameShortend;
            GetComponent<Button>().onClick.AddListener(delegate { GroupFinderManager.SelectGame(Game); });
		}

        internal void CreateActivityChoice(string ActivityName, int Num, GroupFinderManager GroupFinderManager)
		{
            ChoiceText.text = ActivityName;
            GetComponent<Button>().onClick.AddListener(delegate { GroupFinderManager.SelectActivity(Num); });
        }

        internal void CreateRegionChoice(string RegionName, int Num, GroupFinderManager GroupFinderManager)
        {
            ChoiceText.text = RegionName;
            GetComponent<Button>().onClick.AddListener(delegate { GroupFinderManager.SelectRegion(Num); });
        }
    }
}
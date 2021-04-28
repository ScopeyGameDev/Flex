using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flex.Games;

namespace Flex.GroupFinder
{
	public class GroupFinderManager : MonoBehaviour
	{
		[SerializeField] Games.Games Games;

		GameInfo SelectedGame;
		int ActivityNum;
		int RegionNum;

		[SerializeField] GroupFinderPanel GamePanel;
		[SerializeField] GroupFinderPanel ActivityPanel;
		[SerializeField] GroupFinderPanel RegionPanel;

		[SerializeField] GroupFinderChoice GroupFinderChoice;
		[SerializeField] Transform ContentTransform;

		List<GroupFinderChoice> CreatedGroupFinderChoices = new List<GroupFinderChoice>();

		[SerializeField] GroupFinderJoin JoinPanel;

		void Start()
		{
			JoinPanel.gameObject.SetActive(false);
			GameSelection();
		}

		void GameSelection()
		{
			ClearChoices();
			foreach (GameInfo Game in Games.GamesList)
			{
				if (Game.GroupFinder.Count > 0)
				{
					GroupFinderChoice CreatedGroupFinderChoice = Instantiate(GroupFinderChoice, ContentTransform);
					CreatedGroupFinderChoice.CreateGameChoice(Game, this);
					CreatedGroupFinderChoices.Add(CreatedGroupFinderChoice);
				}
			}
		}

		void ActivitySelection()
		{
			ClearChoices();
			for (int i = 0; i < SelectedGame.GroupFinder.Count; i++)
			{
				GroupFinderChoice CreatedGroupFinderChoice = Instantiate(GroupFinderChoice, ContentTransform);
				CreatedGroupFinderChoice.CreateActivityChoice(SelectedGame.GroupFinder[i].Activity, i, this);
				CreatedGroupFinderChoices.Add(CreatedGroupFinderChoice);
			}
		}

		void RegionSelection()
		{
			ClearChoices();
			for (int i = 0; i < SelectedGame.GroupFinder[ActivityNum].Regions.Count; i++)
			{
				GroupFinderChoice CreatedGroupFinderChoice = Instantiate(GroupFinderChoice, ContentTransform);
				CreatedGroupFinderChoice.CreateRegionChoice(SelectedGame.GroupFinder[ActivityNum].Regions[i].ToString(), i, this);
				CreatedGroupFinderChoices.Add(CreatedGroupFinderChoice);
			}
		}

		void ClearChoices()
		{
			foreach (GroupFinderChoice item in CreatedGroupFinderChoices)
			{
				Destroy(item.gameObject);
			}
			CreatedGroupFinderChoices.Clear();
		}

		internal void SelectGame(GameInfo SelectGame)
		{
			SelectedGame = SelectGame;
			GamePanel.Assign(GameSelection, SelectedGame.GameNameShortend);
			ActivitySelection();
		}

		internal void SelectActivity(int Num)
		{
			ActivityNum = Num;
			ActivityPanel.Assign(ActivitySelection, SelectedGame.GroupFinder[ActivityNum].ActivityShortend);
			RegionSelection();
		}

		internal void SelectRegion(int Num)
		{
			RegionNum = Num;
			string RegionString = SelectedGame.GroupFinder[ActivityNum].Regions[RegionNum].ToString();
			RegionPanel.Assign(RegionSelection, RegionString);

			JoinPanel.gameObject.SetActive(true);
			JoinPanel.Assign(SelectedGame.GroupFinder[ActivityNum].Activity, SelectedGame.GroupFinder[ActivityNum].ActivityDescription);
		}
	}
}
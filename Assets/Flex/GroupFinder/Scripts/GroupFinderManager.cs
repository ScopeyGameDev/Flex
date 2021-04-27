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

		void Start()
		{
			GameSelection();
		}

		void GameSelection()
		{
			GamePanel.Assign(GameSelection);

			foreach (GameInfo Game in Games.GamesList)
			{
				if (Game.GroupFinder.Count > 0)
				{
					// Game.GameName
					// Create List for Game
				}
			}
		}

		void ActivitySelection()
		{
			ActivityPanel.Assign(ActivitySelection);

			foreach (Games.GroupFinder Activity in SelectedGame.GroupFinder)
			{
				// Activity.Activity;
				// Create List for Activities
			}
		}

		void RegionSelection()
		{
			RegionPanel.Assign(RegionSelection);

			foreach (RegionsENUM Region in SelectedGame.GroupFinder[ActivityNum].Regions)
			{
				// Create List for Regions
			}
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flex.Guides
{
    public class GuidesManager : MonoBehaviour
    {
        [SerializeField] Games.Games Games;

        [Header("Guides General")]
        [SerializeField] Transform GuidesGeneralParent;
        [SerializeField] Transform GuidesGeneralTransform;
        [SerializeField] GuidesGeneral GuidesGeneral;


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
    }
}
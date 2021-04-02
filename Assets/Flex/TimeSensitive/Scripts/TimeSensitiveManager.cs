using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flex.TimeSensitive
{
    public class TimeSensitiveManager : MonoBehaviour
    {
        [SerializeField] List<TimeSensitiveGame> TimeSensitiveGames;

        [SerializeField] Transform ContentTransform;

        [SerializeField] TimeSensitiveContent TimeSensitiveContent;

        void Start() 
        {
            foreach (TimeSensitiveGame Game in TimeSensitiveGames)
            {
                TimeSensitiveContent CreatedTimeSensitiveContent = Instantiate(TimeSensitiveContent, ContentTransform);
                CreatedTimeSensitiveContent.Create(Game);
            }
        }
    }
}
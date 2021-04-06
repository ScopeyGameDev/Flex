using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Flex.Navigation
{
    public class NavigationManager : MonoBehaviour
    {
        [SerializeField] Button BackButton;

        // Start is called before the first frame update
        void Start()
        {
            BackButton.gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        internal void SetBackButton(UnityAction Event)
        {
            BackButton.gameObject.SetActive(true);
            BackButton.onClick.AddListener(delegate {BackButtonPressed(Event);});
        }

        void BackButtonPressed(UnityAction Event)
        {
            Event.Invoke();
            BackButton.onClick.RemoveAllListeners();
            BackButton.gameObject.SetActive(false);
        }
    }
}
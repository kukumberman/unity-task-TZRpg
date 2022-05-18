using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Cucumba.SO;

namespace Cucumba.UI
{
    public class PlayerProfileView : MonoBehaviour
    {
        [SerializeField] private Image m_Image = null;

        [Inject]
        private SignalBus m_SignalBus = null;

        [Inject]
        private PlayerProfileModel m_PlayerProfile = null;

        [Inject]
        private CharacterItemsStorage m_CharactersStorage = null;

        // not sure if its ok to use unity's life-cycle methods
        private void Start()
        {
            CharacterItem itemToDisplay = m_CharactersStorage.Get(m_PlayerProfile.SelectedCharacterId);
            UpdateVisual(itemToDisplay);
        }

        private void OnEnable()
        {
            m_SignalBus.Subscribe<CharacterChangedSignal>(CharacterChangedSignalListener);
        }

        private void OnDestroy()
        {
            m_SignalBus.Unsubscribe<CharacterChangedSignal>(CharacterChangedSignalListener);
        }

        private void CharacterChangedSignalListener(CharacterChangedSignal signal)
        {
            UpdateVisual(signal.Item);
        }

        private void UpdateVisual(CharacterItem itemToDisplay)
        {
            m_Image.sprite = itemToDisplay.Sprite;
        }
    }
}

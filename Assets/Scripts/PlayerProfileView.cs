using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Cucumba.SO;

namespace Cucumba.UI
{
    public class PlayerProfileView : MonoBehaviour
    {
        [SerializeField] private Image m_Image = null;

        private PlayerProfileModel m_PlayerProfile = null;
        private CharacterItemsStorage m_CharactersStorage = null;

        [Inject]
        public void Construct(PlayerProfileModel profile, CharacterItemsStorage characterStorage)
        {
            m_PlayerProfile = profile;
            m_CharactersStorage = characterStorage;

            // should i call it here?
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            CharacterItem itemToDisplay = m_CharactersStorage.Get(m_PlayerProfile.SelectedCharacterId);

            m_Image.sprite = itemToDisplay.Sprite;
        }
    }
}

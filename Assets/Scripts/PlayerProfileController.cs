using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Cucumba.SO;

namespace Cucumba
{
    public class PlayerProfileController : MonoBehaviour
    {
        [SerializeField] private Button m_RandomizeButton = null;

        [Inject]
        private ICharacterRandomizer m_CharacterRandomizer = null;

        [Inject]
        private PlayerProfileModel m_PlayerProfile = null;

        private void Start()
        {
            m_RandomizeButton.onClick.AddListener(RandomizeHandler);
        }

        private void RandomizeHandler()
        {
            CharacterItem randomizedItem = m_CharacterRandomizer.Randomize();

            m_PlayerProfile.SelectedCharacterId = randomizedItem.Id;
        }
    }
}

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
        private SignalBus m_SignalBus = null;

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

            // better to move this line into non-existing "save context" and listen for the signal
            m_PlayerProfile.SelectedCharacterId = randomizedItem.Id;

            m_SignalBus.Fire(new CharacterChangedSignal() { Item = randomizedItem });
        }
    }
}

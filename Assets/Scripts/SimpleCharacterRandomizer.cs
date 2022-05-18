using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cucumba.SO;
using Zenject;

namespace Cucumba
{
    public class SimpleCharacterRandomizer : ICharacterRandomizer
    {
        [Inject]
        private readonly CharacterItemsStorage m_CharactersStorage = null;

        private int m_PreviousIndex = -1;

        public CharacterItem Randomize()
        {
            int count = m_CharactersStorage.Items.Count;

            int randomIndex = Random.Range(0, count);

            // simple check is used to prevent same items in a sequence
            if (randomIndex == m_PreviousIndex)
            {
                randomIndex = (randomIndex + 1) % count;
            }

            m_PreviousIndex = randomIndex;

            return m_CharactersStorage.Items[randomIndex];
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cucumba.SO;
using Zenject;

namespace Cucumba
{
    public class YetAnotherCharacterRandomizer : ICharacterRandomizer, IInitializable
    {
        [Inject]
        private readonly CharacterItemsStorage m_CharactersStorage = null;

        private int m_PreviousIndex = -1;

        private CharacterItem[] m_Items = null;

        public void Initialize()
        {
            int seed = 0;
            m_Items = m_CharactersStorage.Items.ToArray();
            m_Items.Shuffle(seed);
        }

        public CharacterItem Randomize()
        {
            m_PreviousIndex = (m_PreviousIndex + 1) % m_Items.Length;

            return m_Items[m_PreviousIndex];
        }
    }
}

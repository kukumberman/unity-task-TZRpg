using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cucumba.SO
{
    [CreateAssetMenu(fileName = "[CharacterItem]", menuName = "SO/Unique Items/CharacterItem")]
    public class CharacterItem : UniqueItem
    {
        [SerializeField] private Sprite m_Sprite = null;

        public Sprite Sprite => m_Sprite;
    }
}

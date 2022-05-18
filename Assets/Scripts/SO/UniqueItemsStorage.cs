using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cucumba.SO
{
    public abstract class UniqueItemsStorage<T> : ScriptableObject where T : UniqueItem
    {
        // new idea
        // use Dictionary<string, T> to find entry quicker
        // but not visible in the inspector by default, so populate it from list at startup time

        [SerializeField] protected List<T> m_Items = new List<T>();

        public List<T> Items => m_Items;

        public T Get(string id)
        {
            return m_Items.Find(item => item.Id == id);
        }

        public bool Includes(string id)
        {
            return !(Get(id) is null);
        }
    }
}

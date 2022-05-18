using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cucumba.SO
{
    public class UniqueItem : ScriptableObject
    {
        [SerializeField] protected string m_Id = "should be unique";

        public string Id => m_Id;
    }
}

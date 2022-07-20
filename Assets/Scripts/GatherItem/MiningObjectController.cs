using System.Collections;
using System.Collections.Generic;
using SaveData.SO;
using UnityEngine;
// ReSharper disable All

namespace GatherItem
{
    public class MiningObjectController : MonoBehaviour
    {
        [SerializeField] private ItemGather m_itemGather;

        public ItemGather GetItemGather()
        {
            return m_itemGather;
        }
    }

}
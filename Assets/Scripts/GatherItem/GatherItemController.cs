using System.Collections;
using System.Collections.Generic;
using SaveData.SO;
using UnityEngine;
// ReSharper disable All

namespace GatherItem
{
    public class GatherItemController : MonoBehaviour
    {
        [SerializeField] private ItemGather m_itemGather;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public ItemGather GetItemGather()
        {
            return m_itemGather;
        }
    }

}
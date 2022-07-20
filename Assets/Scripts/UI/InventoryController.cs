using System;
using System.Collections.Generic;
using SaveData;
using UnityEngine;
// ReSharper disable All

namespace UI
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField]private List<SlotController> m_allSlot;
        

        private void Update()
        {
            UpdateInventory();
        }

        public void UpdateInventory()
        {
            for (int i = 0; i < BagData.GetAllInventory().itemGathers.Count; i++)
            {
                // tạm thay đổi active của slot
                var icon = BagData.GetAllInventory().itemGathers[i].imageItem;
                var itemGather = BagData.GetAllInventory().itemGathers[i];
                var count = BagData.GetCountItem(itemGather);
                m_allSlot[i].gameObject.SetActive(true);
                m_allSlot[i].SetSlot(icon, count);
            }
        }
    }
}
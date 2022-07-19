using System.Collections;
using System.Collections.Generic;
using SaveData.SO;
using UnityEngine;

// ReSharper disable All
#pragma warning disable CS0219
#pragma warning disable CS0169

namespace SaveData
{
    public class InventoryModel
    {
        public List<ItemGather> itemGathers;
        public int itemMetal;
        public int itemStone;
        public int itemWood;
        public int itemLeather;
        public int itemCloth;

        //set 
        public void AddItem(ItemGather itemGather, int quantity)
        {
            Debug.Log("day la model");
            Debug.Log("count " + itemGathers.Count);
            var hasItem = false;
            // check item trong inventory
            foreach (var item in itemGathers)
            {
                
            }
            if (itemGathers.Count != 0)
            {
                for (int i = 0; i < itemGathers.Count; i++)
                {
                    Debug.Log("chay vong for");
                    // kiểm tra loại item type = nhau tức đã có => + quantity
                    if (itemGathers[i].type == itemGather.type)
                    {
                        hasItem = true;
                        break;
                    }
                }

                if (hasItem == true)
                {
                    Debug.Log("đã có");
                    switch (itemGather.type)
                    {
                        case ItemGatherType.Metal:
                            itemMetal += quantity;
                            break;
                        case ItemGatherType.Stone:
                            itemStone += quantity;
                            break;
                        case ItemGatherType.Wood:
                            itemWood += quantity;
                            break;
                        case ItemGatherType.Leather:
                            itemLeather += quantity;
                            break;
                        case ItemGatherType.Cloth:
                            itemCloth += quantity;
                            break;
                    }
                }
                else
                {
                    Debug.Log("add new");
                    itemGathers.Add(itemGather);
                    switch (itemGather.type)
                    {
                        case ItemGatherType.Metal:
                            itemMetal += quantity;
                            break;
                        case ItemGatherType.Stone:
                            itemStone += quantity;
                            break;
                        case ItemGatherType.Wood:
                            itemWood += quantity;
                            break;
                        case ItemGatherType.Leather:
                            itemLeather += quantity;
                            break;
                        case ItemGatherType.Cloth:
                            itemCloth += quantity;
                            break;
                    }
                }
            }
            else
            {
                Debug.Log("add lan dau");
                itemGathers.Add(itemGather);
                switch (itemGather.type)
                {
                    case ItemGatherType.Metal:
                        itemMetal += quantity;
                        break;
                    case ItemGatherType.Stone:
                        itemStone += quantity;
                        break;
                    case ItemGatherType.Wood:
                        itemWood += quantity;
                        break;
                    case ItemGatherType.Leather:
                        itemLeather += quantity;
                        break;
                    case ItemGatherType.Cloth:
                        itemCloth += quantity;
                        break;
                }
            }
        }

        //get
        public InventoryModel GetAllInventory()
        {
            return this;
        }

        public int GetCountItem(ItemGather itemGather)
        {
            switch (itemGather.type)
            {
                case ItemGatherType.Metal:
                    return itemMetal;
                case ItemGatherType.Stone:
                    return itemStone;
                case ItemGatherType.Wood:
                    return itemWood;
                case ItemGatherType.Leather:
                    return itemLeather;
                case ItemGatherType.Cloth:
                    return itemCloth;
            }

            return 0;
        }
    }

    public static class BagData
    {
        private const string INVENTORY_DATA = "INVENTORY_DATA";
        private static InventoryModel m_inventoryModel;

        static BagData()
        {
            m_inventoryModel = JsonUtility.FromJson<InventoryModel>(PlayerPrefs.GetString(INVENTORY_DATA));
            if (m_inventoryModel == null)
            {
                m_inventoryModel = new InventoryModel
                {
                    itemGathers = new List<ItemGather>(),
                    itemMetal = 0,
                    itemStone = 0,
                    itemWood = 0,
                    itemLeather = 0,
                    itemCloth = 0
                };
            }
        }

        private static void SaveData()
        {
            var data = JsonUtility.ToJson(m_inventoryModel);
            PlayerPrefs.SetString(INVENTORY_DATA, data);
        }

        //set
        public static void AddItem(ItemGather itemGather, int quantity)
        {
            Debug.Log("goi sang inventory model");
            m_inventoryModel.AddItem(itemGather, quantity);
            SaveData();
        }
        //get

        public static InventoryModel GetAllInventory()
        {
            return m_inventoryModel.GetAllInventory();
        }

        public static int GetCountItem(ItemGather itemGather)
        {
            return m_inventoryModel.GetCountItem(itemGather);
        }
    }
}
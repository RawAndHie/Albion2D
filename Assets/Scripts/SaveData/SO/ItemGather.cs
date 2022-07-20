using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0108, CS0114

namespace SaveData.SO
{
    public enum ItemGatherType
    {
        Cloth,
        Wood,
        Metal,
        Stone,
        Leather
    }

    [CreateAssetMenu(fileName = "New Item Gather", menuName = "Item Gather")]
    public class ItemGather : ScriptableObject
    {
        public ItemGatherType type;
        public Sprite imageItem;
        public int price;
        public int fameValue;
        public int maxStackSize;
        public int itemValue;
        public int level;
        public int tier;
        public float timeMining;

        public void SetLevel(int l, int t)
        {
            tier = t;
            level = l;
        }
        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable CS0108, CS0114

namespace SaveData.SO
{
    [CreateAssetMenu(fileName = "Mine Object", menuName = "Mine Object")]
    public class MiningObject : ScriptableObject
    {
        public string name;
        public int totalItem;
    }
}

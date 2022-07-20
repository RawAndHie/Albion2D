using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveData.SO
{
    [CreateAssetMenu(fileName = "Mining Tool", menuName = "Mining Tool/Tool")]
    public class MiningTool : ScriptableObject
    {
        public float maxMiningRate;
    }
}

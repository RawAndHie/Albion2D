using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveData.SO
{
    [CreateAssetMenu(fileName = "Mining Tool", menuName = "Mining Tool/Tool")]
    public class MiningTool : ScriptableObject
    {
        public float miningRate;
        public int level; // dùng (level+1) tính kinh nghiệm cho level tiếp theo. khi exp đạt tới thì cho lên level và tính tiếp
        public int exp;  // 
    }
}

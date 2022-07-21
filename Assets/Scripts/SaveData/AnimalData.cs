using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable CS0108, CS0114

namespace SaveData
{
    [CreateAssetMenu(fileName = "New Animal", menuName = "Animal")]
    public class AnimalData : ScriptableObject
    {
        public string name;
        public float baseHp;
        public float growthHp;
        public float baseDamage;
        public float growthDamage;

        public float GetHealth(int level)
        {
            // tính toắn health theo tier hiện tại
            float health =  baseHp + growthHp*(level-1) + 
                           (1/(130 * (float)Math.Pow(level, 1))) * 
                           (float)Math.Pow(level-1, 3) + 
                           (float)Math.Pow(level-1, 1.6f) ;
            return health;
        }

        public float GetDamage(int level)
        {
            float damage = baseDamage + growthDamage*(level-1) + 
                           (1/(130 * (float)Math.Pow(level, 1))) * (float)Math.Pow(level-1, 3) + 
                           (float)Math.Pow(level-1, 1.6f);
            return damage;
        }
    }
}

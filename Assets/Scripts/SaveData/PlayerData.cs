using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ReSharper disable All
#pragma warning disable CS0169

namespace SaveData
{
    public class PlayerModel
    {
        // public float baseHealth;
        // public float baseDamage;
        // public float growthHealth;
        // public float growthDamage;
        public int fameWeapon;
        public int fameAmor;
        
    }

    public static class PlayerData
    {
        private const string PLAYER_DATA = "PLAYER_DATA";
        private static PlayerModel m_playerModel;

        static PlayerData()
        {
            m_playerModel = JsonUtility.FromJson<PlayerModel>(PlayerPrefs.GetString(PLAYER_DATA));
            if (m_playerModel == null)
            {
                m_playerModel = new PlayerModel
                {
                    fameAmor = 0,
                    fameWeapon = 0
                };
            }
        }

        private static void SaveData()
        {
            var data = JsonUtility.ToJson(m_playerModel);
            PlayerPrefs.SetString(PLAYER_DATA, data);
        }
    }
}
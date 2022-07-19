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
        public int famePickaxe; // weapon metal
        public int fameHammer; // weapon stone
        public int fameAxe; // weapon wood
        public int fameKnife; // weapon skinner
        public int fameSickle; // weapon colth
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
                    fameWeapon = 0,
                    fameAmor = 0,
                    famePickaxe = 0,
                    fameHammer = 0,
                    fameAxe = 0,
                    fameKnife = 0,
                    fameSickle = 0
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
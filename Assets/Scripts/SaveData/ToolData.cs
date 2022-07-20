using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ReSharper disable All

namespace SaveData
{
    public enum TypeTool
    {
        Pickaxe,
        Hammer,
        Axe,
        Knife,
        Sickle
    }

    public class ToolModel
    {
        public int famePickaxe; // weapon metal
        public int fameHammer; // weapon stone
        public int fameAxe; // weapon wood
        public int fameKnife; // weapon skinner
        public int fameSickle; // weapon colth
        public int levelPickaxe;
        public int levelHammer;
        public int levelAxe;
        public int levelKnife;
        public int levelSickle;
    }

    public static class ToolData
    {
        private const string TOOL_DATA = "TOOL_DATA";
        private static ToolModel m_toolModel;

        static ToolData()
        {
            m_toolModel = JsonUtility.FromJson<ToolModel>(PlayerPrefs.GetString(TOOL_DATA));
            if (m_toolModel == null)
            {
                m_toolModel = new ToolModel
                {
                    famePickaxe = 0,
                    fameHammer = 0,
                    fameAxe = 0,
                    fameKnife = 0,
                    fameSickle = 0,
                    levelPickaxe = 1,
                    levelHammer = 1,
                    levelAxe = 1,
                    levelKnife = 1,
                    levelSickle = 1
                };
            }
        }

        private static void SaveData()
        {
            var data = JsonUtility.ToJson(m_toolModel);
            PlayerPrefs.SetString(TOOL_DATA, data);
        }
    }
}
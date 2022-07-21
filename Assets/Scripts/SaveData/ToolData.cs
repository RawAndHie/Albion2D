using System;
using System.Collections;
using System.Collections.Generic;
using SaveData.SO;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

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

        // tính toán tool level 
        public void SetToolLevel()
        {
            // khi nhận exp thì tính luôn level
            var nextLevelPickaxe = levelPickaxe + 1;
            int needExpPickaxe = 135 + 70 * (nextLevelPickaxe - 1) +
                                 (1 / (130 * (int) Math.Pow(nextLevelPickaxe, 1))) *
                                 (int) Math.Pow(nextLevelPickaxe - 1, 3) +
                                 (int) Math.Pow(nextLevelPickaxe - 1, 1.6f);
            if (famePickaxe >= needExpPickaxe)
            {
                levelPickaxe++;
            }

            // khi nhận exp thì tính luôn level
            var nextLevelHammer = levelHammer + 1;
            int needExpHammer = 135 + 70 * (nextLevelHammer - 1) +
                                (1 / (130 * (int) Math.Pow(nextLevelHammer, 1))) *
                                (int) Math.Pow(nextLevelHammer - 1, 3) +
                                (int) Math.Pow(nextLevelHammer - 1, 1.6f);
            if (fameHammer >= needExpHammer)
            {
                levelHammer++;
            }


            // khi nhận exp thì tính luôn level
            var nextLevelAxe = levelAxe + 1;
            int needExpAxe = 135 + 70 * (nextLevelAxe - 1) +
                             (1 / (130 * (int) Math.Pow(nextLevelAxe, 1))) *
                             (int) Math.Pow(nextLevelAxe - 1, 3) +
                             (int) Math.Pow(nextLevelAxe - 1, 1.6f);
            if (fameAxe >= needExpAxe)
            {
                levelAxe++;
            }

            // khi nhận exp thì tính luôn level
            var nextLevelKnife = levelKnife + 1;
            int needExpKnife = 135 + 70 * (nextLevelKnife - 1) +
                               (1 / (130 * (int) Math.Pow(nextLevelKnife, 1))) *
                               (int) Math.Pow(nextLevelKnife - 1, 3) +
                               (int) Math.Pow(nextLevelKnife - 1, 1.6f);
            if (fameKnife >= needExpKnife)
            {
                levelKnife++;
            }

            // khi nhận exp thì tính luôn level
            var nextLevelSickle = levelSickle + 1;
            int needExpSickle = 135 + 70 * (nextLevelSickle - 1) +
                                (1 / (130 * (int) Math.Pow(nextLevelSickle, 1))) *
                                (int) Math.Pow(nextLevelSickle - 1, 3) +
                                (int) Math.Pow(nextLevelSickle - 1, 1.6f);
            if (fameSickle >= needExpSickle)
            {
                levelSickle++;
            }
        }
    
    //set
    public void SetFame(ItemGatherType type, int fameValue)
    {
        switch (type)
        {
            case ItemGatherType.Metal:
                famePickaxe += fameValue;
                break;
            case ItemGatherType.Stone:
                fameHammer += fameValue;
                break;
            case ItemGatherType.Wood:
                fameAxe += fameValue;
                break;
            case ItemGatherType.Leather:
                fameKnife += fameValue;
                break;
            case ItemGatherType.Cloth:
                fameSickle += fameValue;
                break;
        }
    }

    //get
    public string GetFameValue()
    {
        return "famePickaxe : " + famePickaxe + "\nfameHammer : " + fameHammer +
               "\nfameAxe : " + fameAxe + "\nfameKnife : " + fameKnife + "\nfameSickle : " + fameSickle;
    }

    public string GetLevelValue()
    {
        return "levelPickaxe : " + levelPickaxe + "\nlevelHammer : " + levelHammer +
               "\nlevelAxe : " + levelAxe + "\nlevelKnife : " + levelKnife + "\nlevelSickle : " + levelSickle;
    }
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

    // set
    public static void SetFame(ItemGatherType type, int fameValue)
    {
        m_toolModel.SetFame(type, fameValue);
        m_toolModel.SetToolLevel();
        SaveData();
    }

    //get
    public static string GetFame()
    {
        return m_toolModel.GetFameValue();
    }

    public static String GetLevel()
    {
        return m_toolModel.GetLevelValue();
    }
}

}
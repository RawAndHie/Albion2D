using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable All
#pragma warning disable CS0169

namespace Manager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject m_miningBarOnject;
        [SerializeField] private Image m_miningBarFill;
        private static UIManager m_instance;
        public static UIManager Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = FindObjectOfType<UIManager>();
                }

                return m_instance;
            }
        }

        [SerializeField] private GameObject m_inventory;
        private void Awake()
        {
            if (m_instance == null)
            {
                m_instance = this;
            }
            else if(m_instance != this)
            {
                Destroy(gameObject);
            }
        }

        public void SetMiningBar(float currentTime, float maxTime)
        {
            if (currentTime >0 && currentTime < maxTime)
            {
                m_miningBarOnject.SetActive(true);
                m_miningBarFill.fillAmount = currentTime / maxTime;
            } else if (currentTime < 0 || currentTime > maxTime) 
            {
                m_miningBarOnject.SetActive(false);
            }
        }
        public void OpenInventory()
        {
            //!m_inventory.gameObject.activeSelf false
            if (!m_inventory.activeSelf)
            {
                m_inventory.SetActive(true);
            }
            else
            {
                m_inventory.SetActive(false);
            }
        }

    }
}

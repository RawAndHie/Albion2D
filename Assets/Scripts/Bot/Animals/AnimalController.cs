using System;
using System.Collections;
using System.Collections.Generic;
using SaveData;
using UnityEngine;
// ReSharper disable All
#pragma warning disable CS0649
#pragma warning disable CS0169

namespace Bot.Animals
{
    public class AnimalController : MonoBehaviour
    {
        [SerializeField] private int m_level;
        [SerializeField] private AnimalData m_animalData;
        private float m_health;
        private float m_damage;
        private float m_idleTime;
       
        private void Start()
        {
            m_idleTime = 3f;
            GetInfoAnimal();
        }

        private void Update()
        {
            UpdateState();
            
        }

        private void GetInfoAnimal()
        {
            m_damage = m_animalData.GetDamage(m_level);
            m_health = m_animalData.GetHealth(m_level);
        }
        private void UpdateState()
        {
            m_idleTime -= Time.deltaTime;
            if (m_idleTime <= 0)
            {
                // cho di chuyển ngẫu nhiên rồi quay lại cho idle = 3
                m_idleTime = 3f;
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Manager;
using SaveData;
using UnityEngine;
// ReSharper disable All
#pragma warning disable CS0649
#pragma warning disable CS0169

namespace Mob.Animals
{
    public class MobController : MonoBehaviour
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

        public void Hit(float damage)
        {
            Debug.Log(m_health);
            m_health -= damage;
            if (m_health <= 0)
            {
                Destroy(gameObject);
               // SpawnManager.Instance.ReleaseMob(this); // hiện tại chưa có trong spawn manager
               SpawnManager.Instance.SpawnLeather(transform.position);
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager m_instance;

        public static GameManager Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = FindObjectOfType<GameManager>();
                }

                return m_instance;
            }
        }

        private void Awake()
        {
            if (m_instance != this)
            {
                Destroy(gameObject);
            } else if (m_instance == null)
            {
                m_instance = this;
            }

            StartGame();
        }

        private void StartGame()
        {
            SpawnManager.Instance.SpawnPlayer();
        }
    }
}

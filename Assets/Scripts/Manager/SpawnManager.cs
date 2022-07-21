using System;
using System.Collections;
using System.Collections.Generic;
using Mob.Animals;
using GatherItem;
using Player;
using SaveData;
using UnityEngine;
using Random = UnityEngine.Random;

// ReSharper disable All
#pragma warning disable CS0169

namespace Manager
{
    // player pool
    [Serializable]
    public class PlayerPool
    {
        public PlayerController m_prefab;
        public List<PlayerController> activeObj;
        public List<PlayerController> inactiveObj;

        public PlayerController SpawnObj(Vector3 position, Transform transform)
        {
            if (inactiveObj.Count == 0)
            {
                PlayerController obj = GameObject.Instantiate(m_prefab);
                obj.transform.position = position;
                obj.transform.SetParent(transform);
                activeObj.Add(obj);
                return obj;
            }
            else
            {
                PlayerController obj = inactiveObj[0];
                obj.transform.position = position;
                inactiveObj.RemoveAt(0);
                activeObj.Add(obj);
                return obj;
            }
        }

        public void ReleaseObj(PlayerController obj)
        {
            if (activeObj.Contains(obj))
            {
                obj.gameObject.SetActive(false);
                activeObj.Remove(obj);
                inactiveObj.Add(obj);
            }
        }
    }

    // mob pool
    [Serializable]
    public class MobPool
    {
        public MobController m_prefab;
        public List<MobController> activeObj;
        public List<MobController> inactiveObj;

        public MobController SpawnMob(Vector3 position, Transform transform)
        {
            if (inactiveObj.Count == 0)
            {
                MobController obj = GameObject.Instantiate(m_prefab);
                obj.transform.position = position;
                obj.transform.SetParent(transform);
                activeObj.Add(obj);
                return obj;
            }
            else
            {
                MobController obj = inactiveObj[0];
                obj.transform.position = position;
                inactiveObj.RemoveAt(0);
                activeObj.Add(obj);
                return obj;
            }
        }

        public void ReleaseMob(MobController mob)
        {
            if (activeObj.Contains(mob))
            {
                mob.gameObject.SetActive(false);
                activeObj.Remove(mob);
                inactiveObj.Add(mob);
            }
        }
    }

    //object mine
    [Serializable]
    public class ObjectMinePool
    {
        public MiningObjectController m_prefab;
        public List<MiningObjectController> activeObj;
        public List<MiningObjectController> inactiveObj;

        public MiningObjectController SpawnObj(Vector3 position, Transform transform)
        {
            if (inactiveObj.Count == 0)
            {
                MiningObjectController obj = GameObject.Instantiate(m_prefab, transform);
                obj.transform.position = position;
                obj.transform.SetParent(transform);
                activeObj.Add(obj);
                return obj;
            }
            else
            {
                MiningObjectController obj = inactiveObj[0];
                obj.transform.position = position;
                obj.gameObject.SetActive(true);
                obj.transform.SetParent(transform);
                activeObj.Add(obj);
                inactiveObj.RemoveAt(0);
                return obj;
            }
        }

        public void ReleaseObj(MiningObjectController obj)
        {
            if (activeObj.Contains(obj))
            {
                obj.gameObject.SetActive(false);
                activeObj.Remove(obj);
                inactiveObj.Add(obj);
            }
        }
    }

    public class SpawnManager : MonoBehaviour
    {
        [Header("Prefabs")] [SerializeField] private PlayerPool m_playerPool;
        [SerializeField] private MobPool m_animalPool;
        [SerializeField] private ObjectMinePool m_leatherPool;

        [Header("Other")] [SerializeField] private Transform m_pointSpawn;
        private static SpawnManager m_instance;

        public static SpawnManager Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = FindObjectOfType<SpawnManager>();
                }

                return m_instance;
            }
        }

        private PlayerController m_player;
        public PlayerController Player => m_playerPool.m_prefab;

        private void Awake()
        {
            if (m_instance == null)
            {
                m_instance = this;
            }
            else if (m_instance != this)
            {
                Destroy(gameObject);
            }

            for (int i = 0; i < 20; i++)
            {
                SpawnMob(new Vector3(Random.Range(3f, -3f), Random.Range(3f, -3f)));
            }
        }
        

        // release & spawn mob
        public MobController SpawnMob(Vector3 localtion)
        {
            MobPool pooling = new MobPool();
            pooling = m_animalPool;
            MobController mob = pooling.SpawnMob(localtion, transform);
            return mob;
        }

        public void ReleaseMob(MobController mob)
        {
            MobPool pooling = m_animalPool;
            pooling.ReleaseMob(mob);
        }

        // release & spawn obj mine
        public MiningObjectController SpawnLeather(Vector3 localtion)
        {
            ObjectMinePool pooling = new ObjectMinePool();
            pooling = m_leatherPool;
            MiningObjectController obj = pooling.SpawnObj(localtion, transform);
            return obj;
        }

        public void ReleaseLeather(MiningObjectController obj)
        {
            ObjectMinePool pooling = m_leatherPool;
            pooling.ReleaseObj(obj);
        }

        // release and spawn player
        public PlayerController SpawnPlayer()
        {
            // if player state = dead
            PlayerPool pool = new PlayerPool();
            pool = m_playerPool;
            PlayerController obj = pool.SpawnObj(m_pointSpawn.position, transform);
            return obj;
        }

        public void ReleasePlayer(PlayerController obj)
        {
            PlayerPool pool = m_playerPool;
            pool.ReleaseObj(obj);
        }
    }
}
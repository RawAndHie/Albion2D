using System;
using System.Collections;
using System.Collections.Generic;
using Mob.Animals;
using GatherItem;
using Manager;
using SaveData;
using SaveData.SO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

#pragma warning disable CS0414

// ReSharper disable All
#pragma warning disable CS0169

namespace Player
{
    public enum PlayerState
    {
        Idle,
        Dead,
        Mining,
        Attack,
        Move
    }

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Animator m_animator;
        private PlayerState m_playerState;
        private MiningObjectController m_itemGather;
        private MobController m_mobTrigger;
        private bool m_isTriggerMiningObject = false;
        private bool m_isTriggerMob = false;
        private float m_currentMiningTime;

        private void Start()
        {
            SetPlayerState(PlayerState.Idle);
            m_currentMiningTime = 100;
        }

        private void Update()
        {
            PlayerInputs();
            SetTimeMining();
        }

        private void Attack()
        {
            m_mobTrigger.Hit(100);
            StartCoroutine(AttackState());
        }

        private void SetTimeMining()
        {
            UIManager.Instance.SetMiningBar(m_currentMiningTime, 5);
            if (m_playerState != PlayerState.Mining)
            {
                m_currentMiningTime = 100;
            }

            if (m_playerState == PlayerState.Mining)
            {
                m_currentMiningTime += Time.deltaTime;
            }
        }

        private void PlayerInputs()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                UIManager.Instance.OpenInventory();
            }

            if (m_isTriggerMiningObject == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SetPlayerState(PlayerState.Mining);
                    StartCoroutine(MiningState(5));
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SetPlayerState(PlayerState.Attack);
                m_animator.SetTrigger("Attack");
                if (m_isTriggerMob == true)
                {
                    Attack();
                }
            }
        }


        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Mining Object"))
            {
                m_isTriggerMiningObject = true;
                MiningObjectController miningObjectController;
                col.gameObject.TryGetComponent(out miningObjectController);
                m_itemGather = miningObjectController;
                // BagData.AddItem(gatherItemController.GetItemGather(), Random.Range(1,5));
            }

            if (col.gameObject.CompareTag("Animal"))
            {
                m_isTriggerMob = true;
                MobController mobController;
                col.gameObject.TryGetComponent(out mobController);
                m_mobTrigger = mobController;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Mining Object"))
            {
                m_isTriggerMiningObject = false;
            }

            if (other.gameObject.CompareTag("Animal"))
            {
                m_isTriggerMob = false;
            }
        }

        private IEnumerator MiningState(float maxTime)
        {
            //  khi bắt đầu mine current time < maxTime -> hiển thị fill

            m_currentMiningTime = 0;
            yield return new WaitForSeconds(maxTime);
            if (m_playerState != PlayerState.Mining)
            {
                yield break;
            }

            BagData.AddItem(m_itemGather.GetItemGather(), Random.Range(1, 5));
            ToolData.SetFame(m_itemGather.GetItemGather().type, m_itemGather.GetItemGather().fameValue);
            SetPlayerState(PlayerState.Idle);
        }

        private IEnumerator AttackState()
        {
            yield return new WaitForSeconds(0.3f);
            SetPlayerState(PlayerState.Attack);
        }

        public void SetPlayerState(PlayerState state)
        {
            m_playerState = state;
        }
    }
}
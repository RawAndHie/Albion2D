using System;
using System.Collections;
using System.Collections.Generic;
using GatherItem;
using Manager;
using SaveData;
using SaveData.SO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

// ReSharper disable All
#pragma warning disable CS0169

namespace Player
{
    public enum PlayerState
    {
        Alive,
        Dead,
        Mining
    }

    public class PlayerController : MonoBehaviour
    {
        private GatherItemController m_itemGather;
        private bool m_isTriggerMiningObject = false;
        private float m_currentMiningTime;

        private void Start()
        {
            m_currentMiningTime = 100;
        }

        private void Update()
        {
            PlayerInputs();
            m_currentMiningTime += Time.deltaTime;
            UIManager.Instance.SetMiningBar(m_currentMiningTime, 5);
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
                    StartCoroutine(WaitOneSecond(5));
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Mining Object"))
            {
                m_isTriggerMiningObject = true;
                GatherItemController gatherItemController;
                col.gameObject.TryGetComponent(out gatherItemController);
                m_itemGather = gatherItemController;
                // BagData.AddItem(gatherItemController.GetItemGather(), Random.Range(1,5));
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Mining Object"))
            {
                m_isTriggerMiningObject = false;
            }
        }

        private IEnumerator WaitOneSecond(float maxTime)
        {
            Debug.Log("bắt đầu mining");
            m_currentMiningTime = 0;
            yield return new WaitForSeconds(maxTime);
            BagData.AddItem(m_itemGather.GetItemGather(), Random.Range(1,5));
            Debug.Log("xong nhé");
        }
    }
}
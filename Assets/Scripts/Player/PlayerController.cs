using System;
using System.Collections;
using System.Collections.Generic;
using GatherItem;
using Manager;
using SaveData;
using SaveData.SO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Player
{
    public enum PlayerState
    {
        Alive, Dead, Mining
    }
    public class PlayerController : MonoBehaviour
    {
        private void Update()
        {
            PlayerInputs();
        }

        private void PlayerInputs()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                UIManager.Instance.OpenInventory();
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Mining Object"))
            {
                Debug.Log("va cham");
                GatherItemController gatherItemController;
                col.gameObject.TryGetComponent(out gatherItemController);
                BagData.AddItem(gatherItemController.GetItemGather(), Random.Range(1,5));
            }
        }
    }
}

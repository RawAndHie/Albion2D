using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable All
#pragma warning disable CS0649

namespace UI
{
    public class SlotController : MonoBehaviour
    {
        [SerializeField] private Image m_icon;
        [SerializeField] private TextMeshProUGUI m_countItem;
        [SerializeField] private GameObject m_item;
        public void SetSlot(Sprite icon, int totalItem)
        {
            m_item.gameObject.SetActive(true);
            m_icon.sprite = icon;
            m_countItem.text = "" + totalItem;
        }
    }
}
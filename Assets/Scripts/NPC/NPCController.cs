using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace NPC
{
    public class NPCController : MonoBehaviour
    {
        [SerializeField] private GameObject m_canvas;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                m_canvas.gameObject.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                m_canvas.gameObject.SetActive(false);
            }
        }
    }
}

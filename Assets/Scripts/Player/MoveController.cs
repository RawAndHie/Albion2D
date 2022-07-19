using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ReSharper disable All

namespace Player
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField] private float m_moveSpeed;

        private Vector3 m_moveDelta;

        private Rigidbody2D m_rigidbody;

        // Start is called before the first frame update
        void Start()
        {
            m_rigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            float horizontalMove = Input.GetAxis("Horizontal");
            float verticalMove = Input.GetAxis("Vertical");
            m_moveDelta = new Vector3(horizontalMove, verticalMove, 0);

            if (Application.platform == RuntimePlatform.WindowsEditor ||
                Application.platform == RuntimePlatform.WindowsPlayer)
            {
                if (m_moveDelta.x > 0)
                {
                    transform.localScale = Vector3.one;
                }
                else if (m_moveDelta.x < 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                m_rigidbody.velocity = new Vector2(horizontalMove, verticalMove) * m_moveSpeed;
            }
        }
    }
}
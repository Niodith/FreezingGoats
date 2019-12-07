using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public AudioSource honkSound;
    [SerializeField] private LayerMask m_WhatIsYeetable;
    const float k_yeetableRadius = .5f;
    [SerializeField] private Transform m_GroundCheck;

    // Start is called before the first frame update
    void Start()
    {
        honkSound = GetComponent<AudioSource>();
    }

    public void Honk(bool isHonking)
    {
        if (isHonking)
        {
            honkSound.Play();
        }

    }

    public void Yeet(bool isYeeting)
    {
        if (isYeeting)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_yeetableRadius, m_WhatIsYeetable);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    isYeeting = true;
                    gameObject.layer.CompareTo(i);
                    


                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

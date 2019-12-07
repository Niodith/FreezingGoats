﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public AudioSource honkSound;
    [SerializeField] private LayerMask m_WhatIsYeetable;
    [SerializeField] private float k_yeetableRadius = .5f;
    [SerializeField] private Transform m_AttackPosition;
    [SerializeField] private Vector2  m_scalingYeetPower;
    [SerializeField] private Vector2 m_minimumYeetPower;

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

    public void Yeet(float yeets)
    {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_AttackPosition.position, k_yeetableRadius, m_WhatIsYeetable);
            for (int i = 0; i < colliders.Length; i++)
            {
            if (colliders[i].gameObject != gameObject)
            {
                Rigidbody2D targetRB = colliders[i].gameObject.GetComponent<Rigidbody2D>();

                if (targetRB != null)
                {
                    targetRB.freezeRotation = false;
                    float faceDir = gameObject.transform.localScale.x;

                    Vector2 force = new Vector2(faceDir * (m_minimumYeetPower.x + yeets * m_scalingYeetPower.x), m_minimumYeetPower.y + yeets * m_scalingYeetPower.y);
                    Vector2 force2 = (force + new Vector2(force.x, 0f))/3f;

                    StartCoroutine(kickAfterFrames(targetRB, force, force / 2f));

                }

            }
            } 

        // Update is called once per frame
        void Update()
        {

        }
    }






    public IEnumerator kickAfterFrames(Rigidbody2D r2b2, Vector2 force1, Vector2 forceAfterSecond)
    {
        yield return new WaitForFixedUpdate();
        r2b2.AddForce(force1);
        r2b2.angularVelocity = -force1.x;
        yield return new WaitForSeconds(0.5f);

        r2b2.AddForce(forceAfterSecond);
    }
}

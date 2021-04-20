using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperEnemy : Enemy
{
    public Transform m_rocket;

    protected float m_fireTimer = 2;

    protected Transform m_player;

    protected AudioSource m_audio;

    public AudioClip m_shootClip;
    
    private void Start()
    {
        m_audio = this.GetComponent<AudioSource>();
    }
    protected override void UpdateMove()
    {
        m_fireTimer -= Time.deltaTime;

        if (m_fireTimer <= 0)
        {
            m_fireTimer = 2;
            if (m_player != null)
            {
                Vector3 relativePos = m_player.position - this.transform.position;
                m_audio.PlayOneShot(m_shootClip);
                Instantiate(m_rocket, transform.position, Quaternion.LookRotation(relativePos));
            }
            else
            {
                GameObject obj = GameObject.FindGameObjectWithTag("Player");
                if (obj != null)
                {
                    m_player = obj.transform;
                }
            }

        }
        this.transform.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));

    }


}

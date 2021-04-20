using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float m_speed = 1;

    public int m_life = 1;

    protected float m_rotSpeed = 30;

    internal Renderer m_renderer;

    internal bool m_isActive = false;

    public Transform m_explosionFX;

    public int m_point = 10;

    void OnBecameVisible()
    {
        m_isActive = true;
        m_renderer = this.GetComponent<Renderer>();
    }


    // Update is called once per frame
    void Update()
    {
        UpdateMove();
        if(m_isActive && !m_renderer.isVisible)
        {
            Destroy(this.gameObject);
        }
    }

    protected virtual void UpdateMove()
    {
        float rx = Mathf.Sin(Time.time) * Time.deltaTime;
        transform.Translate(new Vector3(rx, 0, -m_speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerRocket")
        {
            Rocket rocket = other.GetComponent<Rocket>();
            if (rocket != null)
            {
                m_life -= rocket.m_power;
                if (m_life <= 0)
                {
                    Destroy(this.gameObject);
                    Instantiate(m_explosionFX, transform.position, Quaternion.identity);
                    GameManager.Instance.AddScore(m_point);
                }
            }
        }
        else if (other.tag == "Player")
        {
            m_life = 0;
            Destroy(this.gameObject);
        }
    }
}

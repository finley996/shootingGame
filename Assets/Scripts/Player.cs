using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float m_speed = 5;

    public Transform m_rocket;

    private Transform m_transform;

    public int m_life = 3;

    private float m_rocketTimer = 0;

    public AudioClip m_shootClip;

    protected AudioSource m_audio;

    public Transform m_explosionFX;


    private void Start()
    {
        m_transform = this.transform;
        m_audio = this.GetComponent<AudioSource>();
    }
    void Update()
    {
        float move_vertical = 0;
        float move_horizon = 0;
        float move = m_speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            move_vertical += move;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            move_vertical -= move;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move_horizon -= move;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            move_horizon += move;
        }
        m_transform.Translate(new Vector3(move_horizon, 0, move_vertical));

        m_rocketTimer -= Time.deltaTime;
        if (m_rocketTimer <= 0)
        {
            m_rocketTimer = 0.1f;
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                Instantiate(m_rocket, m_transform.position, m_transform.rotation);
                m_audio.PlayOneShot(m_shootClip);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "PlayerRocket")
        {
            m_life--;
            GameManager.Instance.ChangeLife(m_life);
            if (m_life <= 0)
            {
                Instantiate(m_explosionFX, m_transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}

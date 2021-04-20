using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float m_speed = 10;

    public int m_power = 1;

    private void OnBecameInvisible()
    {
        if (this.enabled)
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        this.transform.Translate(0, 0, m_speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Enemy")
        {
            return;
        }
        Destroy(this.gameObject);
    }
}

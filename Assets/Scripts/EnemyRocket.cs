using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocket : Rocket
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            return;
        }
        Destroy(this.gameObject);
    }
        private void Update()
    {
        this.transform.Translate(0, 0, m_speed * Time.deltaTime);
    }
}

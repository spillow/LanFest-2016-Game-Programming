﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class BoostBehavior : MonoBehaviour
{

    public Transform m_Orb;

    public float m_MinHeight = 0.5f;
    public float m_MaxHeight = 3.0f;
    public float m_Velocity = 2.0f;

    public int m_BoostAmount = 12;
    public float m_RespawnTime = 4; // seconds

    private int m_Dir = +1;

    public bool m_Hover = false;

    Renderer m_SphereRend;
    Collider m_Collider;
    public GameObject m_BoostBreakup;

    // Use this for initialization
    void Start()
    {
        m_SphereRend = m_Orb.GetComponent<Renderer>();
        m_Collider = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!m_SphereRend.gameObject.activeInHierarchy)
            return;

        Transform obj = other.transform;
        while (obj.parent != null)
        {
            obj = obj.parent;
        }

        if (obj.tag == "Player")
        {
            var ctrl = obj.GetComponent<CarController>();
            ctrl.AddToBoostWell(m_BoostAmount);

            if (m_BoostBreakup != null)
            {
                var exp = (GameObject)Instantiate(
                               m_BoostBreakup, m_Orb.position, Quaternion.identity);
                var particle = exp.GetComponent<ParticleSystem>();
                particle.Play();
                Destroy(exp, 5f);
            }

            m_Orb.gameObject.SetActive(false);
            m_Collider.enabled = false;
            Invoke("TurnOnSphere", m_RespawnTime);
        }
    }

    void TurnOnSphere()
    {
        m_Orb.gameObject.SetActive(true);
        m_Collider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_Hover)
            return;

        m_Orb.transform.position += m_Orb.transform.up * m_Velocity * Time.deltaTime * m_Dir;
        if (m_Dir == +1 && m_Orb.transform.localPosition.y > m_MaxHeight)
        {
            m_Dir = -1;
        }
        else if (m_Dir == -1 && m_Orb.transform.localPosition.y < m_MinHeight)
        {
            m_Dir = +1;
        }
    }
}

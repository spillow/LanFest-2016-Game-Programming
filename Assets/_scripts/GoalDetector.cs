using UnityEngine;
using System.Collections;

public class GoalDetector : MonoBehaviour
{
    public GameObject m_Ball;
    public float m_BlastRadius;
    public float m_ExplosionForce;
    public GameObject m_Explosion;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == m_Ball.tag)
        {
            // Ball collided, goal scored

            // Trigger visual
            var exp = (GameObject)Instantiate(
                m_Explosion, m_Ball.transform.position, Quaternion.identity);
            var particle = exp.GetComponent<ParticleSystem>();
            particle.Play();
            m_Ball.SetActive(false);
            Destroy(exp, 5f);

            // add explosion force to all players within the blast radius
            foreach (var car in GameObject.FindGameObjectsWithTag("Player"))
            {
                var rb = car.GetComponent<Rigidbody>();
                rb.AddExplosionForce(
                    m_ExplosionForce,
                    m_Ball.transform.position,
                    m_BlastRadius);
            }
        }
    }
}

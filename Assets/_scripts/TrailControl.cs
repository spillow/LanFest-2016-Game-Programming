using UnityEngine;
using System.Collections;

public class TrailControl : MonoBehaviour
{
    TrailRenderer m_TrailRenderer;
    Rigidbody m_Ball;

    public float minVelocity;
    public float maxVelocity;
    public float tailLength;

    private float m;
    private float b;

    // Use this for initialization
    void Start()
    {
        m_TrailRenderer = GetComponent<TrailRenderer>();
        m_Ball = GetComponentInParent<Rigidbody>();

        if (maxVelocity <= minVelocity)
        {
            Debug.LogWarning("max velocity <= min velocity");
            maxVelocity = minVelocity + 1f;
        }

        m = -tailLength / (minVelocity - maxVelocity);
        b = (minVelocity * tailLength) / (minVelocity - maxVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        float velocity = Mathf.Clamp(
            m_Ball.velocity.magnitude,
            minVelocity,
            maxVelocity);

        // length described by (minVelocity, 0) (maxVelocity, tailLength)
        float targetLength = m * velocity + b;
        float currVelocity = 0f;
        m_TrailRenderer.time = Mathf.SmoothDamp(
            m_TrailRenderer.time,
            targetLength,
            ref currVelocity,
            0.1f);
    }
}

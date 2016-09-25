using UnityEngine;
using System.Collections;

public class BallProjector : MonoBehaviour
{
    public Transform m_Ball;
    public Projector m_OuterProjector;
    public Projector m_InnerProjector;

    // Use this for initialization
    void Start()
    {
        int projectorLayer = LayerMask.NameToLayer("Projector");
        m_OuterProjector.ignoreLayers = ~(1 << projectorLayer);
        m_InnerProjector.ignoreLayers = ~(1 << projectorLayer);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = m_Ball.position;
        m_OuterProjector.enabled = m_Ball.gameObject.activeInHierarchy;
        m_InnerProjector.enabled = m_Ball.gameObject.activeInHierarchy;

        float ballHeight = Mathf.Clamp(m_Ball.position.y, 0f, 20f);

        m_InnerProjector.orthographicSize = 0.088f * ballHeight + 1.8f;
    }
}

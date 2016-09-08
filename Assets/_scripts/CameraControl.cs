using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    public GameObject m_Player;
    public GameObject m_Ball;
    private Vector3 m_Offset;

    private bool m_BallCam = false;

    // Use this for initialization
    void Start ()
    {
        // Record the initial displacement from the vehicle.  This distance will
        // be maintained.
        m_Offset = transform.position - m_Player.transform.position;
    }
    
    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown("joystick button 3") ||
            Input.GetKeyDown("space"))
        {
            m_BallCam = !m_BallCam;
        }

        if (m_BallCam)
        {
            Vector3 playerBall =
                (m_Player.transform.position - m_Ball.transform.position).normalized;
            Vector2 projected = new Vector2(playerBall.x, playerBall.z);
            projected.Normalize();
            projected *= (new Vector2(m_Offset.x, m_Offset.z)).magnitude;
            Vector3 camLocation = new Vector3(projected.x, m_Offset.y, projected.y);
            transform.position = m_Player.transform.position + camLocation;
            transform.LookAt(m_Ball.transform);
        }
        else
        {
            transform.position = m_Player.transform.position + m_Offset;
            transform.LookAt(m_Player.transform);
        }
    }
}

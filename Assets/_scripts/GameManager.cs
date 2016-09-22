using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    enum State
    {
        Kickoff,
        NormalPlay,
        GoalScored
    }

    public Text m_Timer;

    [Tooltip("length in seconds")]
    public float m_GameLength; // seconds

    private State m_GameState = State.NormalPlay;

    // Use this for initialization
    void Start()
    {

    }

    void UpdateClock()
    {
        if (m_GameState == State.NormalPlay)
        {
            m_GameLength -= Time.deltaTime;
            uint minutes = (uint)m_GameLength / 60;
            uint seconds = (uint)m_GameLength % 60;

            m_Timer.text = string.Format("{0}:{1:D2}", minutes, seconds);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateClock();
    }
}

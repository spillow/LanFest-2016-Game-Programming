using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using UnityStandardAssets.Vehicles.Car;

public class GameManager : MonoBehaviour
{
    enum State
    {
        Kickoff,
        NormalPlay,
        GoalScored
    }

    public Text m_Timer;
    public Image m_BoostDial;
    public Text m_BoostAmount;

    public GameObject m_BoostDialRoot;
    public GameObject m_ScoreboardRoot;

    public CarController m_CarController;

    [Tooltip("length in seconds")]
    public float m_GameLength; // seconds

    private State m_GameState = State.NormalPlay;

    void OnEnable()
    {
        m_BoostDialRoot.SetActive(true);
        m_ScoreboardRoot.SetActive(true);
    }

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

    void UpdateBoostDial()
    {
        float frac = m_CarController.CarBoost / 100.0f;
        m_BoostDial.fillAmount = frac;
        m_BoostAmount.text = string.Format("{0}", (uint)m_CarController.CarBoost);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateClock();
        UpdateBoostDial();
    }
}

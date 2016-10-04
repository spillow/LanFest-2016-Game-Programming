using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : NetworkBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        private UnityStandardAssets.Cameras.AutoCam m_Cam;

        private void Awake()
        {
        }

        public override void OnStartLocalPlayer()
        {
            base.OnStartLocalPlayer();

            //GetComponent<MeshRenderer>().material.color = Color.red;

            // get the car controller
            m_Car = GetComponent<CarController>();

            // get the camera rig
            GameObject rig = GameObject.FindGameObjectWithTag("CameraRig");
            m_Cam = rig.GetComponent<UnityStandardAssets.Cameras.AutoCam>();

            // hook up the game manager
            GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");
            GameManager gm = gameManager.GetComponent<GameManager>();
            gm.m_CarController = m_Car;
            gm.enabled = true;

            // hook up the camera rig
            m_Cam.m_CarController = m_Car;
            m_Cam.SetTarget(m_Car.transform);
            m_Cam.enabled = true;
        }

        void Update()
        {
            if (!isLocalPlayer)
                return;

            bool ballcam = CrossPlatformInputManager.GetButtonDown("BallCam");

            if (ballcam)
            {
                m_Cam.BallCamPressed();
            }
        }

        private void FixedUpdate()
        {
            if (!isLocalPlayer)
                return;

            // pass the input to the car!
            float h         = CrossPlatformInputManager.GetAxis("Horizontal");
            float v         = CrossPlatformInputManager.GetAxis("Vertical");
            float jump      = CrossPlatformInputManager.GetAxis("Jump");
            float boost     = CrossPlatformInputManager.GetAxis("Boost");
            float rollbrake = CrossPlatformInputManager.GetAxis("AirRollBrake");

            float vkb       = CrossPlatformInputManager.GetAxis("VerticalKB");
            float triggers  = CrossPlatformInputManager.GetAxis("Triggers");
            float accel     = (vkb == 0f) ? triggers : v;

            m_Car.Move(h, accel, accel, v, jump, boost, rollbrake);
        }
    }
}

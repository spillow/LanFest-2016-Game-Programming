using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
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

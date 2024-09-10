using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UnityStandardAssets.Utility
{
    [RequireComponent(typeof (Text))]
    public class FPSCounter : MonoBehaviour
    {
        const float fpsMeasurePeriod = 0.5f;
        private int m_FpsAccumulator = 0;
        private float m_FpsNextPeriod = 0;
        private int m_CurrentFps;
        const string display = "{0} FPS";
        private Text m_Text;

        [SerializeField] private bool unlockFPS = true;

        private void Start()
        {
            m_FpsNextPeriod = Time.realtimeSinceStartup + fpsMeasurePeriod;
            m_Text = GetComponent<Text>();

            if (unlockFPS) {
                Application.targetFrameRate = int.MaxValue;
            }
        }


        private void Update()
        {
            // measure average frames per second
            m_FpsAccumulator++;
            if (Time.realtimeSinceStartup > m_FpsNextPeriod)
            {
                m_CurrentFps = (int) (m_FpsAccumulator/fpsMeasurePeriod);
                m_FpsAccumulator = 0;
                m_FpsNextPeriod += fpsMeasurePeriod;
                m_Text.text = string.Format(display, m_CurrentFps);

			   //m_Text.text = (Screen.width.ToString() +" x "+Screen.height.ToString()+" : "+m_CurrentFps);
            }
        }
    }
}

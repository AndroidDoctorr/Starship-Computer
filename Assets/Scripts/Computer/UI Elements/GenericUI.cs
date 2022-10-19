using Assets.Scripts.Computer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public enum ConsoleTypes {
        // Name          // Dimensions (w x h)
        StandardConsole, // 0.8m x 0.25m
        WideConsole,     // 1m x 0.25m
        SmallConsole,    // 0.5m x 0.2m
        TallConsole,     // 0.6m x 0.4m
        WorkStation = 50,// 1 StandardConsole + 1 Display
        Display = 100,   // 0.8m x 0.5m
        LargeDisplay,    // 2m x 1m
        WidePanel = 200, // 0.5m x 0.4m
        Panel,           // 0.25m x 0.4m
        SmallPanel,      // 0.1m x 0.25m
        // Mobile
        Pad = 300,       // 0.1m x 0.2m
        Tablet,          // 0.3m x 0.2m
        WideTablet,      // 0.5m x 0.4m
        Tricorder        // 0.1m x 0.1m
    }
    public abstract class GenericUI : MonoBehaviour
    {
        private ISystem _system;
        private AudioSource _as;
        public bool IsEnabled { get; protected set; } = false;
        public bool HasPower { get; protected set; } = false;
        public float PowerDraw = 1;

        public AudioClip[] SoundEffects;
        public Image[] ImagesToColor;
        public TMP_Text[] TextsToColor;

        public GameObject EnabledObject;
        public GameObject DisabledObject;
        public GameObject RedAlertObject;
        void Start()
        {
            _as = GetComponent<AudioSource>();
        }
        public void SetSystem(ISystem system)
        {
            if (system == null)
            {
                Debug.LogError("UI Property - No system provided");
                return;
            }
            _system = system;
        }
        protected void PlaySound(int clipId)
        {
            Debug.Log($"Play Sound {clipId} in UI: {GetType().Name}");
            if (!IsEnabled) return;
            if (_as == null) return;
            _as.clip = SoundEffects[clipId];
            _as.PlayDelayed(0);
        }
        public void Disable()
        {
            Debug.Log($"Disable UI: {GetType().Name}");
            PowerDraw = 0;
            IsEnabled = false;

            EnabledObject.SetActive(false);
            DisabledObject.SetActive(true);
        }
        public void Enable()
        {
            Debug.Log($"Enable UI: {GetType().Name}");
            if (!HasPower) return;
            PowerDraw = 1;
            IsEnabled = true;

            EnabledObject.SetActive(true);
            DisabledObject.SetActive(false);
        }
        public void PowerDown()
        {
            Debug.Log($"Power Down UI: {GetType().Name}");
            Disable();

            HasPower = false;

            DisabledObject.SetActive(false);
        }
        public void PowerUp()
        {
            Debug.Log($"Power Up UI: {GetType().Name}");
            HasPower = true;

            if (IsEnabled) Enable();

            else Disable();
        }
        public void SetRedAlert(bool isRedAlert)
        {
            Debug.Log($"Set Red Alert in UI: {GetType().Name}");
            if (HasPower && IsEnabled)
                RedAlertObject.SetActive(isRedAlert);
        }
        public void EndRedAlert()
        {
            Debug.Log($"End Red Alert in UI: {GetType().Name}");
            RedAlertObject.SetActive(false);
        }
        public virtual void SetColor(Color color)
        {
            Debug.Log($"Set Color {color} in UI: {GetType().Name}");

            foreach (UIElement element in GetComponentsInChildren<UIElement>(true))
                element.SetColor(color);

            foreach (Image image in ImagesToColor)
                image.color = color;

            foreach (TMP_Text text in TextsToColor)
                text.color = color;
        }
    }
}

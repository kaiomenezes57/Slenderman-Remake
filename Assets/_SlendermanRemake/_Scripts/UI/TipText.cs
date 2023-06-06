using UnityEngine;
using TMPro;

namespace SlendermanRemake
{
    public class TipText : MonoBehaviour
    {
        public static TipText Instance;
        private TextMeshProUGUI _tipText;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _tipText = GetComponent<TextMeshProUGUI>();
            _tipText.text = null;
        }

        public void SetTipText(string message)
        {
            _tipText.text = message;
        }
    }
}

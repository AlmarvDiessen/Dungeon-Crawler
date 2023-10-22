using UnityEngine;
using UnityEngine.UI;

namespace LectureScripts.UI
{
    public class HealthBarUI : MonoBehaviour
    {
        //Fields
        [SerializeField] private Image _image;
        [SerializeField] private Gradient _gradient;
        [SerializeField] private Image _icon;

        [Header("Testing variables")]
        [SerializeField, Range(0.0f, 1.0f)] private float _gradientTest = 1.0f;
    
        //Properties
        public Sprite Icon
        {
            set => _icon.sprite = value;
        }
    
        //Unity event functions
        private void Start()
        {
            Debug.Assert(_image != null);
        }

        private void OnValidate()
        {
            UpdateHealthBar(_gradientTest);
        }

        //Methods
        public void UpdateHealthBar(float pT)
        {
            Debug.Assert(pT >= 0.0f, pT);
            Debug.Assert(pT <= 1.0f, pT);
        
            _image.fillAmount = pT;
            _image.color = _gradient.Evaluate(pT);
        }
    }
}

using System;
using UnityEngine;
using TMPro;
using Utils;

namespace UI
{
    public class TutorialUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI moveUpText;
        [SerializeField] private TextMeshProUGUI moveDownText;
        [SerializeField] private TextMeshProUGUI moveLeftText;
        [SerializeField] private TextMeshProUGUI moveRightText;
        [SerializeField] private TextMeshProUGUI interactText;
        [SerializeField] private TextMeshProUGUI interactAltText;
        [SerializeField] private TextMeshProUGUI pauseText;
        [SerializeField] private TextMeshProUGUI gamepadInteractText;
        [SerializeField] private TextMeshProUGUI gamepadInteractAltText;
        [SerializeField] private TextMeshProUGUI gamepadPauseText;


        private void Start()
        {
            KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;
            UpdateVisual();
            Show();
        }

        private void KitchenGameManager_OnStateChanged(object sender, EventArgs e)
        {
            if (KitchenGameManager.Instance.IsCountDownToStartActive())
            {
                Hide();
            }
        }


        private void UpdateVisual()
        {
            moveUpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up);
            moveDownText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down);
            moveLeftText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
            moveRightText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);
            interactText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
            interactAltText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact_Alt);
            pauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);
            gamepadInteractText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Interact);
            gamepadInteractAltText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_InteractAlt);
            gamepadPauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Pause);
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
        }
    
        public void Hide()
        {
            gameObject.SetActive(false);
        }

    }

}
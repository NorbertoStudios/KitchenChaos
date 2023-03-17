using System;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DeliveryResultUI : MonoBehaviour
    {
        [SerializeField] private Image backgroundImage;
        [SerializeField] private Image iconImage;
        [SerializeField] private TextMeshProUGUI messageText;
        [SerializeField] private Color successColor;
        [SerializeField] private Color failedColor;
        [SerializeField] private Sprite successSprite;
        [SerializeField] private Sprite failedSprite;
        
        private float resultTimer = 1f;

        private void Start()
        {
            DeliveryManager.Instance.OnRecipeSuccess += DeliveryManager_OnRecipeSuccess;
            DeliveryManager.Instance.OnRecipeFailed += DeliveryManager_OnRecipeFailed;
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (gameObject.activeInHierarchy)
            {
                resultTimer -= Time.deltaTime;
                if (resultTimer < 0f)
                {
                    gameObject.SetActive(false);
                    resultTimer = 1f;
                }
            }
        }

        private void DeliveryManager_OnRecipeFailed(object sender, EventArgs e)
        {
            gameObject.SetActive(true);
            backgroundImage.color = failedColor;
            iconImage.sprite = failedSprite;
            messageText.text = "DELIVERY\nFAILED";
        }

        private void DeliveryManager_OnRecipeSuccess(object sender, EventArgs e)
        {
            gameObject.SetActive(true);
            backgroundImage.color = successColor;
            iconImage.sprite = successSprite;
            messageText.text = "DELIVERY\nSUCCESS";
        }
    }
}
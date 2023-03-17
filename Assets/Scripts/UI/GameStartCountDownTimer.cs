using TMPro;
using UnityEngine;
using Utils;

namespace UI
{
    public class GameStartCountDownTimer : MonoBehaviour
    {
        private const string NUMBER_POPUP = "NumberPopup";
        [SerializeField] private TextMeshProUGUI countDownText;

        private Animator animator;
        private int previousCountDownNumber;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Start(){
            KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;
            Hide();
        }

        private void Update(){
            int countdownNumber = Mathf.CeilToInt(KitchenGameManager.Instance.GetCountDownToStartTimer()); 
            countDownText.text = countdownNumber.ToString();

            if (previousCountDownNumber != countdownNumber)
            {
                previousCountDownNumber = countdownNumber;
                animator.SetTrigger(NUMBER_POPUP);
                SoundManager.Instance.PlayCountdownSound();
            }
        }

        private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e){
            if(KitchenGameManager.Instance.IsCountDownToStartActive()){
                Show();
            }else {
                Hide();
            }
        }

        private void Show(){
            gameObject.SetActive(true);
        }

        private void Hide(){
            gameObject.SetActive(false);
        }

    }
}

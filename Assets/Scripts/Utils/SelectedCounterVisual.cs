using Counters;
using UnityEngine;

namespace Utils
{
    public class SelectedCounterVisual : MonoBehaviour
    {
        [SerializeField] private BaseCounter baseCounter;

        [SerializeField] private GameObject[] VisualGameObjectArray;

        private void Start(){
            Player.Instance.OnSelectedCountersChanged += Player_OnSelectedCountersChanged;
        }

        private void Player_OnSelectedCountersChanged(
            object sender, 
            Player.OnSelectedCountersChangedEventArgs e){ 
            if (e.selectedCounter == baseCounter){
                Show();
            }else{
                Hide();
            }
        }

        private void Show(){
            foreach (GameObject visualGameObject in VisualGameObjectArray){
                visualGameObject.SetActive(true);
            }
        }
        private void Hide(){
            foreach (GameObject visualGameObject in VisualGameObjectArray)
            {
                visualGameObject.SetActive(false);
            }
        }


    }
}

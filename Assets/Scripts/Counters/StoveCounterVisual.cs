using UnityEngine;

namespace Counters
{
    public class StoveCounterVisual : MonoBehaviour
    {
        [SerializeField] private GameObject stoveOnGameObject;
        [SerializeField] private GameObject particlesGameObject;
        [SerializeField] private StoveCounter stoveCounter;

        public void Start(){
            stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
        }

        private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e ){
            bool showVisual = e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried;
            ShowOrHide(showVisual);
        }   

        private void ShowOrHide(bool showVisual)
        {
            stoveOnGameObject.SetActive(showVisual);
            particlesGameObject.SetActive(showVisual);
        }

    }
}
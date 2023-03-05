using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField]
    private ClearCounter clearCounter;

    [SerializeField]
    private GameObject VisualGameObject;
     private void Start(){
        Player.Instance.OnSelectedCountersChanged += Player_OnSelectedCountersChanged;
     }

     private void Player_OnSelectedCountersChanged(
        object sender, 
        Player.OnSelectedCountersChangedEventArgs e){ 
        if (e.selectedCounter == clearCounter){
            Show();
        }else{
            Hide();
        }
     }

     private void Show(){
        VisualGameObject.SetActive(true);
     }
     private void Hide(){
        VisualGameObject.SetActive(false);
     }


}

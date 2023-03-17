using System;
using System.Collections.Generic;
using ScribtableObjects;
using UnityEngine;

namespace Utils
{
    public class PlateCompleteVisual : MonoBehaviour
    {


        [Serializable]
        public struct KitchenObjectSO_Gameobject{
            public KitchenObjectSO kitchenObjectSO;
            public GameObject gameObject;
        }

        [SerializeField] private PlateKitchenObject plateKitchenObject;
        [SerializeField] private List<KitchenObjectSO_Gameobject> kitchenObjectSOGameobjectList;

        private void Start(){
            plateKitchenObject.OnIngredientAdded += PlateKitchenObject_OnIngredientAdded;
            foreach (KitchenObjectSO_Gameobject kitchenObjectSOGameobject in kitchenObjectSOGameobjectList)
            {
                kitchenObjectSOGameobject.gameObject.SetActive(false);
            
            }
        }


        private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e) {
            foreach (KitchenObjectSO_Gameobject kitchenObjectSOGameobject in kitchenObjectSOGameobjectList){
                if (kitchenObjectSOGameobject.kitchenObjectSO == e.KitchenObjectSO){
                    kitchenObjectSOGameobject.gameObject.SetActive(true);
                }
            }
        }
    }
}

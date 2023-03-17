using System;
using System.Collections.Generic;
using ScribtableObjects;
using UnityEngine;

namespace Utils
{
    public class PlateKitchenObject : KitchenObject
    {
        public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
        public class OnIngredientAddedEventArgs : EventArgs
        {
            public KitchenObjectSO KitchenObjectSO;
        }


        [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;
        private List<KitchenObjectSO> kitchenObjectSOList;

        private void Awake()
        {
            kitchenObjectSOList = new List<KitchenObjectSO>();
        }

        public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
        {
            if (!validKitchenObjectSOList.Contains(kitchenObjectSO))
            {
                // Not a valid ingridient
                return false;
            }
            if (kitchenObjectSOList.Contains(kitchenObjectSO))
            {
                // Already has this item
                return false;
            }
            else
            {

                kitchenObjectSOList.Add(kitchenObjectSO);

                OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs
                {
                    KitchenObjectSO = kitchenObjectSO
                });

                return true;
            }
        }

        public List<KitchenObjectSO> GetKitchenObjectSOList(){
            return kitchenObjectSOList;
        }
    }
}

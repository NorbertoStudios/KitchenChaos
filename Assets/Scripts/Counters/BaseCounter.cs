using System;
using UnityEngine;
using Utils;

namespace Counters
{
    public abstract class BaseCounter : MonoBehaviour, IKitchenObjectParent
    {
        public static event EventHandler OnAnyObjectPlaceHere;
        [SerializeField] private Transform counterTopPoint;

        private KitchenObject kitchenObject;

        public static void ResetStaticData()
        {
            OnAnyObjectPlaceHere = null;
        }

        public abstract void Interact(Player player);
        public virtual void InteractAlternate(Player player)
        {
        }

        public Transform GetKitchenObjectFollowTransform()
        {
            return counterTopPoint;
        }

        public void SetKitchenObject(KitchenObject kitchenObject)
        {
            this.kitchenObject = kitchenObject;

            if (kitchenObject != null)
            {
                OnAnyObjectPlaceHere?.Invoke(this, EventArgs.Empty);
            }
        }

        public KitchenObject GetKitchenObject()
        {
            return kitchenObject;
        }

        public void ClearKitchenObject()
        {
            kitchenObject = null;
        }

        public bool HasKitchenObject()
        {
            return kitchenObject != null;
        }

    }
}

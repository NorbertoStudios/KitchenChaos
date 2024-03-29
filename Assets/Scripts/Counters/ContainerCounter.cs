using System;
using ScribtableObjects;
using UnityEngine;
using Utils;

namespace Counters
{
    public class ContainerCounter : BaseCounter
    {
        public event EventHandler OnPlayerGrabbedObject;
        [SerializeField] private KitchenObjectSO kitchenObjectSO;

        public override void Interact(Player player)
        {
            if (!player.HasKitchenObject())
            {
                // Player is not carrying a kitchen object
                KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);
                OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
            }
        }

    }
}

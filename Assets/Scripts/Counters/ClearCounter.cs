using ScribtableObjects;
using UnityEngine;
using Utils;

namespace Counters
{
    public class ClearCounter : BaseCounter
    {
        [SerializeField] private KitchenObjectSO kitchenObjectSO;

        public override void Interact(Player player)
        {
            if (!HasKitchenObject())
            {
                // There is no KitchenObject
                if (player.HasKitchenObject())
                {
                    // Player is carrying something
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
                else
                {
                    // Player is not carrying something
                }
            }
            else
            {
                // There is a KitchenObject here
                if (player.HasKitchenObject())
                {
                    // Player is carrying something
                    if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                    {
                        // Player is Holding a plate
                        if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO())){
                            GetKitchenObject().DestroySelf();
                        }
                    } else {
                        // Player is not holding a plate
                        if(GetKitchenObject().TryGetPlate(out plateKitchenObject)){
                            // Counter is holding a plate
                            if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO())){
                                player.GetKitchenObject().DestroySelf();
                            }
                        }
                    }
                }
                else
                {
                    // Player is not carrying something
                    GetKitchenObject().SetKitchenObjectParent(player);
                }
            }
        }



    }
}

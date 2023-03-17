using Utils;

namespace Counters
{
    public class DeliveryCounter : BaseCounter
    {
        public static DeliveryCounter Instance { get; private set; }

        private void Awake(){
            Instance = this;
        }

        public override void Interact(Player player)
        {
            if(player.HasKitchenObject()){
                if(player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)){
                    // Only plates can be accepted
                    DeliveryManager.Instance.DeliverRecipe(plateKitchenObject);

                    player.GetKitchenObject().DestroySelf();
                }
            }
        }
    }
}

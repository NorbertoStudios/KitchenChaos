using System;
using ScribtableObjects;
using UnityEngine;
using Utils;

namespace Counters
{
    public class PlatesCounter : BaseCounter
    {
        public event EventHandler OnPlateSpwaned;
        public event EventHandler OnPlateRemove;

        [SerializeField] private KitchenObjectSO plateKitchenObjectSO;
        [SerializeField] private float spawnPlateTimerMax = 4f;
        [SerializeField] private int platesSpawnedAmount;
        // [SerializeField] private int platesSpawnedAmountMax = 4;

        private float spawnPlateTimer;
        public override void Interact(Player player)
        {
            if(!player.HasKitchenObject()){
                // Player is Empty handed
                if(platesSpawnedAmount > 0){
                    platesSpawnedAmount--;

                    KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);
                    OnPlateRemove?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public void Update(){
            spawnPlateTimer += Time.deltaTime;
            if(spawnPlateTimer > spawnPlateTimerMax){
                spawnPlateTimer = 0f;
                if(KitchenGameManager.Instance.IsGamePlaying() && platesSpawnedAmount < spawnPlateTimerMax){
                    platesSpawnedAmount++;
                    OnPlateSpwaned?.Invoke(this, EventArgs.Empty);
                }
                // 
            } 
        }
    }
}

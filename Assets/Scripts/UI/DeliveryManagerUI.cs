using ScribtableObjects;
using UnityEngine;

namespace UI
{
    public class DeliveryManagerUI : MonoBehaviour
    {
        [SerializeField] private Transform container;
        [SerializeField] private Transform recipeTemplate;

        public void Awake(){
            recipeTemplate.gameObject.SetActive(false);
        }

        private void Start(){
            DeliveryManager.Instance.OnRecipeSpawned += DeliveryManager_OnRecipeSpawned;
            DeliveryManager.Instance.OnRecipeCompleted += DeliveryManager_OnRecipeCompleted; 

            UpdateVisual();
        }

        public void DeliveryManager_OnRecipeSpawned(object sender, System.EventArgs e){
            UpdateVisual();
        }
        public void DeliveryManager_OnRecipeCompleted(object sender, System.EventArgs e){
            UpdateVisual();
        }

        public void UpdateVisual(){
            foreach (Transform child in container){
                if(child == recipeTemplate)continue;
                Destroy(child.gameObject);
            }

            foreach (RecipeSO recipeSO in DeliveryManager.Instance.GetWaitingRecipeSOList()){
                Transform recipeTransform = Instantiate(recipeTemplate, container);
                recipeTransform.gameObject.SetActive(true);
                recipeTransform.GetComponent<DeliveryManagerSingleUI>().SetRecipeSO(recipeSO);
            }
        }
    }
}

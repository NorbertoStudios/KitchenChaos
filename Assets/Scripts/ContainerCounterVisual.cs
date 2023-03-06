using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{
    [SerializeField] private ContainerCounter ContainerCounter;
    private Animator animator;

    private const string OPEN_CLOSE = "OpenClose";

    public void Awake(){
        animator = GetComponent<Animator>();
    }

    public void Start(){
        ContainerCounter.OnPlayerGrabbedObject += ContainerCounter_OnPlayerGrabbedObject;
    }

    private void ContainerCounter_OnPlayerGrabbedObject(object sender, System.EventArgs e){
        animator.SetTrigger(OPEN_CLOSE);
    }
}

using UnityEngine;

public class DoorsAnimationController : MonoBehaviour
{
    [SerializeField] private Animator DoorA_animator; 
    [SerializeField] private Animator DoorB_animator; 


    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    private void OpenDoorsAnimation()
    {
        DoorA_animator.SetTrigger("OpenDoor");
        DoorB_animator.SetTrigger("OpenDoor");
    }

}

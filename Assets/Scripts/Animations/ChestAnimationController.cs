using UnityEngine;

public class ChestAnimationController : MonoBehaviour
{
    [SerializeField] private Animator chestAnimator; 

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    public void OpenDoorsAnimation()
    {
        chestAnimator.SetTrigger("IsOpen");
    }
}

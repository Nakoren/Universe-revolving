using UnityEngine;

public class ChestAnimationController : MonoBehaviour
{
    [SerializeField] private Animator chestAnimator; 
    [SerializeField] private RewardContainer m_rewardContainer;

    private void OnEnable()
    {
        m_rewardContainer.onOpen+=OpenDoorsAnimation;
    }

    private void OnDisable()
    {
         m_rewardContainer.onOpen-=OpenDoorsAnimation;
    }

    public void OpenDoorsAnimation()
    {
        chestAnimator.SetTrigger("IsOpen");
    }
}

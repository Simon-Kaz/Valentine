using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Canvas uiCanvas;
    [SerializeField] private Canvas uiYesCanvas;
    [SerializeField] private GameObject heartContainer;
    [SerializeField] private Animator bearAnimator;
    
    private static readonly int Dance = Animator.StringToHash("Dance");
    private static readonly int Die = Animator.StringToHash("Die");

    public void OnYesClick()
    {
        bearAnimator.SetBool(Dance, true);
        heartContainer.SetActive(true);
        uiCanvas.gameObject.SetActive(false);
        uiYesCanvas.gameObject.SetActive(true);
    }

    public void OnNoClick()
    {
        uiCanvas.gameObject.SetActive(false);
        bearAnimator.SetBool(Die, true);
    }
}

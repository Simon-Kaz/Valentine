using UnityEngine;

public class UIMainCanvasManager : MonoBehaviour
{
    [SerializeField] private Canvas uiCanvas;
    [SerializeField] private Canvas uiYesCanvas;
    [SerializeField] private Canvas uiNoCanvas;
    [SerializeField] private GameObject heartContainer;
    [SerializeField] private Animator bearAnimator;

    private static readonly int Dance = Animator.StringToHash("Dance");
    private static readonly int Die = Animator.StringToHash("Die");
    private static readonly int Wave = Animator.StringToHash("Wave");

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

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
        uiNoCanvas.gameObject.SetActive(true);
        bearAnimator.SetBool(Die, true);
        bearAnimator.SetBool(Wave, false);
    }
}

using System.Collections;
using UnityEngine;

public class UINoCanvasManager : MonoBehaviour
{
    [SerializeField] private Canvas uiNoCanvas;
    [SerializeField] private Canvas uiMainCanvas;
    [SerializeField] private Canvas uiGoodbyeCanvas;
    [SerializeField] private Animator bearAnimator;
    [SerializeField] private GameObject bearGo;
    [SerializeField] private GameObject tryAgainButton;

    private static readonly int Wave = Animator.StringToHash("Wave");
    private static readonly int Die = Animator.StringToHash("Die");

    public void OnYesClick()
    {
        WalkAway();
    }

    public void OnNoClick()
    {
        uiMainCanvas.gameObject.SetActive(true);
        uiNoCanvas.gameObject.SetActive(false);
        bearAnimator.SetBool(Die, false);
        bearAnimator.SetBool(Wave, true);
    }

    private void WalkAway()
    {
        uiNoCanvas.gameObject.SetActive(false);
        uiGoodbyeCanvas.gameObject.SetActive(true);
    }
}
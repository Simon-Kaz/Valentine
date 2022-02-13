using System.Collections;
using UnityEngine;

public class GoodbyeCanvasHandler : MonoBehaviour
{
    [SerializeField] private GameObject tryAgainButton;
    [SerializeField] private Animator bearAnimator;
    [SerializeField] private GameObject bearGo;
    [SerializeField] private Canvas uiMainCanvas;

    private static readonly int Walk = Animator.StringToHash("Walk");
    private static readonly int Wave = Animator.StringToHash("Wave");
    private static readonly int Die = Animator.StringToHash("Die");
    
    private void Start()
    {
        StartCoroutine(LoadTryAgain());
    }

    private IEnumerator LoadTryAgain()
    {
        bearAnimator.SetBool(Walk, true);
        yield return new WaitForSecondsRealtime(1);
        bearGo.transform.Rotate(new Vector3(0, 270, 0));
        yield return new WaitForSecondsRealtime(5);
        tryAgainButton.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        tryAgainButton.gameObject.SetActive(true);
    }

    public void OnTryAgainClick()
    {
        uiMainCanvas.gameObject.SetActive(true);
        gameObject.SetActive(false);
        bearAnimator.SetBool(Die, false);
        bearAnimator.SetBool(Walk, false);
        bearAnimator.SetBool(Wave, true);
    }
}

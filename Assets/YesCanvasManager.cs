using System.Collections;
using UnityEngine;

public class YesCanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject tryAgainButton;
    [SerializeField] private Animator bearAnimator;
    [SerializeField] private GameObject bearGo;
    [SerializeField] private Canvas uiMainCanvas;
    [SerializeField] private GameObject heartContainer;

    private static readonly int Walk = Animator.StringToHash("Walk");
    private static readonly int Wave = Animator.StringToHash("Wave");
    private static readonly int Die = Animator.StringToHash("Die");
    private static readonly int Dance = Animator.StringToHash("Dance");
    
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(LoadTryAgain());
    } 

    private IEnumerator LoadTryAgain()
    {
        yield return new WaitForSecondsRealtime(5);
        tryAgainButton.gameObject.SetActive(true);
    }

    public void OnTryAgainClick()
    {
        uiMainCanvas.gameObject.SetActive(true);
        heartContainer.gameObject.SetActive(false);
        bearAnimator.SetBool(Walk, false);
        bearAnimator.SetBool(Dance, false);
        bearAnimator.SetBool(Die, false);
        bearAnimator.SetBool(Wave, true);
        gameObject.SetActive(false);
    }
}

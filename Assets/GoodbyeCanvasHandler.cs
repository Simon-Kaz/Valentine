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
        StartCoroutine(WalkAwayAnimation());
        StartCoroutine(LoadTryAgain());
    }

    private IEnumerator WalkAwayAnimation()
    {
        bearAnimator.SetBool(Die, false);
        bearAnimator.SetBool(Walk, true);
        yield return new WaitForSecondsRealtime(1);
        bearGo.transform.Rotate(new Vector3(0f, 1f, 0f), -90f);
        yield return MoveOverSeconds(bearGo, new Vector3 (5f, 0f, 0f), 5f);
    }

    private IEnumerator MoveOverSpeed (GameObject objectToMove, Vector3 end, float speed){
        // speed should be 1 unit per second
        while (objectToMove.transform.position != end)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, end, speed * Time.deltaTime); ;
            yield return new WaitForEndOfFrame ();
        }
    }
    
    public IEnumerator MoveOverSeconds (GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
    }

    private IEnumerator LoadTryAgain()
    {
        yield return new WaitForSecondsRealtime(5);
        tryAgainButton.gameObject.SetActive(true);
    }

    public void OnTryAgainClick()
    {
        uiMainCanvas.gameObject.SetActive(true);
        gameObject.SetActive(false);
        bearGo.transform.Rotate(new Vector3(0f, 1f, 0f), 90f);
        bearAnimator.SetBool(Walk, false);
        bearAnimator.SetBool(Wave, true);
        bearGo.transform.position = new Vector3(0, 0, 0);
    }
}

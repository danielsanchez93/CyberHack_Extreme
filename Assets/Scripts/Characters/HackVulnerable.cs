using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class HackVulnerable : MonoBehaviour
{
    /// <summary>
    /// Time needed to complete the hack in this char
    /// </summary>
    [SerializeField] float hackTime = 2;
    [Header("Hack Bar")]
    [SerializeField] GameObject hackBar;
    [SerializeField] Image barFill;
    [Header("Control variables")]
    [SerializeField] float duration = 0;

    bool isMouseIn;
    bool canBeHacked = true;

    private void Update()
    {
        if (isMouseIn && canBeHacked)
        {
            duration += Time.deltaTime;
        }
        else {
            duration = 0;        
        }

        barFill.fillAmount = duration / hackTime;

        if(duration >= hackTime)
        {
            ///Hack Completed
            CompletedHack();
        }

    }

    private void OnMouseDown()
    {
        if(canBeHacked) hackBar.SetActive(true);
        isMouseIn = true;
    }

    private void CancelHack()
    {
        isMouseIn = false;
        hackBar.SetActive(false);
    }

    private void CompletedHack()
    {
        Debug.Log("Hack Completed");
        canBeHacked = false;
        hackBar.SetActive(false);
    }

    public void ResetVulnerabilities()
    {
        canBeHacked = true;
    }

    private void OnMouseExit() =>  CancelHack();
    private void OnMouseUp() => CancelHack();
}
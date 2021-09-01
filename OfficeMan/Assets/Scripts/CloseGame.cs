using UnityEngine;
using UnityEngine.EventSystems;

public class CloseGame : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Application.Quit();
    }
}

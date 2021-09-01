using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int _index;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(_index);
    }
}

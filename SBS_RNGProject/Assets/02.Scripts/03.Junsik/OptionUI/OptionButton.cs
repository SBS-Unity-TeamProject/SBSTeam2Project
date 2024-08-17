using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject UI;
    bool IsUIon = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!IsUIon)
        {
            UI.SetActive(true);
            IsUIon = true;
        }
        else
        {
            UI.SetActive(false);
            IsUIon=false;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

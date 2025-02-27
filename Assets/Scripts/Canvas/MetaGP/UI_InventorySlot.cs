using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Item item;
    private Image icon;

    public event Action<Item> onMouseHover;
    public event Action onMouseExit;

    public void OnPointerEnter(PointerEventData eventData)
    {
        onMouseHover?.Invoke(item);
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        onMouseExit?.Invoke();
    }

    private void Awake()
    {
        icon = GetComponent<Image>();
    }

    public void SetItem(Item newItem)
    {
        item = newItem;
        if (item != null)
        {
            icon.sprite = item.icon;
        }
    }


}

using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Transitor : IInteractable
{
    public int targetInd;
    public Room roomSO;
    public Action<int> onActivate;
    private Canvas iconCanvas;
    private DoorsAnimationController doorController;
    private bool isActive = false;
    private Icons levelIcons;

    public void Initiate(Room room, int roomInd, Icons levelIcons)
    {
        this.levelIcons = levelIcons;
        doorController = GetComponent<DoorsAnimationController>();
        iconCanvas = GetComponentInChildren<Canvas>();
        roomSO = room;
        targetInd = roomInd;
    }

    private void Update()
    {
        if (iconCanvas != null && Camera.main != null)
        {
            iconCanvas.transform.rotation = Camera.main.transform.rotation;
        }
    }

    public void addIcon(Texture icon)
    {
        RawImage iconImage = iconCanvas.GetComponentInChildren<RawImage>();
        iconImage.texture = icon;
        Color col = iconImage.color;
        col.a = 1;
        iconImage.color = col;
        
    }

    public void Enable()
    {
        switch (this.roomSO.GetType().Name)
        {
            case nameof(BattleRoom): addIcon(levelIcons.battleRoom); break;
            case nameof(RewardRoom): addIcon(levelIcons.rewardRoom); break;
            case nameof(RestRoom): addIcon(levelIcons.restRoom); break;
            case nameof(BossRoom): addIcon(levelIcons.bossRoom); break;
            case nameof(ShopRoom): addIcon(levelIcons.shopRoom); break;
        }
        doorController.OpenDoorsAnimation();
    }

    override public void Interact()
    {
        Activate();
    }

    private void Activate()
    {
        onActivate.Invoke(targetInd);
    }
}

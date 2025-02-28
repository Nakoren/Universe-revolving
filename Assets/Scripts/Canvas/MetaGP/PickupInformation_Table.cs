using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickupInformation_Table : MonoBehaviour
{
    [SerializeField] private Color32 grey = new Color32(135, 135, 135, 255);
    [SerializeField] private Color32 blue = new Color32(38, 82, 255, 255);
    [SerializeField] private Color32 violet = new Color32(155, 40, 255, 255);
    [SerializeField] private Color32 orange = new Color32(255, 131, 40, 255);

    private Canvas canvas;
    private PartPickUpObject pickupObject;
    
    private Image[] icons;
    private TextMeshProUGUI[] texts;
    
    private TextMeshProUGUI name_text;
    private TextMeshProUGUI type_text;
    private TextMeshProUGUI description_text;
    private TextMeshProUGUI сharacteristics_text;
    private TextMeshProUGUI price_text;

    private void Awake()
    {
        pickupObject = GetComponent<PartPickUpObject>();
        canvas = GetComponentInChildren<Canvas>(true);
        icons = GetComponentsInChildren<Image>(true);
        texts = GetComponentsInChildren<TextMeshProUGUI>(true);
    }

    private void Start()
    {
        InitInformation();
        RefreshInformation();
    }

    private void OnEnable()
    {
        RefreshInformation();
    }

    private void LateUpdate()
    {
        if (canvas != null && Camera.main != null)
        {
            canvas.transform.rotation = Camera.main.transform.rotation;
        }
    }

       private void InitInformation()
    {
        name_text = texts[0];
        type_text = texts[1];
        description_text = texts[2];
        сharacteristics_text = texts[3];
       // price_text = texts[4];
    }

    private void RefreshInformation()
    {
        var item = pickupObject.item;
        if (item == null)
            return;

        var part = item.part;

       
        switch (item.rare)
        {
            case 0:
                name_text.color = grey;
                break;
            case 1:
                name_text.color = blue;
                break;
            case 2:
                name_text.color = violet;
                break;
            case 3:
                name_text.color = orange;
                break;
            default:
                name_text.color = Color.white;
                break;
        }

        string name = item.itemName.ToString();
        string description = item.description;
        string characteristics = $"Модификатор урона: {part.damageRate * 100}%";
        string type = "";

        switch (part.type)
        {
            case IPart.Ptype.Magazine:
                Magazine mag = part as Magazine;
                if (mag != null)
                {
                    type = "Магазин";
                    characteristics += $"\nКоличествово патронов: {mag.cage}\nВремя перезарядки: {mag.recharge}";
                    icons[1].sprite = item.icon;
                }
                break;

            case IPart.Ptype.Receiver:
                Receiver rec = part as Receiver;
                if (rec != null)
                {
                    type = "Ствольная коробка";
                    characteristics += $"\nСкорострельность: {rec.delay}\nСкорость снаряда: {rec.force}\nКоличество снарядов: {rec.volume}";
                    icons[1].sprite = item.icon;
                }
                break;

            case IPart.Ptype.Scope:
                Scope sc = part as Scope;
                type = "Прицел";
                characteristics += $"\nРазброс: {sc.spread}\nДальность: {sc.range}";
                icons[1].sprite = item.icon;
                break;

            default:
                characteristics = "No additional info";
                break;
        }

        name_text.text = name;
        type_text.text = type;
        description_text.text = description;
        сharacteristics_text.text = characteristics;
    }

    public void SetPrice(int price)
    {
        string priceString = $"Price: \n{price.ToString()}"; 
    }
}

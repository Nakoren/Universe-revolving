using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PickupInformation_Table : MonoBehaviour
{
    private Canvas canvas;
    private PickupObject pickupObject;
    private TextMeshProUGUI[] texts;
    private Image[] icon;

    public Color32 grey = new Color32(135, 135, 135, 255);
    private Color32 blue = new Color32(38, 82, 255, 255);
    private Color32 violet = new Color32(155, 40, 255, 255);
    private Color32 orange = new Color32(255, 131, 40, 255);


    private void Awake()
    {
        pickupObject = GetComponent<PickupObject>();
        canvas = GetComponentInChildren<Canvas>(true);
        canvas.gameObject.SetActive(false);
        icon = GetComponentsInChildren<Image>(true);

        texts = GetComponentsInChildren<TextMeshProUGUI>(true);

        var part = pickupObject.m_item.part;
        var item = pickupObject.m_item;

        string type = "";
        var name = pickupObject.m_item.itemName.ToString();
        var description = pickupObject.m_item.description;
        string сharacteristics = $"Модификатор урона: {part.damageRate * 100}%";

        int rare = pickupObject.m_item.rare;
        switch (rare)
        {
            case 0: 
                texts[0].color = grey;
                break;
            case 1: 
                texts[0].color = blue;
                break;
            case 2: 
                texts[0].color = violet;
                break;
            case 3: 
                texts[0].color = orange; 
                break;
            default:
                texts[0].color = Color.white;
                break;
        }



        switch (part.type)
        {
            case IPart.Ptype.Magazine:
                Magazine mag = part as Magazine;
                if (mag != null)
                {
                    type = "Магазин";
                    сharacteristics += $"\nКоличествово патронов: {mag.cage}\nВремя перезарядки: {mag.recharge}";
                    icon[1].sprite=item.icon;
                }
                break;

            case IPart.Ptype.Receiver:
                Receiver rec = part as Receiver;
                if (rec != null)
                {
                    type = "Ствольная коробка";
                    сharacteristics += $"\nСкорострельность: {rec.delay}\nСкорость снаряда: {rec.force}\nКоличество снарядов: {rec.volume}";
                    icon[1].sprite=item.icon;
                }
                break;

            case IPart.Ptype.Scope:
                Scope sc = part as Scope;
                {
                    type = "Прицел";
                    сharacteristics += $"\nРазброс: {sc.spread}\nДальность: {sc.range}";
                    icon[1].sprite=item.icon;
                }

                break;

            default:
                сharacteristics = "No additional info";
                break;
        }

        texts[0].text = name;
        texts[1].text = type;
        texts[2].text = description;
        texts[3].text = сharacteristics;
    }


    private void LateUpdate()
    {
        if (canvas != null && Camera.main != null)
        {
            canvas.transform.rotation = Camera.main.transform.rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.gameObject.SetActive(false);
        }
    }

}

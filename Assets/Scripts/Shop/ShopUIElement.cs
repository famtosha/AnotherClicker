using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

public class ShopUIElement : MonoBehaviour
{
    public TextMeshProUGUI modifierName;
    public TextMeshProUGUI modifierCost;
    public Image modifierImage;
    private ShopUI _shopUI;

    public void Contruct(ShopUI shopUI)
    {
        _shopUI = shopUI;
    }

    public void SetElement(string name, int cost, Sprite sprite)
    {
        modifierName.text = name;
        modifierCost.text = cost.ToString();
        modifierImage.sprite = sprite;
    }

    public void Click()
    {
        _shopUI.Buy(this);
    }
}
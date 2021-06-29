using UnityEngine;
using System.Collections.Generic;
using Zenject;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private ShopUIElement _uiElementPrefub;
    [SerializeField] private GameObject _shopUIRoot;
    [SerializeField] private GameObject _shopUIElementsRoot;
    private List<ShopUIElement> _modifiers = new List<ShopUIElement>();
    private Shop _shop;
    private ClickerUI _clickerUI;

    [Inject]
    public void Contruct(Shop shop, ClickerUI clickerUI)
    {
        _shop = shop;
        _clickerUI = clickerUI;
        _clickerUI.ShopOpening += ShowShop;
        _shop.AssortmentChanged += UpdateListUI;
    }

    public void OnDestroy()
    {
        _clickerUI.ShopOpening -= ShowShop;
        _shop.AssortmentChanged -= UpdateListUI;
    }

    private void Start()
    {
        UpdateListUI();
        HideShop();
    }

    public void Clear()
    {
        for (int i = _modifiers.Count - 1; i >= 0; i--)
        {
            var temp = _modifiers[i];
            Destroy(temp.gameObject);
        }
        _modifiers.Clear();
    }

    public void HideShop()
    {
        _shopUIRoot.SetActive(false);
    }

    public void ShowShop()
    {
        _shopUIRoot.SetActive(true);
    }

    private void UpdateListUI()
    {
        Clear();
        foreach (var modifiler in _shop.coinModifiers)
        {
            CreateElement(modifiler);
        }
    }

    private void CreateElement(CoinModifier modifier)
    {
        var clone = Instantiate(_uiElementPrefub, _shopUIElementsRoot.transform);
        clone.SetElement(modifier.name, modifier.modifierCost, modifier.sprite);
        clone.Contruct(this);
        _modifiers.Add(clone);
    }

    public void Buy(ShopUIElement sender)
    {
        int id = _modifiers.IndexOf(sender);
        _shop.TryToBuyModilfer(id);
    }
}

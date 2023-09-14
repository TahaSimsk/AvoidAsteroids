using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using Product = UnityEngine.Purchasing.Product;

public class Store : MonoBehaviour
{
    const string RedSparrowDefinitionId = "com.simsek.avoidasteroids.redsparrow";
    public const string NewShipRedSparrowKey = "RedSparrow";

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == RedSparrowDefinitionId)
        {
            PlayerPrefs.SetInt(NewShipRedSparrowKey, 1);
        }

    }
    
    public void OnPurchaseFailed(Product product, PurchaseFailureDescription description)
    {
        Debug.LogWarning($"Failed to purchase product {product}, because {description}");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    [SerializeField]
    GameObject shopUI;

    int selectedItem = 0;
    int currentItemCost = 0;

    private Player player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<Player>();
            if (player)
            {
                UIManager.Instance.OpenShop(player.diamonds);
            }
            shopUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            shopUI.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        switch (item)
        {
            case 0:
                UIManager.Instance.UpdateSelection(71);
                selectedItem = 0;
                currentItemCost = 200;
                break;
            case 1:
                UIManager.Instance.UpdateSelection(-18);
                selectedItem = 1;
                currentItemCost = 400;
                break;
            case 2:
                UIManager.Instance.UpdateSelection(-124);
                selectedItem = 2;
                currentItemCost = 100;
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }

    public void BuyItem()
    {
        if (player.diamonds >= currentItemCost)
        {
            switch (selectedItem)
            {
                case 0:
                    //Logic for buying flame sword
                    break;
                case 1:
                    // Logic for buying boots of flight
                    break;
                case 2:
                    GameManager.Instance.hasKey = true;
                    break;
                default:
                    Debug.Log("Error");
                    break;
            }
            player.diamonds -= currentItemCost;
            UIManager.Instance.OpenShop(player.diamonds);
        }
        else
        {
            Debug.Log("Not enough gems");
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    private static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("UI Manager is null.");
            }
            return instance;
        }
    }

    public Text shopGemCountText;
    public Image selectionImage;
    public Text gemCountText;

    private void Awake()
    {
        instance = this;
    }

    public void OpenShop(int gemCount)
    {
        shopGemCountText.text = gemCount.ToString() + "G";
    }


    public void UpdateSelection(int yValue)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yValue);
    }

    public void UpdateGemCount(int count)
    {
        gemCountText.text = count.ToString();
    }

}

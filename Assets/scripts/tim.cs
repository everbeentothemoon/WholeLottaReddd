using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class tim : MonoBehaviour
{
    [SerializeField]
    public float money = 100f;  // Available money
    public List<GameObject> shopList;  // List of shop item game objects
    public float[] prices;  // Array of item prices
    public GameObject destinationParentBackpack;
    public GameObject destinationParentChest;

    public List<GameObject> buyButton;
    public List<GameObject> sellButton;
    public List<GameObject> moveToChestButton;
    public List<GameObject> moveToBackpackButton;
    public float maxItems = 0f;

    public float priceTag;
    public TextMeshProUGUI priceTagText;
    public TextMeshProUGUI moneyText;
    public float timer = 20f;
    public TextMeshProUGUI timerText;

    public GameObject pausemenu;
    public GameObject pausegame;

    public GameObject chestButton;
    public GameObject shopButton;
    public GameObject Shop;

    public GameObject cycle;
    public GameObject cycle2;
    public GameObject cycle3;
    public float cycletimer = 100f;

    public int backpackMax = 3;
    public int chestMax = 6;

    int numChildren = 0;
    int chestNumChildren = 0;

    public GameObject buttonToDisable;
    public GameObject buttonToDisable2;

    public void Start()
    {
        shopButton.SetActive(false);
        cycle.SetActive(true);
        cycle2.SetActive(false);
        cycle3.SetActive(false);
    }
    private void Update()
    {
        cycletimer -= Time.deltaTime;

        if (cycletimer <= 80f)
        {
            cycle.SetActive(false);
            cycle2.SetActive(true);
        }

        if (cycletimer <= 50f)
        {
            cycle2.SetActive(false);
            cycle3.SetActive(true);
        }

        moneyText.text = "$" + money.ToString();

        string integerString = timer.ToString("F0");

        // Set the TextMeshPro text to the integer string
        timerText.text = integerString;

        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            Debug.Log("1 " + timer);

            if (timer <= 0f)
            {
                money += 50;
                timer += 25f;
            }
        }


    }

    //the first two functions go on one buy button
    public void Purchase(int index)
    {
        if (money >= prices[index])
        {
            if (shopList[index] != null)
            {
                //int numChildren = destinationParentBackpack.transform.childCount;

                if (numChildren < backpackMax) // Check if the number of children is less than 3
                {
                    numChildren += 1;
                    priceTag = prices[index];
                    priceTagText.text = "$" + priceTag.ToString();
                    money -= prices[index];

                    //shopList[index].SetActive(false);
                    shopList[index].transform.SetParent(destinationParentBackpack.transform, true);
                    shopList[index].transform.SetSiblingIndex(0);
                    buyButton[index].SetActive(false);
                    sellButton[index].SetActive(true);
                    moveToChestButton[index].SetActive(true);
                    Debug.Log("Item purchased: " + shopList[index].name);
                }
                else
                {
                    Debug.Log("Cannot purchase more than 3 items.");
                }
            }
        }
        else
        {
            Debug.Log("Insufficient funds to purchase item: " + shopList[index].name);
        }
    }



    public void Sell(int index)
    {
        numChildren -= 1;
        shopList[index].SetActive(false);
        money += prices[index];
    }

    public void MoveToChest(int index)
    {
       
            numChildren -= 1;
            chestNumChildren += 1;
            shopList[index].transform.SetParent(destinationParentChest.transform, true);
            shopList[index].transform.SetSiblingIndex(0);
            sellButton[index].SetActive(false);
            moveToChestButton[index].SetActive(true);
        if(chestNumChildren > 6)
        {
            Debug.Log("full");
        }
 
    }

    public void MoveToBackPack(int index)
    {
 
            numChildren += 1;
            chestNumChildren -= 1;
            shopList[index].transform.SetParent(destinationParentBackpack.transform, true);
            shopList[index].transform.SetSiblingIndex(0);
            sellButton[index].SetActive(true);
            moveToBackpackButton[index].SetActive(false);
        if (numChildren > 3)
        {
            Debug.Log("full");
        }
  
    }

    public void UpgradeBackpack()
    {
        backpackMax = 6;
        money -= 100f;
        buttonToDisable.SetActive(false);
    }

    public void UpgradeChest()
    {
        chestMax = 15;
        money -= 200f;
        buttonToDisable2.SetActive(false);
    }

    public void ChangeScreensToChest()
    {
        Shop.SetActive(false);
        destinationParentChest.SetActive(true);
        shopButton.SetActive(true);
    }

    public void ChangeScreensToShop()
    {
        Shop.SetActive(true);
        destinationParentChest.SetActive(false);
        chestButton.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("WholeLottaReddd");
    }

    public void PauseButton()
    {
        Time.timeScale = 0f;
        pausegame.SetActive(false);
        pausemenu.SetActive(true);
    }

    public void ResumeButton()
    {
        Time.timeScale = 1f;
        pausegame.SetActive(true);
        pausemenu.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}

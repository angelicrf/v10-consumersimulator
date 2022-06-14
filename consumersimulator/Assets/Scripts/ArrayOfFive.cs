using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArrayOfFive : MonoBehaviour
{
    public Button myButton;
    public TMP_Text textField;

    private Timer timer;
    private List<string> arrayoffive;
    public List<string> listNumbers;
    public GameObject cellRItems;
    public GameObject cellLItems;
    public AudioSource clickBtnAudio;
    void Start()
    {
        arrayoffive = new List<string>
            {
            "WineBottle","Shampoo","Bleach","ToiletPaper","Pizza","CansPack","WaterBottle","Banana","Pasta","SlicedBread","Apple","Rice","Chicken","Sauce","Sushis","Coffee","Ham","MashPotatoe"
            };//MashPotatoe - Flour
        //"","Shampoo","Book","Cake",,"Cereals","Sugar","ChocolateBox",
        //        "Chips",,"Bleach","Cheese","Pizza","Artichoke","Ham","PetFood","Teabox","Vase",,"Garlic",
        //        "Oil","Salt","Paintings"
        listNumbers = new List<string>();
        timer = FindObjectOfType<Timer>();
        RandmeItems();
    }
    private void RandmeItems()
    {
        if (textField)
        {

            string pickItem;          
            //if (!mainItemsUi.activeSelf)
            //{
            //    mainItemsUi.SetActive( true );
            //}
            for (int i = 0; i < 5; i++)
            {
                do
                {
                    pickItem = arrayoffive[new System.Random().Next( 0 , arrayoffive.Count )];
                } while (listNumbers.Contains( pickItem ));
                listNumbers.Add( pickItem );
            }
            if (listNumbers.Count == 5)
            {
                foreach (var item in listNumbers)
                {
                    textField.text += item + "\n";
                    if (cellRItems)
                    {
                        cellRItems.GetComponent<TMP_Text>().text += item + "\n";
                    }
                    if (cellLItems)
                    {
                        cellLItems.GetComponent<TMP_Text>().text += item + "\n";
                    }
                }
            }
        }
    }
    public void TaskOnClick()
    {
        if (timer)
        {
            clickBtnAudio.Play();
            DeactivateItemMenu();
        }
    }
    private void DeactivateItemMenu()
    {
        StartCoroutine( timer.GameStartDelay() );
  
    }
}
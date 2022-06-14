using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class StaticStatus : MonoBehaviour
{

    private string getCartName;
    private string stringItem = "";
    private int thisLength = 0;
    private GameObject itemTextUI;
    private GameObject itemTextQuantity;
    private ItemUI itemUI;
 
    private void Start()
    {
        itemUI = FindObjectOfType<ItemUI>();
        arrayOfFive = FindObjectOfType<ArrayOfFive>();
        if (arrayOfFive)
        {
            Debug.Log( "arrayOfFive is " + arrayOfFive.listNumbers.Count );
        }
    }
    
    private ArrayOfFive arrayOfFive;
    public void GrabStaticStatSelectStart()
    {
        itemUI.ActivateCanvas();
        itemTextUI = GameObject.Find( "ItemTxt" );
        itemTextQuantity = GameObject.Find( "QuantityTxt" );
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        if (itemUI && itemTextQuantity)
        {
            itemTextUI.GetComponent<Text>().text = "Item";
            itemTextQuantity.GetComponent<Text>().text = "Quantity";
        }
    }
    public void GrabStaticStatSelectFinish()
    {
        StartCoroutine( ObjectCartCo() );
    }
    public void CartKinematic()
    {
        getCartName = Carts.cart;
        Debug.Log( "getCartName" + getCartName );
        if(getCartName != null)
            GameObject.Find( getCartName ).GetComponent<Rigidbody>().isKinematic = true;
    }
    public void CartNonKinematic()
    {
        getCartName = Carts.cart;
        if(getCartName != null)
            GameObject.Find( getCartName ).GetComponent<Rigidbody>().isKinematic = false;
    }
    public void CartParentObject()
    {
        itemTextUI = GameObject.Find( "ItemTxt" );
        itemTextQuantity = GameObject.Find( "QuantityTxt" );
        
        getCartName = Carts.cart;

        if (getCartName != null)
        {
            Debug.Log( "cartNameisNotNull " + getCartName );
            gameObject.transform.parent = GameObject.Find("CenterCart").transform;
            gameObject.transform.position = GameObject.Find( "CenterCart" ).transform.position;
            Carts.isItemCart = true;
            CartItems.ItemName = gameObject.name;
            stringItem = CartItems.ItemName.Split( '_' )[0];
        
            for (int i = 0; i < CartItems.ItemCall.Count; i++)
                {
                    if (!CartItems.ItemCall[i].Name.Contains( stringItem ))
                    {
                        CartItems.AddItems( stringItem );
                    if (itemTextUI && itemTextQuantity)
                    {
                        itemTextUI.GetComponent<Text>().text = stringItem;
                        itemTextQuantity.GetComponent<Text>().text = "1";
                    }
                }
                } 
            CartItems.TotalItems = CartItems.ItemCall.Count;
          
            //items Objects
            if (CartItems.ItemCall.Count == 0)
            {
                thisLength = 1;
            }
            else
            {
                thisLength = CartItems.TotalItems;
            }
            CartItems.AddItemsObject( thisLength , stringItem , $"{stringItem} Desc" );
            if (arrayOfFive && thisLength > 0)
            {
                Debug.Log( "arrayExistCart.." + arrayOfFive.listNumbers.Count );
                CartItems.MatchedCount = CartItems.ItemCall.Where( x => arrayOfFive.listNumbers.Contains( x.Name ) ).Count();
                Debug.Log( "MatchedItemsCart.." + CartItems.MatchedCount );
            }
            StartCoroutine( DeactivatePanelCartCo() );
         
        }
        else
        {
            //E-Cart
            string eCartItem = gameObject.name;
            stringItem = eCartItem.Split( '_' )[0];
            CartItems.AddItems( stringItem );
            CartItems.TotalItems = CartItems.HoldItems.Count;
            if (itemTextUI && itemTextQuantity)
            {
                itemTextUI.GetComponent<Text>().text = "Ecart adedd: \n" + stringItem;
                itemTextQuantity.GetComponent<Text>().text = "1";
            }
            //items Objects
            if (CartItems.ItemCall.Count == 0)
            {
                thisLength = 1;
            }
            else
            {
                thisLength = CartItems.TotalItems;
            }
            CartItems.AddItemsObject( thisLength , stringItem , $"{stringItem} Desc" );
            for (int i = 0; i < thisLength; i++)
            {
                Debug.Log( "itemsObject " + CartItems.ItemCall[i].Name + CartItems.ItemCall[i].Id + CartItems.ItemCall[i].Description );
            }
            if (arrayOfFive && thisLength > 0)
            {
                Debug.Log( "arrayExist.." + arrayOfFive.listNumbers.Count );
                CartItems.MatchedCount = CartItems.ItemCall.Where( x => arrayOfFive.listNumbers.Contains( x.Name ) ).Count();
                Debug.Log( "MatchedItems.." + CartItems.MatchedCount);
                gameObject.transform.position = new Vector3( 40 , 50 , 0 );
                StartCoroutine(DeactivatePanelCo());
            }
         }
        }
  
    private IEnumerator ObjectCartCo()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds( 2f );
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
   
    }
    private IEnumerator DeactivatePanelCo()
    {
        yield return new WaitForSeconds( 2f );
        itemUI.DiactivateCanvas();  
        gameObject.SetActive( false );
    }
    private IEnumerator DeactivatePanelCartCo()
    {
        yield return new WaitForSeconds( 2f );
        itemUI.DiactivateCanvas();
        Destroy( gameObject.GetComponent<XRGrabInteractable>() );
        Destroy( gameObject.GetComponent<Rigidbody>() );
       
    }

}
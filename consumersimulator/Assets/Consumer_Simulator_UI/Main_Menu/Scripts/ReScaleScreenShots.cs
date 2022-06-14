using UnityEngine;

public class ReScaleScreenShots : MonoBehaviour
{ 
    private bool isClicked = false;
    private Vector3 originalPos;
    public GameObject deactivateMenu;
    private void Start()
    {
        originalPos = gameObject.transform.position;
    }
    public void ScaleScreenShot()
    {
      
        isClicked = !isClicked;

        if ( isClicked)
        {
            deactivateMenu.SetActive( false );
            gameObject.transform.localScale = new Vector3( 2 , 2 , 2 );
            gameObject.transform.position = new Vector3( -1 , gameObject.transform.position.y , gameObject.transform.position.z - 2.5f);

        }
        if (gameObject && !isClicked)
        {
            deactivateMenu.SetActive( true );
            gameObject.transform.localScale = new Vector3( 1 , 1 , 1 );
            gameObject.transform.position = originalPos;
        }
    }
}

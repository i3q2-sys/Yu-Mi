using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyWall : MonoBehaviour
{
	public GameObject ImageTemplate;
	public GameObject PostItTemplate;
	public Transform InstantiationPoint;
	public GameObject SelectedElement;

	public GameObject UI;


    // Start is called before the first frame update
    void Start()
    {
		//PickImage(512);
	}

    // Update is called once per frame
    void Update()
    {
		MoveElements();
    }

	public void CloseUI() 
	{
		UI.SetActive(false);
	}

	public void OpenUI() { UI.SetActive(true); }

	public void MoveElements() 
	{
		if (SelectedElement == null)
		{
			if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Stationary))
			{
				Debug.Log("Hey");
				Vector2 test = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
				RaycastHit2D hit = Physics2D.Raycast(test, (Input.GetTouch(0).position));
				if (hit.collider)
				{
					if (hit.collider.CompareTag("Photo"))
					{
						SelectedElement = hit.collider.gameObject;
						Debug.Log("Selected");
					}
				}
			}
		}
		else 
		{
			if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Moved))
			{

				Vector2 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
				SelectedElement.transform.position = pos;

			}
		}

		if (SelectedElement != null && Input.touchCount == 0) 
		{
			SelectedElement = null;
		}
	}






	public void PickImage( int maxSize )
{
	NativeGallery.Permission permission = NativeGallery.GetImageFromGallery( ( path ) =>
	{
		Debug.Log( "Image path: " + path );
		if( path != null )
		{
			// Create Texture from selected image
			Texture2D texture = NativeGallery.LoadImageAtPath( path, maxSize );
			Sprite photo = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
			if( texture == null )
			{
				Debug.Log( "Couldn't load texture from " + path );
				return;
			}
			GameObject a = Instantiate(ImageTemplate,InstantiationPoint.position, Quaternion.identity);
			a.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
			a.GetComponent<SpriteRenderer>().sprite = photo;
			a.GetComponent<SpriteRenderer>().sortingOrder = 1;
			a.tag = "Photo";
			CloseUI();
			
		}
	} );

	Debug.Log( "Permission result: " + permission );
}

}

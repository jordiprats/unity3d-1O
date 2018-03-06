using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour {

    bool isSelecting = false;
    Vector3 mousePosition1;
    
 
	public bool IsWithinSelectionBounds( GameObject gameObject )
    {
        if( !isSelecting )
            return false;
 
        var camera = Camera.main;
        var viewportBounds =
            DrawUtils.GetViewportBounds( camera, mousePosition1, Input.mousePosition );
            
        return viewportBounds.Contains(
            camera.WorldToViewportPoint( gameObject.transform.position ) );
    }

    void Update()
    {
        // If we press the left mouse button, save mouse location and begin selection
        if( Input.GetMouseButtonDown( 0 ) )
        {
            isSelecting = true;
            mousePosition1 = Input.mousePosition;
        }
        // If we let go of the left mouse button, end selection
        if( Input.GetMouseButtonUp( 0 ) )
            isSelecting = false;
    }
 
    void OnGUI()
    {
        if( isSelecting )
        {
            // Create a rect from both mouse positions
            var rect = DrawUtils.GetScreenRect( mousePosition1, Input.mousePosition );
            DrawUtils.DrawScreenRect( rect, new Color( 0.8f, 0.8f, 0.95f, 0.25f ) );
            DrawUtils.DrawScreenRectBorder( rect, 2, new Color( 0.8f, 0.8f, 0.95f ) );
        }
    }
}

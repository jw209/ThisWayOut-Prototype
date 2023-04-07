using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGuide : MonoBehaviour
{
  public Transform pivot;
  private Vector3 mousePos;
  private Vector3 difference;

  void Update()
  {
    Cursor.visible = false;
    
    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    difference = pivot.position - mousePos;
    difference.Normalize();
    
    transform.position = pivot.position - difference;
  }
}

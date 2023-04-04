using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGuide : MonoBehaviour
{
  private Vector3 mousePos;
  private Vector3 difference;
  public Transform pivotTransform;

  // Update is called once per frame
  void FixedUpdate()
  {
    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    difference = pivotTransform.position - mousePos;
    difference.Normalize();
    transform.position = pivotTransform.position - difference;
  }
}

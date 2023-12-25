using System;
using UnityEditor.PackageManager;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField]private Camera camera;
    private bool inGrid = false;
    private bool isEnded = true;
    private bool canStart = false;
    private Vector3 gridPos = new Vector3();
    private Vector3 startPosition = new Vector3();
    private Rune[][] _allRunes = Array.Empty<Rune[]>();
    private Rune[] selectedRunes = Array.Empty<Rune>();
    private Vector3[] selectedRunesPositions = Array.Empty<Vector3>();
    [SerializeField] private float runeSize = 50;
    private void Start()
    {
        gridPos = transform.position;
        inGrid = false;
        isEnded = true;
        canStart = false;
    }

    private void OnMouseDown()
    {
         startPosition = camera.ScreenToWorldPoint(Input.mousePosition);
         Debug.Log("Start");
         inGrid = true;
         isEnded = false;
         var isSelected = TrySelectRunes();
         if (isSelected)
         {

         }
         else
         {
                 
         }
    }
     private void OnMouseDrag()
     {
         if (!isEnded && inGrid)
         {
             Debug.Log("In");
             var isSelected = TrySelectRunes();
             if (isSelected)
             {

             }
             else
             {
                 
             }
         }
     }

     private void OnMouseUp()
     {
         Debug.Log("End");
         isEnded = true;
         if (inGrid)
         {
             TryUseRunes();
         }
     }

     private void OnMouseExit()
     {
         Debug.Log("Vixod");
         inGrid = false;
     }
     private void OnMouseEnter()
     {
         inGrid = true;
         Debug.Log("Vxod");
     }

     private void TryUseRunes()
     {
         
     }
     private bool TrySelectRunes(out Rune rune, Vector3 startPos)
     {
         rune = new Rune();
         var targetPos = new Vector3();
         var center = gridPos;
         float margin = _allRunes[0].Length / 2 * runeSize;
         if (startPos.x > center.x + margin || startPos.x < center.x - margin || startPos.y > center.y + margin ||
             startPos.y < center.y - margin)
         {
             return false;
         }
         else
         {
             for (int i = 0; i < _allRunes.Length;i++)
             {
                 for (int k = 0; k < _allRunes[0].Length;k++)
                 {
                     if (Math.Abs(_allRunes[i][k].position.x - targetPos.x) < runeSize &&
                         Math.Abs(_allRunes[i][k].position.y - targetPos.y) < runeSize)
                     {
                         rune = _allRunes[i][k];
                     }
                      
                 }
             }
             return true;

         }
     }

     private EDirection GetDirection(Vector2 pos,Vector2 pos2)
     {
         
         if (pos.y > pos2.y && pos.x == pos2.x) {
             return EDirection.N;
         }
         if (pos.y == pos2.y && pos.x < pos2.x) {
             return EDirection.E;
         }
         if (pos.y == pos2.y && pos.x > pos2.x) {
             return EDirection.W;
         }
         if (pos.y < pos2.y && pos.x == pos2.x) {
             return EDirection.S;
         }
         if (pos.y > pos2.y && pos.x < pos2.x) {
             return EDirection.NE;
         }
         if (pos.y > pos2.y && pos.x > pos2.x) {
             return EDirection.NW;
         }
         if (pos.y < pos2.y && pos.x < pos2.x) {
             return EDirection.SE;
         }
         if (pos.y < pos2.y && pos.x > pos2.x) {
             return EDirection.SW;
         }
         return EDirection.EXCEPTION;
     }

     
}

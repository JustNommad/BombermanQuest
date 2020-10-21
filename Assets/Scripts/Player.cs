using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask raycastMask;
    [SerializeField] private LayerMask raycastMaskExplosion;
    [SerializeField] private GameObject bomb;
    [SerializeField] private GameObject placeForBomb;
    private bool isInMovement;
    
    void Update()
    {
        if (isInMovement)
            return;
        if (Input.GetKeyDown(KeyCode.A))
            MovePlayerTo(Vector2.left);
        if (Input.GetKeyDown(KeyCode.D))
            MovePlayerTo(Vector2.right);
        if (Input.GetKeyDown(KeyCode.W))
            MovePlayerTo(Vector2.up);
        if (Input.GetKeyDown(KeyCode.S))
            MovePlayerTo(Vector2.down);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlantBomb();
        }
    }

    private void MovePlayerTo(Vector2 dir)
    {
        if (Raycast(dir))
            return;
        isInMovement = true;

        var pos = (Vector2) transform.position + dir;
        transform.DOMove(pos, 0.5f).OnComplete(() =>
        {
            isInMovement = false;
        });
    }

    private bool Raycast(Vector2 dir)
    {    
        var hit = Physics2D.Raycast(transform.position, dir, 1f, raycastMask);
        return hit.collider != null;
    }

    //private GameObject RaycastFromCamera()
    //{
    //    var hit = Physics2D.Raycast(
    //        Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1f);
    //    return hit.collider ? hit.collider.gameObject : null;
    //}

    private void PlantBomb()
    {
        var b = Instantiate(bomb, placeForBomb.transform.parent, true);
        b.transform.position = transform.position;
    }
}

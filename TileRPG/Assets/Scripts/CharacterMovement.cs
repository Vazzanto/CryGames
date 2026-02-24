using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody2D SelectedUnit;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.OverlapPoint(mousePosition);
            if (hit != null)
            {
                if (hit.transform.CompareTag("Unit"))
                {
                    this.SelectUnit(hit.transform.gameObject);
                }
            }
            else if (hit == null && SelectedUnit != null)
            {
                this.MoveSelectedUnit(mousePosition);
            }
        }
    }

    private void SelectUnit(GameObject unit)
    {
        if (unit.GetComponent<Rigidbody2D>() != SelectedUnit)
        {
            this.DeselectUnit();
            SelectedUnit = unit.GetComponent<Rigidbody2D>();
            unit.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            this.DeselectUnit();
        }
    }

    private void DeselectUnit()
    {
        if (SelectedUnit != null)
        {
            SelectedUnit.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            SelectedUnit = null;
        }
    }

    private void MoveSelectedUnit(Vector2 targetPosition)
    {
        if (SelectedUnit != null)
        {
            SelectedUnit.transform.position = Vector2.MoveTowards(SelectedUnit.transform.position, targetPosition, 10);
            this.DeselectUnit();
        }
    }
}

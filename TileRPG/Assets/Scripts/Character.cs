using UnityEngine;

public class Character : MonoBehaviour  //Creazione di un oggetto
{
    /* Pascal Case: Tipo di scrittura dove tutte le parole sono attaccayìte e ogni parola inizia con la maiuscola
     * Nel public si usano le maiuscole per la prima parola (es: CiaoBello)
     * Nel private NON si usano le maiuscole per la prima parola (es: ciaoBello)
     * */
    public int Vita = 100;
    public int Attacco = 15;
    public int Difesa = 5;

    public Character Bersaglio;



    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Bersaglio != null)
            {
                Bersaglio.Vita -= this.Attacco - Bersaglio.Difesa;      // *istanza.parametro_dell'istanza   * Con "this" indichiamo istanza corrente   * -=
            }
        }

        if (this.Vita <= 0 )
        {
            Destroy(this.gameObject);
        }
    }
}

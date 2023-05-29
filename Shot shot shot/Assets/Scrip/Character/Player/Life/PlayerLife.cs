using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour, ITakeDamage
{
    [SerializeField] float life;
    [SerializeField] Image lifebar;
    [SerializeField] GameObject GameOverFace;

    private float MaxLifeReference;
    private bool inmune = false;
    // Start is called before the first frame update
    void Start()
    {
        MaxLifeReference = life;
       
    }

    // Update is called once per frame
    void Update()
    {

        lifebar.fillAmount = life/ MaxLifeReference;
        if (life == 0)
        {
            GamerOver();
        }
    }

    private void GamerOver()
    {
        Time.timeScale = 0;
        GameOverFace.SetActive(true);

    }

    private void OnTriggerEnter(Collider other)
    {
      
    }

    public void TakeDamage() 
    {
        if (inmune==false)
        {
            life--;
            StartCoroutine(inmunity());
        }
       
    }

    IEnumerator inmunity() 
    {
        Debug.Log("we enter");
        inmune = true;
        yield return new WaitForSeconds(3);
        inmune = false;
        Debug.Log("we leave");
    }
}

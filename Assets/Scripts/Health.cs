using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] Image _healthBar;
    [SerializeField] float _maxhealth;
    [SerializeField] float _health;
    [SerializeField] GameObject healthBarUI;

    public float Maxhealth { get => _maxhealth; set => _maxhealth = value; }


    // Start is called before the first frame update
    void Start()
    {
        _healthBar.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void TakeDame(float damage)
    {
        _maxhealth -= damage;
        _healthBar.fillAmount = _maxhealth / 100f;
        healthBarUI.SetActive(true);
        if (healthBarUI.activeSelf)
        {
            StartCoroutine(HideHealthBarUI());
        }
    }

    IEnumerator HideHealthBarUI()
    {
        yield return new WaitForSeconds(2);
        healthBarUI.SetActive(false);
    }
}

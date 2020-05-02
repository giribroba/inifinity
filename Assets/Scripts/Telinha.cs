﻿using UnityEngine;
using UnityEngine.UI;

public class Telinha : MonoBehaviour
{
    [SerializeField] private Sprite[] imagens;
    [SerializeField] private Image filtro;
    private int index;
    void Update()
    {
        this.gameObject.GetComponent<Image>().sprite = imagens[index];
    }

    public void Avancar()
    {
        if (index < imagens.Length)
            index++;
    }

    public void Voltar()
    {
        if (index > 0)
            index--;
    }
    public void Continuar()
    {
        if (index == imagens.Length - 1)
        {
            Time.timeScale = 1;
            filtro.gameObject.SetActive(true);
            ObstaculosBehaviour.boost = true;
            Destroy(this.gameObject);
        }
    }
}

﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Vida : MonoBehaviour
{
    [SerializeField] private ParticleSystem particula;
    [SerializeField] private GameObject barraMovel, barraPreenchedora;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private float velocidade;
    private float vida = 100;
    private RectTransform rt;
    private Image iBarraPreenchedora;
    private Renderer rParticula;
    public float VidaVar { get { return vida; } set { vida = value; } }
    void Start()
    {
        vida = 100;
        rParticula = particula.GetComponent<Renderer>();
        iBarraPreenchedora = barraPreenchedora.GetComponent<Image>();
        rt = this.GetComponent<RectTransform>();
    }

    void Update()
    {
        print(vida);
        if (Player.doente)
        {
            particula.enableEmission = true;
            rParticula.material.color = iBarraPreenchedora.color;
            particula.transform.position = barraMovel.transform.position - (Vector3.right * 0.05f);

            iBarraPreenchedora.fillAmount = vida / 100;
            iBarraPreenchedora.color = new Color(1, 0, vida / 100);
            barraMovel.transform.localPosition = Vector2.right * (rt.rect.width * vida / 100 - rt.rect.width / 2);
            if (vida > 0)
                vida -= velocidade * Time.deltaTime;
        }

        if (vida <= 0)
        {
            StartCoroutine("GameOver");
        }
    }

    private IEnumerator GameOver()
    {
        Player.execute = true;
        Player.doente = false;
        gameOver.SetActive(true);
        yield return new WaitForSeconds(1);
        Mute.Selecionar(0);
        SceneManager.LoadScene("Menu");
    }
}

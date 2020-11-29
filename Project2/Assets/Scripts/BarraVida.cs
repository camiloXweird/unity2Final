﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Slider slider;

    public void setVida(int vida)
    {
        slider.value = vida;
    }

    public void setVidaMaxima(int vidaMax)
    {
        slider.maxValue = vidaMax;
    }
}

﻿using System;
public interface IFade
{
    event Action OnFade;
    event Action OnEndFade;
    void Fade(float alpha, float duration);
}

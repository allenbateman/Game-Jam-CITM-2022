using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation
{
    private Sprite[] m_Frames;
    private float m_Timer;
    private float m_Time;
    private int m_Index;
    private SpriteRenderer m_SR;

    public Animation(Sprite[] frames, float frameTime, SpriteRenderer sr)
    {
        m_Frames = frames;
        m_Time = frameTime;

        m_Index = 0;
        m_Timer = 0;
        m_SR = sr;
        m_SR.sprite = m_Frames[0];
    }

    public void Update()
    {
        m_Timer += Time.deltaTime;

        if(m_Timer >= m_Time)
        {
            m_Index++;

            if(m_Index >= m_Frames.Length)
            {
                m_Index = m_Frames.Length - 1;
            }

            m_SR.sprite = m_Frames[m_Index];

            m_Timer = 0;
        }
    }

    public bool Finished()
    {
        return m_Index == m_Frames.Length - 1;
    }

    public void Reset()
    {
        m_Index = 0;
        m_Timer = 0;
        m_SR.sprite = m_Frames[0];
    }
}

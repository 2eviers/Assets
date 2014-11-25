using System;
using System.Collections.Generic;
using AssemblyCSharp;
using UnityEngine;
using System.Collections;

public class Score {

    private readonly List<Membre> _tableDesMembres;

    private float _point;
    private float _lastTimeChange;

    public Score()
    {
        _point = 0;
        _lastTimeChange = Time.time;
        _tableDesMembres = new List<Membre>();
    }

    public void AddData(Membre mP)
    {
        DiscretTime();
        _tableDesMembres.Add(mP);
    }

    public void RemoveData(Membre mP)
    {
        DiscretTime();
    }

    public float globalMultiplicateur()
    {

        float globalMultiplicateur = 1f;
        GameManager Mngr = Camera.main.GetComponent<GameManager>();
        foreach (Membre member in Mngr.Player.GetComponent<PlayerAction>().GetMembres())
        {

            globalMultiplicateur *= member.BonusMultiplicator * member.TimeDuration;
        }
        return globalMultiplicateur;
    }

    public float Point()
    {
        float point = _point + (Time.time - _lastTimeChange) * globalMultiplicateur();
        
        return (point);
    }


    public List<Membre> GetMembres()
    {
        return _tableDesMembres;
    }

    private void DiscretTime()
    {
        _point = Point();
        _lastTimeChange = Time.time;
    }

    public String PointToString()
    {
        var unit = new List<string>();
        unit.Add("PP");
        unit.Add("k PP"); //1000
        unit.Add("M PP");
        unit.Add("B PP");
        unit.Add("T PP");
        unit.Add("q PP");
        unit.Add("Q PP");
        unit.Add("s PP");
        unit.Add("S PP");
        unit.Add("O PP");
        unit.Add("N PP");
        unit.Add("d PP");
        unit.Add("U PP");
        unit.Add("D PP");


        return "";
    }
}

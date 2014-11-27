using System;
using System.Collections.Generic;
using AssemblyCSharp;
using UnityEngine;
using System.Collections;

public class Score {

    private readonly List<Membre> _tableDesMembres;

    private float _point;
    private float _lastTimeChange;

    readonly List<String> _unit = new List<String>
        {
            "PP",
            "k PP",
            "M PP",
            "B PP",
            "T PP",
            "q PP",
            "Q PP",
            "s PP",
            "S PP",
            "O PP",
            "N PP",
            "d PP",
            "U PP",
            "D PP"
        };

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

        float point = Point();

        IEnumerator enumerator = _unit.GetEnumerator();
        enumerator.MoveNext();
        while (point > 1000 && enumerator.MoveNext())
        {            
            point /= 1000;
        }

        point = Mathf.Round(point*1000)/1000;

        return point + " " + enumerator.Current;
    }
}

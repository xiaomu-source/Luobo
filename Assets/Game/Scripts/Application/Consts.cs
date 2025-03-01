﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class Consts
{
    //目录
    public static readonly string LevelDir = Application.dataPath + @"\Game\Resources\Res\Levels";
    public static readonly string MapDir = Application.dataPath + @"\Game\Resources\Res\Maps";
    public static readonly string CardDir = Application.dataPath + @"\Game\Resources\Res\Cards";

    //存档
    public const string GameProgress = "GameProgress";

    //Model
    public const string M_GameModel = "M_GameModel";
    public const string M_RoundModel = "M_RoundModel";


    //View
    public const string V_Start = "V_Start";
    public const string V_Select = "V_Select";
    public const string V_Board = "V_Board";
    public const string V_CountDown = "V_CountDown";
    public const string V_Win = "V_Win";
    public const string V_Lost = "V_Lost";
    public const string V_Sytem = "V_Sytem";
    public const string V_Complete = "V_Complete";
    public const string V_Spanwner = "V_Spanwner";
    

    //Controller
    public const string E_StartUp = "E_StartUp";

    public const string E_EnterScene = "E_EnterScene"; //SceneArgs
    public const string E_ExitScene = "E_ExitScene";//SceneArgs

    public const string E_StartLevel = "E_StartLevel"; //StartLevelArgs
    public const string E_EndLevel = "E_EndLevel";//EndLevelArgs

    public const string E_CountDownComplete = "E_CountDownComplete";

    public const string E_StartRound = "E_StartRound";//StartRoundArgs
    public const string E_SpawnMonster = "E_SpawnMonster";//SpawnMonsterArgs
}

public enum GameSpeed
{
    One,
    Two
}

public enum MonsterType
{
    Monster0,
    Monster1,
    Monster2,
    Monster3,
    Monster4,
    Monster5
}
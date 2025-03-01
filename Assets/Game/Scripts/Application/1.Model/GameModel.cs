﻿using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class GameModel : Model
{
    #region 常量
    #endregion

    #region 事件
    #endregion

    #region 字段
    //所有的关卡
    List<Level> m_Levels = new List<Level>();

    //最大通关关卡索引
    int m_GameProgress = -1;

    //当前游戏的关卡索引
    int m_PlayLevelIndex = -1;

    //游戏当前分数
    int m_score = 0;

    //是否游戏中
    bool m_isPlaying = false;
    #endregion

    #region 属性
    public override string Name
    {
        get { return Consts.M_GameModel; }
    }

    public int Score
    {
        get { return m_score; }
        set { m_score = value; }
    }

    public int LevelCount
    {
        get { return m_Levels.Count; }
    }

    public int GameProgress
    {
        get { return m_GameProgress; }
    }

    public int PlayLevelIndex
    {
        get { return m_PlayLevelIndex; }
    }

    public bool IsPlaying
    {
        get { return m_isPlaying; }
        set { m_isPlaying = value; }
    }

    public bool IsGamePassed
    {
        get { return m_GameProgress >= LevelCount - 1; }
    }

    public List<Level> AllLevels
    {
        get { return m_Levels; }
    }

    public Level PlayLevel
    {
        get
        {
            if (m_PlayLevelIndex < 0 || m_PlayLevelIndex > m_Levels.Count - 1)
                throw new IndexOutOfRangeException("关卡不存在");

            return m_Levels[m_PlayLevelIndex];
        }
    }
    #endregion

    #region 方法

    //初始化
    public void Initialize()
    {
        //构建Level集合
        List<FileInfo> files = Tools.GetLevelFiles();
        List<Level> levels = new List<Level>();
        for (int i = 0; i < files.Count; i++)
        {
            Level level = new Level();
            Tools.FillLevel(files[i].FullName, ref level);
            levels.Add(level);
        }
        m_Levels = levels;

        //读取游戏进度
        m_GameProgress = Saver.GetProgress();
    }

    //游戏开始
    public void StartLevel(int levelIndex)
    {
        m_PlayLevelIndex = levelIndex;
        m_isPlaying = true;
    }

    //游戏结束
    public void StopLevel(bool isWin)
    {
        if (isWin && PlayLevelIndex > GameProgress)
        {
            Saver.SetProgress(PlayLevelIndex);
        }
        m_isPlaying = false;
    }

    //清档
    public void ClearProgress()
    {
        m_isPlaying = false;
        m_PlayLevelIndex = -1;
        m_GameProgress = -1;
        Saver.SetProgress(-1);
    }

    #endregion

    #region Unity回调
    #endregion

    #region 事件回调
    #endregion

    #region 帮助方法
    #endregion



    
}
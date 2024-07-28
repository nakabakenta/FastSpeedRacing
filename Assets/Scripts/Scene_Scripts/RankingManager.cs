using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankingManager : MonoBehaviour
{
    //Stageï ÅAintå^Record(ï™,ïb,É~Éäïb)
    public static int[,] minute  = new int[5, 10] { { 99, 99, 99, 99, 99, 99, 99, 99, 99, 99 },
                                                    { 99, 99, 99, 99, 99, 99, 99, 99, 99, 99 },
                                                    { 99, 99, 99, 99, 99, 99, 99, 99, 99, 99 },
                                                    { 99, 99, 99, 99, 99, 99, 99, 99, 99, 99 },
                                                    { 99, 99, 99, 99, 99, 99, 99, 99, 99, 99 } };
    public static int[,] second  = new int[5, 10] { { 59, 59, 59, 59, 59, 59, 59, 59, 59, 59 },
                                                    { 59, 59, 59, 59, 59, 59, 59, 59, 59, 59 },
                                                    { 59, 59, 59, 59, 59, 59, 59, 59, 59, 59 },
                                                    { 59, 59, 59, 59, 59, 59, 59, 59, 59, 59 },
                                                    { 59, 59, 59, 59, 59, 59, 59, 59, 59, 59 } };
    public static int[,] msecond = new int[5, 10] { { 99, 99, 99, 99, 99, 99, 99, 99, 99, 99 },
                                                    { 99, 99, 99, 99, 99, 99, 99, 99, 99, 99 },
                                                    { 99, 99, 99, 99, 99, 99, 99, 99, 99, 99 },
                                                    { 99, 99, 99, 99, 99, 99, 99, 99, 99, 99 },
                                                    { 99, 99, 99, 99, 99, 99, 99, 99, 99, 99 } };
    //Stageï ÅAstringå^Record(ï™,ïb,É~Éäïb)
    public static string[,] textMinute  = new string[5, 10];
    public static string[,] textSecond  = new string[5, 10];
    public static string[,] textMsecond = new string[5, 10];
    //RankingText
    public static string[]  textRanking = new string[10] { "1st : ", "2nd : ", "3rd : ", "4th : ",  "5th : ",
                                                           "6th : ", "7th : ", "8th : ", "9th : ", "10th : " };
    //RankingManagerInfo
    public RankingManagerInfo rankingManagerInfo;

    // Update is called once per frame
    void Update()
    {
        if (Stage.setRanking == true)
        {
            Ranking();
        }
    }
    void Ranking()
    {
        for (int i = 0; i < 10 && Stage.setRanking == true; i++)
        {
            if (Stage.minute < minute[GameManager.nowStage - 1, i])
            {
                if (i == 9)
                {
                    minute [GameManager.nowStage - 1, i] = Stage.minute;
                    second [GameManager.nowStage - 1, i] = Stage.second;
                    msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                    Stage.setRanking = false;
                }
                else if (i == 8)
                {
                    for (int j = 1; j > 0; j--)
                    {
                        minute [GameManager.nowStage - 1, i + j] = minute [GameManager.nowStage - 1, i + j - 1];
                        second [GameManager.nowStage - 1, i + j] = second [GameManager.nowStage - 1, i + j - 1];
                        msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                    }
                    minute [GameManager.nowStage - 1, i] = Stage.minute;
                    second [GameManager.nowStage - 1, i] = Stage.second;
                    msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                    Stage.setRanking = false;
                }
                else if (i == 7)
                {
                    for (int j = 2; j > 0; j--)
                    {
                        minute [GameManager.nowStage - 1, i + j] = minute [GameManager.nowStage - 1, i + j - 1];
                        second [GameManager.nowStage - 1, i + j] = second [GameManager.nowStage - 1, i + j - 1];
                        msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                    }
                    minute [GameManager.nowStage - 1, i] = Stage.minute;
                    second [GameManager.nowStage - 1, i] = Stage.second;
                    msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                    Stage.setRanking = false;
                }
                else if (i == 6)
                {
                    for (int j = 3; j > 0; j--)
                    {
                        minute [GameManager.nowStage - 1, i + j] = minute [GameManager.nowStage - 1, i + j - 1];
                        second [GameManager.nowStage - 1, i + j] = second [GameManager.nowStage - 1, i + j - 1];
                        msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                    }
                    minute [GameManager.nowStage - 1, i] = Stage.minute;
                    second [GameManager.nowStage - 1, i] = Stage.second;
                    msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                    Stage.setRanking = false;
                }
                else if (i == 5)
                {
                    for (int j = 4; j > 0; j--)
                    {
                        minute [GameManager.nowStage - 1, i + j] = minute [GameManager.nowStage - 1, i + j - 1];
                        second [GameManager.nowStage - 1, i + j] = second [GameManager.nowStage - 1, i + j - 1];
                        msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                    }
                    minute [GameManager.nowStage - 1, i] = Stage.minute;
                    second [GameManager.nowStage - 1, i] = Stage.second;
                    msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                    Stage.setRanking = false;
                }
                else if (i == 4)
                {
                    for (int j = 5; j > 0; j--)
                    {
                        minute [GameManager.nowStage - 1, i + j] = minute [GameManager.nowStage - 1, i + j - 1];
                        second [GameManager.nowStage - 1, i + j] = second [GameManager.nowStage - 1, i + j - 1];
                        msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                    }
                    minute [GameManager.nowStage - 1, i] = Stage.minute;
                    second [GameManager.nowStage - 1, i] = Stage.second;
                    msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                    Stage.setRanking = false;
                }
                else if (i == 3)
                {
                    for (int j = 6; j > 0; j--)
                    {
                        minute [GameManager.nowStage - 1, i + j] = minute [GameManager.nowStage - 1, i + j - 1];
                        second [GameManager.nowStage - 1, i + j] = second [GameManager.nowStage - 1, i + j - 1];
                        msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                    }
                    minute [GameManager.nowStage - 1, i] = Stage.minute;
                    second [GameManager.nowStage - 1, i] = Stage.second;
                    msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                    Stage.setRanking = false;
                }
                else if (i == 2)
                {
                    for (int j = 7; j > 0; j--)
                    {
                        minute [GameManager.nowStage - 1, i + j] = minute [GameManager.nowStage - 1, i + j - 1];
                        second [GameManager.nowStage - 1, i + j] = second [GameManager.nowStage - 1, i + j - 1];
                        msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                    }
                    minute [GameManager.nowStage - 1, i] = Stage.minute;
                    second [GameManager.nowStage - 1, i] = Stage.second;
                    msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                    Stage.setRanking = false;
                }
                else if (i == 1)
                {
                    for (int j = 8; j > 0; j--)
                    {
                        minute [GameManager.nowStage - 1, i + j] = minute [GameManager.nowStage - 1, i + j - 1];
                        second [GameManager.nowStage - 1, i + j] = second [GameManager.nowStage - 1, i + j - 1];
                        msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                    }
                    minute [GameManager.nowStage - 1, i] = Stage.minute;
                    second [GameManager.nowStage - 1, i] = Stage.second;
                    msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                    Stage.setRanking = false;
                }
                else if (i == 0)
                {
                    for (int j = 9; j > 0; j--)
                    {
                        minute [GameManager.nowStage - 1, i + j] = minute [GameManager.nowStage - 1, i + j - 1];
                        second [GameManager.nowStage - 1, i + j] = second [GameManager.nowStage - 1, i + j - 1];
                        msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                    }
                    minute [GameManager.nowStage - 1, i] = Stage.minute;
                    second [GameManager.nowStage - 1, i] = Stage.second;
                    msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                    Stage.setRanking = false;
                }
            }
            else if (Stage.minute == minute[GameManager.nowStage - 1, i])
            {
                if (Stage.second < second[GameManager.nowStage - 1, i])
                {
                    if (i == 9)
                    {
                        minute[GameManager.nowStage - 1, i] = Stage.minute;
                        second[GameManager.nowStage - 1, i] = Stage.second;
                        msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                        Stage.setRanking = false;
                    }
                    else if (i == 8)
                    {
                        for (int j = 1; j > 0; j--)
                        {
                            minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                            second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                            msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                        }
                        minute[GameManager.nowStage - 1, i] = Stage.minute;
                        second[GameManager.nowStage - 1, i] = Stage.second;
                        msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                        Stage.setRanking = false;
                    }
                    else if (i == 7)
                    {
                        for (int j = 2; j > 0; j--)
                        {
                            minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                            second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                            msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                        }
                        minute[GameManager.nowStage - 1, i] = Stage.minute;
                        second[GameManager.nowStage - 1, i] = Stage.second;
                        msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                        Stage.setRanking = false;
                    }
                    else if (i == 6)
                    {
                        for (int j = 3; j > 0; j--)
                        {
                            minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                            second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                            msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                        }
                        minute[GameManager.nowStage - 1, i] = Stage.minute;
                        second[GameManager.nowStage - 1, i] = Stage.second;
                        msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                        Stage.setRanking = false;
                    }
                    else if (i == 5)
                    {
                        for (int j = 4; j > 0; j--)
                        {
                            minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                            second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                            msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                        }
                        minute[GameManager.nowStage - 1, i] = Stage.minute;
                        second[GameManager.nowStage - 1, i] = Stage.second;
                        msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                        Stage.setRanking = false;
                    }
                    else if (i == 4)
                    {
                        for (int j = 5; j > 0; j--)
                        {
                            minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                            second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                            msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                        }
                        minute[GameManager.nowStage - 1, i] = Stage.minute;
                        second[GameManager.nowStage - 1, i] = Stage.second;
                        msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                        Stage.setRanking = false;
                    }
                    else if (i == 3)
                    {
                        for (int j = 6; j > 0; j--)
                        {
                            minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                            second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                            msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                        }
                        minute[GameManager.nowStage - 1, i] = Stage.minute;
                        second[GameManager.nowStage - 1, i] = Stage.second;
                        msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                        Stage.setRanking = false;
                    }
                    else if (i == 2)
                    {
                        for (int j = 7; j > 0; j--)
                        {
                            minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                            second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                            msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                        }
                        minute[GameManager.nowStage - 1, i] = Stage.minute;
                        second[GameManager.nowStage - 1, i] = Stage.second;
                        msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                        Stage.setRanking = false;
                    }
                    else if (i == 1)
                    {
                        for (int j = 8; j > 0; j--)
                        {
                            minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                            second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                            msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                        }
                        minute[GameManager.nowStage - 1, i] = Stage.minute;
                        second[GameManager.nowStage - 1, i] = Stage.second;
                        msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                        Stage.setRanking = false;
                    }
                    else if (i == 0)
                    {
                        for (int j = 9; j > 0; j--)
                        {
                            minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                            second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                            msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                        }
                        minute[GameManager.nowStage - 1, i] = Stage.minute;
                        second[GameManager.nowStage - 1, i] = Stage.second;
                        msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                        Stage.setRanking = false;
                    }
                }
                else if (Stage.second == second[GameManager.nowStage - 1, i])
                {
                    if (Stage.msecond < msecond[GameManager.nowStage - 1, i])
                    {
                        if (i == 9)
                        {
                            minute[GameManager.nowStage - 1, i] = Stage.minute;
                            second[GameManager.nowStage - 1, i] = Stage.second;
                            msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                            Stage.setRanking = false;
                        }
                        else if (i == 8)
                        {
                            for (int j = 1; j > 0; j--)
                            {
                                minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                                second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                                msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                            }
                            minute[GameManager.nowStage - 1, i] = Stage.minute;
                            second[GameManager.nowStage - 1, i] = Stage.second;
                            msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                            Stage.setRanking = false;
                        }
                        else if (i == 7)
                        {
                            for (int j = 2; j > 0; j--)
                            {
                                minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                                second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                                msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                            }
                            minute[GameManager.nowStage - 1, i] = Stage.minute;
                            second[GameManager.nowStage - 1, i] = Stage.second;
                            msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                            Stage.setRanking = false;
                        }
                        else if (i == 6)
                        {
                            for (int j = 3; j > 0; j--)
                            {
                                minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                                second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                                msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                            }
                            minute[GameManager.nowStage - 1, i] = Stage.minute;
                            second[GameManager.nowStage - 1, i] = Stage.second;
                            msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                            Stage.setRanking = false;
                        }
                        else if (i == 5)
                        {
                            for (int j = 4; j > 0; j--)
                            {
                                minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                                second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                                msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                            }
                            minute[GameManager.nowStage - 1, i] = Stage.minute;
                            second[GameManager.nowStage - 1, i] = Stage.second;
                            msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                            Stage.setRanking = false;
                        }
                        else if (i == 4)
                        {
                            for (int j = 5; j > 0; j--)
                            {
                                minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                                second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                                msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                            }
                            minute[GameManager.nowStage - 1, i] = Stage.minute;
                            second[GameManager.nowStage - 1, i] = Stage.second;
                            msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                            Stage.setRanking = false;
                        }
                        else if (i == 3)
                        {
                            for (int j = 6; j > 0; j--)
                            {
                                minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                                second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                                msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                            }
                            minute[GameManager.nowStage - 1, i] = Stage.minute;
                            second[GameManager.nowStage - 1, i] = Stage.second;
                            msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                            Stage.setRanking = false;
                        }
                        else if (i == 2)
                        {
                            for (int j = 7; j > 0; j--)
                            {
                                minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                                second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                                msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                            }
                            minute[GameManager.nowStage - 1, i] = Stage.minute;
                            second[GameManager.nowStage - 1, i] = Stage.second;
                            msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                            Stage.setRanking = false;
                        }
                        else if (i == 1)
                        {
                            for (int j = 8; j > 0; j--)
                            {
                                minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                                second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                                msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                            }
                            minute[GameManager.nowStage - 1, i] = Stage.minute;
                            second[GameManager.nowStage - 1, i] = Stage.second;
                            msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                            Stage.setRanking = false;
                        }
                        else if (i == 0)
                        {
                            for (int j = 9; j > 0; j--)
                            {
                                minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                                second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                                msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                            }
                            minute[GameManager.nowStage - 1, i] = Stage.minute;
                            second[GameManager.nowStage - 1, i] = Stage.second;
                            msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                            Stage.setRanking = false;
                        }
                    }
                    else if (Stage.msecond == msecond[GameManager.nowStage - 1, i])
                    {
                        if (i == 9)
                        {
                            minute[GameManager.nowStage - 1, i] = Stage.minute;
                            second[GameManager.nowStage - 1, i] = Stage.second;
                            msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                            Stage.setRanking = false;
                        }
                        else if (i == 8)
                        {
                            for (int j = 1; j > 0; j--)
                            {
                                minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                                second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                                msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                            }
                            minute[GameManager.nowStage - 1, i] = Stage.minute;
                            second[GameManager.nowStage - 1, i] = Stage.second;
                            msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                            Stage.setRanking = false;
                        }
                        else if (i == 7)
                        {
                            for (int j = 2; j > 0; j--)
                            {
                                minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                                second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                                msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                            }
                            minute[GameManager.nowStage - 1, i] = Stage.minute;
                            second[GameManager.nowStage - 1, i] = Stage.second;
                            msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                            Stage.setRanking = false;
                        }
                        else if (i == 6)
                        {
                            for (int j = 3; j > 0; j--)
                            {
                                minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                                second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                                msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                            }
                            minute[GameManager.nowStage - 1, i] = Stage.minute;
                            second[GameManager.nowStage - 1, i] = Stage.second;
                            msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                            Stage.setRanking = false;
                        }
                        else if (i == 5)
                        {
                            for (int j = 4; j > 0; j--)
                            {
                                minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                                second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                                msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                            }
                            minute[GameManager.nowStage - 1, i] = Stage.minute;
                            second[GameManager.nowStage - 1, i] = Stage.second;
                            msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                            Stage.setRanking = false;
                        }
                        else if (i == 4)
                        {
                            for (int j = 5; j > 0; j--)
                            {
                                minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                                second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                                msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                            }
                            minute[GameManager.nowStage - 1, i] = Stage.minute;
                            second[GameManager.nowStage - 1, i] = Stage.second;
                            msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                            Stage.setRanking = false;
                        }
                        else if (i == 3)
                        {
                            for (int j = 6; j > 0; j--)
                            {
                                minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                                second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                                msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                            }
                            minute[GameManager.nowStage - 1, i] = Stage.minute;
                            second[GameManager.nowStage - 1, i] = Stage.second;
                            msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                            Stage.setRanking = false;
                        }
                        else if (i == 2)
                        {
                            for (int j = 7; j > 0; j--)
                            {
                                minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                                second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                                msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                            }
                            minute[GameManager.nowStage - 1, i] = Stage.minute;
                            second[GameManager.nowStage - 1, i] = Stage.second;
                            msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                            Stage.setRanking = false;
                        }
                        else if (i == 1)
                        {
                            for (int j = 8; j > 0; j--)
                            {
                                minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                                second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                                msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                            }
                            minute[GameManager.nowStage - 1, i] = Stage.minute;
                            second[GameManager.nowStage - 1, i] = Stage.second;
                            msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                            Stage.setRanking = false;
                        }
                        else if (i == 0)
                        {
                            for (int j = 9; j > 0; j--)
                            {
                                minute[GameManager.nowStage - 1, i + j] = minute[GameManager.nowStage - 1, i + j - 1];
                                second[GameManager.nowStage - 1, i + j] = second[GameManager.nowStage - 1, i + j - 1];
                                msecond[GameManager.nowStage - 1, i + j] = msecond[GameManager.nowStage - 1, i + j - 1];
                            }
                            minute[GameManager.nowStage - 1, i] = Stage.minute;
                            second[GameManager.nowStage - 1, i] = Stage.second;
                            msecond[GameManager.nowStage - 1, i] = Stage.msecond;
                            Stage.setRanking = false;
                        }
                    }
                }
            }
        }

        for (int i = 0; i < 10; i++)
        {
            //ï™
            if (minute[GameManager.nowStage - 1, i] < 10)
            {
                textMinute[GameManager.nowStage - 1, i] = "0" + minute[GameManager.nowStage - 1, i].ToString();
            }
            else
            {
                textMinute[GameManager.nowStage - 1, i] = minute[GameManager.nowStage - 1, i].ToString();
            }
            //ïb
            if (second[GameManager.nowStage - 1, i] < 10)
            {
                textSecond[GameManager.nowStage - 1, i] = "0" + second[GameManager.nowStage - 1, i].ToString();
            }
            else
            {
                textSecond[GameManager.nowStage - 1, i] = second[GameManager.nowStage - 1, i].ToString();
            }
            //É~Éäïb
            if (msecond[GameManager.nowStage - 1, i] < 10)
            {
                textMsecond[GameManager.nowStage - 1, i] = "0" + msecond[GameManager.nowStage - 1, i].ToString();
            }
            else
            {
                textMsecond[GameManager.nowStage - 1, i] = msecond[GameManager.nowStage - 1, i].ToString();
            }
            rankingManagerInfo.textRanking[i].text = textRanking[i] + textMinute[GameManager.nowStage - 1, i] + "." + textSecond[GameManager.nowStage - 1, i] + "." + textMsecond[GameManager.nowStage - 1, i];
        }
    }
}
[System.Serializable]
public class RankingManagerInfo
{
    public TMP_Text[] textRanking = new TMP_Text[10];
}

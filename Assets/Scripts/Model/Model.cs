using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    public const int maxRows = 26;
    public const int maxColumns = 10;
    private int score = 0;

    public int Score { get { return score; } }
    private int bestScore = 0;
    public int BestScore { get { return bestScore; } }
    private int numbersGame = 0;
    public int NumbersGame { get { return numbersGame; } }


    private int isMute = 0;
    public int IsMute { get { return isMute; } }
    public bool isUpdateScore = false;



    private Transform[,] map = new Transform[maxColumns, maxRows];


    public void ClearHistory()
    {
        score = 0;
        bestScore = 0;
        numbersGame = 0;
        Save();
    }
    public void SetMute(int mute)
    {
        isMute = mute;
        Save();
    }
    private void Awake()
    {
        Load();
    }

    public void RestartGame()
    {
        for(int i = 0; i < maxRows; i++)
        {
            for(int j = 0; j < maxColumns; j++)
            {
                if (map[j, i] != null)
                {
                    Destroy(map[j, i].gameObject);
                    map[j, i] = null;
                }
            }
        }
        score = 0;

    }
    public bool IsGameOver()
    {
        for(int i = 23; i< maxRows; i++)
        {
            for(int j = 0; j < maxColumns; j++)
            {
                if (map[j, i] != null)
                {
                    numbersGame++;
                    Save();
                    return true;
                }
                   
            }
        }
        return false;
    }
    public void Load()
    {
        bestScore= PlayerPrefs.GetInt("bestScore", 0);
        numbersGame = PlayerPrefs.GetInt("numbersGame", 0);
        isMute= PlayerPrefs.GetInt("isMute", 0);
    }

    public void Save()
    {
        
        PlayerPrefs.SetInt("bestScore", bestScore);
        PlayerPrefs.SetInt("numbersGame", numbersGame);
        PlayerPrefs.SetInt("isMute", isMute);

    }
    public bool IsValidMapPosition(Transform t)
    {
        foreach(Transform child in t)
        {
            if (child.tag != "Block") continue;
            Vector2 pos = child.position.Round();
            if (IsInsiadeMap(pos) == false) return false;
            if (map[(int)pos.x,(int)pos.y] != null){
                return false;

            }
        }
        return true;
    }
    public bool PlaceShape(Transform t)
    {
        foreach(Transform child in t)
        {
            if (child.tag != "Block") continue;
            Vector2 pos = child.position.Round();
            map[(int)pos.x, (int)pos.y] = child;
        }

       return CheakMap();

    }
    public bool CheakMap()
    {
        int count = 0;
        for(int i = 0; i < 23; i++)
        {
            if (IsRowFall(i))
            {
                DeleteRow(i);
                MoveDownAll(i);
                i--;
                count++;
            }
        }
        if (count > 0)
        {
            isUpdateScore = true;
            score += count * 100;
            if (score > bestScore)
            {
                bestScore = score;
                Save();
            }
        }
        return count > 0;
    }
    public bool IsRowFall(int row)
    {
        for(int i = 0; i < maxColumns; i++)
        {
            if (map[i,row] == null)
                return false;
        }
        return true;
    }
    public void DeleteRow(int row)
    {
        for (int i = 0; i < maxColumns; i++)
        {
            Destroy(map[i, row].gameObject);
            map[i, row] = null;
        }
    }

    public void MoveDownAll(int row)
    {
        for(int i = row; i < 23; i++)
        {
            for(int j = 0; j < maxColumns; j++)
            {
                if (map[j, i] != null)
                {
                    map[j, i - 1] = map[j, i];
                    map[j, i] = null;
                    map[j, i - 1].position += new Vector3(0, -1, 0);
                }
            }
        }
    }

    public bool IsInsiadeMap(Vector2 pos)
    {
        return pos.x >= 0 && pos.y >= 0 && pos.x < maxColumns;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataProcesser : MonoBehaviour
{
    private SQLiteHelper sql;
    public static DataProcesser _instance;
    private readonly string dbPath = string.Format("Data Source={0}", Path.Combine(Environment.CurrentDirectory, "Assets\\Data\\wow.db"));
    private void Awake()
    {
        _instance = this;
        getUserData();
    }

    public void getUserData()
    {
        sql = new SQLiteHelper(dbPath);
        SqliteDataReader reader = sql.ReadFullTable("UserInfo");
        while (reader.Read())
        {
            PlayerInfo._instance.Coin = reader.GetInt32(reader.GetOrdinal("Coin"));
            PlayerInfo._instance.Name = reader.GetString(reader.GetOrdinal("userName"));
            PlayerInfo._instance.Mp = reader.GetInt32(reader.GetOrdinal("Mp"));
            PlayerInfo._instance.Hp = reader.GetInt32(reader.GetOrdinal("Hp"));
            PlayerInfo._instance.CurrentHp = reader.GetInt32(reader.GetOrdinal("CurrentHp"));
            PlayerInfo._instance.CurrentMp = reader.GetInt32(reader.GetOrdinal("CurrentMp"));
            PlayerInfo._instance.Exp = reader.GetInt32(reader.GetOrdinal("Exp"));
            PlayerInfo._instance.Level=reader.GetInt32(reader.GetOrdinal("level"));
            PlayerInfo._instance.HeadPortrait = reader.GetString(reader.GetOrdinal("HeadPortrait"));

        }
        sql.CloseConnection();
    }
}

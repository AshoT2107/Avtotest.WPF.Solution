using System.Collections.Generic;
using System.IO;
using Avtotest.WPF.Models;
using Newtonsoft.Json;

namespace Avtotest.WPF.Databases;

public class Database
{
    private const string UsersJsonPath = "JsonData/users.json";
    private const string QuestionsJsonPath = "JsonData/uzlotin.json";

    private static Database _database;
    public static Database Db
    {
        get
        {
            if (_database == null)
            {
                _database = new Database();
            }

            return _database;
        }
    }

    public Database()
    {
        QuestionsDb = new QuestionsDatabase(ReadQuestionsJson());
    }

    public QuestionsDatabase QuestionsDb;

    private List<QuestionEntity> ReadQuestionsJson()
    {
        if (!File.Exists(QuestionsJsonPath)) return new List<QuestionEntity>();
        var json = File.ReadAllText(QuestionsJsonPath);

        try
        {
            return JsonConvert.DeserializeObject<List<QuestionEntity>>(json)!;
        }
        catch
        {
            System.Console.WriteLine("Cannot deserialize questions json.");
            return new List<QuestionEntity>();
        }
    }
}
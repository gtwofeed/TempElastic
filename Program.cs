﻿using Nest;
using System;

namespace TempElastic
{
    internal class Program
    {
        public class Text
        {
            public int Id { get; set; }
            public string Mess { get; set; }
        }

        static void Main(string[] args)
        {

            var settings = new ConnectionSettings(new Uri("http://localhost:9200")).DefaultIndex("1");
            var client = new ElasticClient(settings);
            List<string> brotski = new List<string>()
            {
                "Не выходи из комнаты, не совершай ошибку",
                "Зачем тебе Солнце, если ты куришь Шипку?",
                "За дверью бессмысленно все, особенно – возглас счастья",
                "Только в уборную, и сразу же возвращайся",
                "Не выходи из комнаты, не вызывай мотора",
                "Потому что, пространство – сделано из коридора",
                "И кончается счетчиком, а если войдет живая",
                "Мелкая, пасть разевая, выгони не раздевая",
                "Не выходи из комнаты – считай, что тебя продуло",
                "Что интересней на свете кроме стены и стула?",
                "Зачем выходить оттуда, куда вернешься вечером?",
                "Таким же, каким ты был, тем более – изувеченным?",
                "Не выходи из комнаты, танцуй поймав боссанову",
                "В пальто на голое тело, в туфлях на босу ногу",
                "В прихожей пахнет капустой и мазью лыжной",
                "Ты написал много букв, и еще одна будет лишней",
                "Не выходи из комнаты – пускай, только комната",
                "Догадывается, как ты выглядишь – и вообще инкогнито",
                "Эрго сум, как заметила форме в сердцах субстанция",
                "Не выходи из комнаты – на улице чай, не Франция",
                "Не будь дураком – будь тем, чем другие не были",
                "Не выходи из комнаты, то есть дай волю мебели",
                "Слейся лицом с обоями, запрись и забаррикадируйся",
                "Шкафом от хроноса, космоса, эроса, расы, вируса",
                "Не выходи из комнаты, не совершай ошибку",
                "Зачем тебе Солнце, если ты куришь Шипку?",
                "За дверью бессмысленно все, особенно – возглас счастья",
                "Только в уборную, и сразу же возвращайся",
                "Не выходи из комнаты, не совершай ошибку",
                "Зачем тебе Солнце, если ты куришь Шипку?",
                "За дверью бессмысленно все, особенно – возглас счастья",
                "Только в уборную, и сразу же возвращайся"
            }; // набор строк
            for (int i = 1; i <= brotski.Count; i++)
            {
                var text = new Text()
                {
                    Id = i,
                    Mess = brotski[i-1]
                };
                var indexResponse = client.IndexDocument(text);
            }

            string query = "выходи";
            var SearchResponse = client.Search<Text>(s => s
            .Index("1")
            .From(0)
            .Size(20)
            .Query(q => q
            .Term(t => t.Mess, query)));
            List<Text> elasticData1 = SearchResponse.Documents.ToList<Text>();
            foreach (var item in elasticData1) Console.WriteLine(item);
            Console.WriteLine("END");
            Console.ReadLine();

            
        }
    }
}
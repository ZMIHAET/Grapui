using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GraphsTeory
{
    public class Graph
    {
        public Dictionary<string, Dictionary<string, double>> MainGraph = new Dictionary<string, Dictionary<string, double>>();
        public string type;
        public Graph() { }
        public Graph(string type) { this.type = type; }
        public Graph(Dictionary<string, Dictionary<string, double>> nodes)
        {
            MainGraph = nodes;
        }
        public Graph(string Path, string type)
        {
            using (StreamReader file = new StreamReader(Path))
            {
                try
                {
                    this.type = type;
                    if (type == "t1")
                    {
                        while (!file.EndOfStream)
                        {
                            string Point = file.ReadLine();
                            Dictionary<string, double> Vert = new Dictionary<string, double>();
                            string LinkString = file.ReadLine();
                            if (String.IsNullOrEmpty(LinkString))
                            {
                                MainGraph.Add(Point, Vert);
                            }
                            else
                            {
                                char[] c = { ' ' };
                                List<string> Points = LinkString.Split(c, StringSplitOptions.RemoveEmptyEntries).ToList();
                                for (int i = 0; i < Points.Count; i++)
                                {
                                    Vert.Add(Points[i], 1);
                                }
                                MainGraph.Add(Point, Vert);
                            }
                        }
                    }
                    if (type == "t2")
                    {
                        while (!file.EndOfStream)
                        {
                            string Point = file.ReadLine();
                            Dictionary<string, double> Vert = new Dictionary<string, double>();
                            string LinkString = file.ReadLine();
                            if (String.IsNullOrEmpty(LinkString))
                            {
                                MainGraph.Add(Point, Vert);
                            }
                            else
                            {
                                char[] c = { ' ' };
                                List<string> PointsAndWeights = LinkString.Split(c, StringSplitOptions.RemoveEmptyEntries).ToList();
                                for (int i = 0; i < PointsAndWeights.Count; i += 2)
                                {
                                    Vert.Add(PointsAndWeights[i], double.Parse(PointsAndWeights[i + 1]));
                                }
                                MainGraph.Add(Point, Vert);
                            }
                        }
                    }
                    if (type == "t3")
                    {
                        while (!file.EndOfStream)
                        {
                            string Point = file.ReadLine();
                            Dictionary<string, double> Vert = new Dictionary<string, double>();
                            string LinkString = file.ReadLine();
                            if (String.IsNullOrEmpty(LinkString))
                            {
                                MainGraph.Add(Point, Vert);
                            }
                            else
                            {
                                char[] c = { ' ' };
                                List<string> Points = LinkString.Split(c, StringSplitOptions.RemoveEmptyEntries).ToList();
                                for (int i = 0; i < Points.Count; i++)
                                {
                                    Vert.Add(Points[i], 1);
                                }
                                MainGraph.Add(Point, Vert);
                            }
                        }
                    }
                    if (type == "t4")
                    {
                        while (!file.EndOfStream)
                        {
                            string Point = file.ReadLine();
                            Dictionary<string, double> Vert = new Dictionary<string, double>();
                            string LinkString = file.ReadLine();
                            if (String.IsNullOrEmpty(LinkString))
                            {
                                MainGraph.Add(Point, Vert);
                            }
                            else
                            {
                                char[] c = { ' ' };
                                List<string> PointsAndWeights = LinkString.Split(c, StringSplitOptions.RemoveEmptyEntries).ToList();
                                for (int i = 0; i < PointsAndWeights.Count; i += 2)
                                {
                                    Vert.Add(PointsAndWeights[i], double.Parse(PointsAndWeights[i + 1]));
                                }
                                MainGraph.Add(Point, Vert);
                            }
                        }
                    }
                }
                catch { }
            }
            Console.WriteLine("Граф создан");
        }
        public Graph(Graph graph)
        {
            foreach (var Point in graph.MainGraph)
            {
                Dictionary<string, double> Vert = new Dictionary<string, double>();
                foreach (var Points in Point.Value)
                {
                    Vert.Add(Points.Key, Points.Value);
                }
                MainGraph.Add(Point.Key, Vert);
                this.type = graph.type;
            }

            Console.WriteLine("Копия создана");
        }

        public Dictionary<string, char> nov;
        public void NovSet()
        {
            nov = new Dictionary<string, char>();
            if (MainGraph != null)
            {
                foreach (var item in MainGraph)
                {
                    nov.Add(item.Key, 'w');
                }
            }
        }
        
        public void ShowMainGraph()
        {
            foreach (var Point in MainGraph)
            {
                Console.Write("{0}: ", Point.Key);
                foreach (var Points in Point.Value)
                {
                    if (Points.Value == 0)
                    {
                        Console.Write("{0}", Points.Key);
                    }
                    else
                    {
                        Console.Write("{0} ({1}) ", Points.Key, Points.Value);
                    }
                }
                Console.WriteLine();
            }
        }
        public void Add_Vertex(string Point)
        {
            Dictionary<string, double> Vert = new Dictionary<string, double>();
            if (MainGraph.ContainsKey(Point))
            {
                Console.WriteLine("Ошибка: Такая точка уже есть");
            }
            else
            {
                MainGraph.Add(Point, Vert);
                Console.WriteLine("Точка добавлена");
            }
        }
        public void AddWayFromVertexes(string Point1, string Point2)
        {
            if (this.type == "t1")
            {
                if (MainGraph.ContainsKey(Point1) && MainGraph.ContainsKey(Point2))
                {
                    MainGraph[Point1].Add(Point2, 1);
                    MainGraph[Point2].Add(Point1, 1);
                    Console.WriteLine("Ребро создано");
                }
                else
                {
                    Console.WriteLine("Ошибка:");
                    Console.WriteLine("обе вершины должны быть в графе");
                }
            }
            if (this.type == "t3")
            {
                if (MainGraph.ContainsKey(Point1) && MainGraph.ContainsKey(Point2))
                {
                    MainGraph[Point1].Add(Point2, 1);
                    Console.WriteLine("Ребро создано");
                }
                else
                {
                    Console.WriteLine("Ошибка:");
                    Console.WriteLine("обе вершины должны быть в графе");
                }
            }
        }
        public void AddWayFromVertexes(string Point1, string Point2, double Weight)
        {
            if (this.type == "t2")
            {
                if (MainGraph.ContainsKey(Point1) && MainGraph.ContainsKey(Point2))
                {
                    MainGraph[Point1].Add(Point2, Weight);
                    MainGraph[Point2].Add(Point1, Weight);
                    Console.WriteLine("Ребро создано");
                }
                else
                {
                    Console.WriteLine("Ошибка:");
                    Console.WriteLine("обе вершины должны быть в графе");
                }
            }
            if (this.type == "t4")
            {
                if (MainGraph.ContainsKey(Point1) && MainGraph.ContainsKey(Point2))
                {
                    MainGraph[Point1].Add(Point2, Weight);
                    Console.WriteLine("Ребро создано");
                }
                else
                {
                    Console.WriteLine("Ошибка:");
                    Console.WriteLine("обе вершины должны быть в графе");
                }
            }
        }
        public void Delete_Vertex(string Point)
        {
            Dictionary<string, double> Vert = new Dictionary<string, double>();
            if (!MainGraph.ContainsKey(Point))
            {
                Console.WriteLine("Ошибка: точка не существует");
            }
            else
            {
                MainGraph.Remove(Point);
                foreach (string Points in MainGraph.Keys)
                {
                    if (MainGraph[Points].ContainsKey(Point))
                    {
                        MainGraph[Points].Remove(Point);
                    }
                }
                Console.WriteLine("Точка удалена");
            }
        }
        public void DeleteWayFromVertexes(string Point1, string Point2)
        {
            if (this.type == "t1" || this.type == "t2")
            {
                if (MainGraph.ContainsKey(Point1) && MainGraph.ContainsKey(Point2) && MainGraph[Point1].ContainsKey(Point2) && MainGraph[Point2].ContainsKey(Point1))
                {
                    if (MainGraph[Point1].ContainsKey(Point2) && MainGraph[Point2].ContainsKey(Point1))
                    {
                        MainGraph[Point1].Remove(Point2);
                        MainGraph[Point2].Remove(Point1);
                        Console.WriteLine("Ребро удалено");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка:");
                    Console.WriteLine("обе вершины должны быть в графе или ребро не существует");
                }
            }
            if (this.type == "t3" || this.type == "t4")
            {
                if (MainGraph.ContainsKey(Point1) && MainGraph.ContainsKey(Point2) && (MainGraph[Point1].ContainsKey(Point2) || MainGraph[Point2].ContainsKey(Point1)))
                {
                    if (MainGraph[Point1].ContainsKey(Point2) && MainGraph[Point2].ContainsKey(Point1))
                    {
                        MainGraph[Point1].Remove(Point2);
                        MainGraph[Point2].Remove(Point1);
                        Console.WriteLine("Ребро удалено");
                    }
                    else if (!MainGraph[Point1].ContainsKey(Point2) && MainGraph[Point2].ContainsKey(Point1))
                    {
                        MainGraph[Point2].Remove(Point1);
                        Console.WriteLine("Ребро удалено");
                    }
                    else if (MainGraph[Point1].ContainsKey(Point2) && !MainGraph[Point2].ContainsKey(Point1))
                    {
                        MainGraph[Point1].Remove(Point2);
                        Console.WriteLine("Ребро удалено");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка:");
                    Console.WriteLine("обе вершины должны быть в графе или ребро не существует");
                }
            }
        }
        public void WrtiteToFile(string Path)
        {
            using (StreamWriter file = new StreamWriter(Path))
            {
                foreach (var Point in MainGraph)
                {
                    file.Write("{0}: ", Point.Key);
                    if (Point.Value.Count == 0)
                    {
                        file.Write("");
                    }
                    else
                    {
                        foreach (var Points in Point.Value)
                        {
                            file.Write("{0} ({1}) ", Points.Key, Points.Value);
                        }
                    }
                    file.WriteLine();
                }
            }
            Console.WriteLine("Записано");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////// TASKS ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        //////////////////////////////////////////////////////////// FindWay ////////////////////////////////////////////////////////////////////////
        public void FindWay(string Point1, string Point2)
        {
            if (MainGraph.ContainsKey(Point1) && MainGraph.ContainsKey(Point2))
                foreach (var Points in MainGraph[Point1])
                {
                    if (MainGraph[Points.Key].ContainsKey(Point2) && Points.Key != Point1 && Points.Key != Point2)
                    {
                        Console.WriteLine("Смежная вершина: {0}", Points.Key);
                        break;
                    }
                }
            else
            {
                Console.WriteLine("Ошибка:");
                Console.WriteLine("обе вершины должны быть в графе");
            }
        }

        //////////////////////////////////////////////////////////// HalfStep ////////////////////////////////////////////////////////////////////////
        public void ShowHalfStep(string Point)
        {
            if (!MainGraph.ContainsKey(Point))
            {
                Console.WriteLine("Ошибка: точка не существует");
            }
            else
            {
                Console.WriteLine("Полустепень вершины {0} равна: {1}", Point, MainGraph[Point].Count());
            }
        }

        //////////////////////////////////////////////////////////// Merge ////////////////////////////////////////////////////////////////////////
        public Graph Merge(Graph one)
        {
            Graph second = new Graph(this);
            foreach (string vertex in one.MainGraph.Keys)
            {
                if (!second.MainGraph.ContainsKey(vertex))
                    second.Add_Vertex(vertex);
            }
            foreach (string vertex in one.MainGraph.Keys)
            {
                foreach (var way in one.MainGraph[vertex])
                {
                    second.MainGraph[vertex][way.Key] = way.Value;
                }
            }
            return second;
        }

        //////////////////////////////////////////////////////////// DFS ////////////////////////////////////////////////////////////////////////
        void dfs(string name, ref Dictionary<string, bool> Used, ref Stack<string> order)
        {
            Used[name] = true;
            foreach (var key in MainGraph[name].Keys)
            {
                if (!Used[key])
                    dfs(key, ref Used, ref order);
            }
            order.Push(name);

        }
        void dfs_second(string name, ref Dictionary<string, bool> Used, Graph G)
        {
            Used[name] = true;
            foreach (var key in G.MainGraph[name].Keys)
            {
                if (!Used[key])
                {
                    dfs_second(key, ref Used, G);
                }
            }

        }
        public Graph Transpose_Graph()
        {
            Dictionary<string, Dictionary<string, double>> NewNodes = new Dictionary<string, Dictionary<string, double>>();
            foreach (string key in MainGraph.Keys)
            {
                Dictionary<string, double> D = new Dictionary<string, double>();
                NewNodes.Add(key, D);
            }
            foreach (string first in MainGraph.Keys)
            {
                foreach (string second in MainGraph[first].Keys)
                {
                    if (type == "t4")
                    {
                        NewNodes[second].Add(first, MainGraph[first][second]);
                    }
                    else
                    {
                        NewNodes[second].Add(first, 1);
                    }

                }

            }
            return new Graph(NewNodes);
        }
        public int CountComponents()
        {
            Dictionary<string, bool> Used = new Dictionary<string, bool>();
            Stack<string> Order = new Stack<string>();
            foreach (var key in MainGraph.Keys)
            {
                Used.Add(key, false);
            }
            foreach (var key in MainGraph.Keys)
            {
                if (!Used[key])
                {
                    dfs(key, ref Used, ref Order);
                }
            }
            Graph G = this.Transpose_Graph();
            int counter = 0;
            foreach (var key in MainGraph.Keys)
            {
                Used[key] = false;
            }
            while (Order.Count > 0)
            {
                string vertex = Order.Pop();
                if (!Used[vertex])
                {
                    counter++;
                    dfs_second(vertex, ref Used, G);
                }
            }
            return counter;
        }

        //////////////////////////////////////////////////////////// BFS ////////////////////////////////////////////////////////////////////////
        public void PrintVerticesWithMaxDistanceK(int k)
        {
            foreach (var startVertex in MainGraph.Keys)
            {
                // Словарь для отслеживания расстояния от начальной вершины
                Dictionary<string, int> distances = MainGraph.Keys.ToDictionary(v => v, v => -1);
                Queue<string> queue = new Queue<string>();

                // Инициализация начальной вершины
                distances[startVertex] = 0;
                queue.Enqueue(startVertex);

                while (queue.Count > 0)
                {
                    string currentVertex = queue.Dequeue();
                    foreach (var neighbor in MainGraph[currentVertex])
                    {
                        // Проверяем, не посетили ли мы вершину ранее и не превышено ли расстояние k
                        if (distances[neighbor.Key] == -1 && distances[currentVertex] < k)
                        {
                            distances[neighbor.Key] = distances[currentVertex] + 1;
                            queue.Enqueue(neighbor.Key);
                        }
                    }
                }

                // Вывод вершин с расстоянием не больше k от startVertex
                Console.Write($"Вершины, от которых до {startVertex} кратчайший путь не превосходит {k}: ");
                foreach (var vertex in distances.Where(d => d.Value != -1 && d.Value <= k))
                {
                    Console.Write($"{vertex.Key} ");
                }
                Console.WriteLine();
            }
        }

        //////////////////////////////////////////////////////////// Krascal ////////////////////////////////////////////////////////////////////////
        List<(double weight, string a, string b)> ways = new List<(double, string, string)>();
        public Graph Krascal()
        {
            foreach (var item in MainGraph)
            {
                foreach (var item2 in MainGraph[item.Key])
                {
                    if (!(ways.Contains((MainGraph[item.Key][item2.Key], item.Key, item2.Key)) || ways.Contains((MainGraph[item.Key][item2.Key], item2.Key, item.Key))))
                        ways.Add((MainGraph[item.Key][item2.Key], item.Key, item2.Key));
                }
            }
            ways.Sort();

            Graph crasc = new Graph(type);

            foreach (var item in MainGraph)
            {
                crasc.Add_Vertex(item.Key);
            }
            crasc.NovSet();

            foreach ((double weight, string a, string b) item in ways)
            {
                crasc.AddWayFromVertexes(item.a, item.b, item.weight);

                if (crasc.hasCycles(item.a, " "))
                {
                    crasc.DeleteWayFromVertexes(item.a, item.b);
                }
                crasc.NovSet();

            }
            return crasc;
        }

        public bool hasCycles(string s, string prev)
        {
            nov[s] = 'b';
            foreach (var item in MainGraph[s])
            {
                if (nov[item.Key] == 'w')
                {
                    hasCycles(item.Key, s);
                }
                else if (item.Key != prev)
                {
                    return true;
                }
            }
            return false;
        }

        //////////////////////////////////////////////////////////// Dijkstra ////////////////////////////////////////////////////////////////////////
        public void Dijkstra(string u)
        {
            if (!MainGraph.ContainsKey(u))
            {
                Console.WriteLine("Ошибка: точка не существует");
            }
            else
            {
                Dictionary<string, double> distance = new Dictionary<string, double>();
                Dictionary<string, bool> used = new Dictionary<string, bool>();
                Dictionary<string, string> pred = new Dictionary<string, string>();

                foreach (var item in MainGraph.Keys)
                {
                    distance.Add(item, int.MaxValue);
                    used.Add(item, false);
                    pred[item] = "no way";
                }
                distance[u] = 0;

                foreach (var count in MainGraph.Keys)
                {
                    string source = MinDistance(distance, used);
                    used[source] = true;

                    foreach (var item2 in MainGraph[source])
                    {
                        string v = item2.Key;
                        double weight = item2.Value;
                        if (!used[v] && distance[source] != int.MaxValue && distance[source] + weight < distance[v])
                        {
                            distance[v] = distance[source] + weight;
                            pred[v] = source;
                        }
                    }
                }
                Console.WriteLine("Кратчайший путь из вершины " + u + ":");
                foreach (var item in MainGraph.Keys)
                {
                    if (distance[item] == int.MaxValue)
                        Console.WriteLine("В вершину " + item + ": " + "Пути до этой вершины не существует");
                    else
                    {
                        Console.Write("в вершину " + item + ": ");
                        PrintPath(u, item, pred);
                    }
                    Console.WriteLine();
                }
            }
        }
        private string MinDistance(Dictionary<string, double> distance, Dictionary<string, bool> used)
        {
            double minDistance = int.MaxValue;
            string minIndex = "";
            foreach (var item in MainGraph.Keys)
            {
                if (!used[item] && distance[item] <= minDistance)
                {
                    minDistance = distance[item];
                    minIndex = item;
                }
            }
            return minIndex;
        }
        private void PrintPath(string source, string current, Dictionary<string, string> pred)
        {
            // рекурсивно выводим путь из исходной вершины в текущую вершину
            if (current == source)
            {
                Console.Write(source + " ");
            }
            else
            {
                PrintPath(source, pred[current], pred);
                Console.Write(current + " ");
            }
        }

        //////////////////////////////////////////////////////////// BellmanFord ////////////////////////////////////////////////////////////////////////
        public void BellmanFord(string u, string v1, string v2)
        {
            if (!MainGraph.ContainsKey(u) || !MainGraph.ContainsKey(v1) || !MainGraph.ContainsKey(v2))
            {
                Console.WriteLine("Ошибка: точка не существует");
            }
            else
            {
                Dictionary<string, double> distance = new Dictionary<string, double>();
                Dictionary<string, string> pred = new Dictionary<string, string>();
                foreach (var item in MainGraph.Keys)
                {
                    distance[item] = int.MaxValue;
                    pred[item] = null;
                }

                distance[u] = 0;

                for (int i = 0; i < MainGraph.Count - 1; i++)
                {
                    foreach (var item in MainGraph)
                    {
                        foreach (var item2 in item.Value)
                        {
                            if (distance[item.Key] + item2.Value < distance[item2.Key])
                            {
                                distance[item2.Key] = distance[item.Key] + item2.Value;
                                pred[item2.Key] = item.Key;
                            }
                        }
                    }
                }
                Console.WriteLine("Кратчайший путь от {0} до {1}: {2}", u, v1, GetPath(u, v1, pred));
                Console.WriteLine("Кратчайший путь от {0} до {1}: {2}", u, v2, GetPath(u, v2, pred));
            }
        }
        private string GetPath(string start, string end, Dictionary<string, string> pred)
        {
            if (!pred.ContainsKey(end) || pred[end] == null)
                return start == end ? start : "Путь не существует";

            return GetPath(start, pred[end], pred) + " " + end;
        }

        //////////////////////////////////////////////////////////// Floyd ////////////////////////////////////////////////////////////////////////
        public void Floyd(string u)
        {
            if (!MainGraph.ContainsKey(u))
            {
                Console.WriteLine("Ошибка: точка не существует");
            }
            else
            {
                Dictionary<(string, string), double> distance = new Dictionary<(string, string), double>();
                foreach (var item in MainGraph)
                {
                    foreach (var item2 in MainGraph)
                    {
                        if (item.Key == item2.Key)
                            distance[(item.Key, item2.Key)] = 0;
                        else
                            distance[(item.Key, item2.Key)] = MainGraph.ContainsKey(item.Key) && MainGraph[item.Key].ContainsKey(item2.Key) ? MainGraph[item.Key][item2.Key] : int.MaxValue;
                    }
                }

                foreach (var k in MainGraph)
                {
                    foreach (var item in MainGraph)
                    {
                        foreach (var item2 in MainGraph)
                        {
                            if (distance.ContainsKey((item.Key, k.Key)) && distance.ContainsKey((k.Key, item2.Key)) && (distance.ContainsKey((item.Key, item2.Key)) || item.Key == item2.Key)
                                && distance[(item.Key, k.Key)] != int.MaxValue && distance[(k.Key, item2.Key)] != int.MaxValue && distance[(item.Key, k.Key)] + distance[(k.Key, item2.Key)] < distance[(item.Key, item2.Key)])
                            {
                                distance[(item.Key, item2.Key)] = distance[(item.Key, k.Key)] + distance[(k.Key, item2.Key)];
                            }
                        }
                    }
                }

                foreach (var item in distance.Keys)
                {
                    string i = item.Item1;
                    string j = item.Item2;
                    if (distance[(i, j)] != int.MaxValue && distance[(j, j)] < 0 && distance[(j, i)] != int.MaxValue)
                    {
                        Console.WriteLine("В графе содержится отрицательный цикл");
                        return;
                    }
                }

                foreach (var item in MainGraph)
                {
                    if (distance.ContainsKey((u, item.Key)) && distance[(u, item.Key)] != int.MaxValue)
                        Console.WriteLine("Кратчайший путь из " + u + " в " + item.Key + ": " + distance[(u, item.Key)]);
                    else
                        Console.WriteLine("Пути из " + u + " в " + item.Key + " не существует");
                }
            }
        }
        //////////////////////////////////////////////////////////// Streams ////////////////////////////////////////////////////////////////////////

        public void FordFulkerson(string source, string sink, Graph MainGraphS)
        {
            if (!MainGraph.ContainsKey(sink) || !MainGraph.ContainsKey(source))
            {
                Console.WriteLine("Ошибка: одной из точек нет");
            }
            else
            {
                // Копия графа для остаточной сети
                Graph residualGraph = new Graph(MainGraphS);

                // Словарь для хранения родителей в пути
                Dictionary<string, string> parent = new Dictionary<string, string>();

                double maxFlow = 0;

                // Пока существует путь из источника в сток
                while (Bfs(residualGraph, source, sink, parent))
                {
                    double pathFlow = double.MaxValue;

                    // Находим минимальную пропускную способность в пути
                    string current = sink;
                    while (current != source)
                    {
                        string prev = parent[current];
                        pathFlow = Math.Min(pathFlow, residualGraph.MainGraph[prev][current]);
                        current = prev;
                    }

                    // Обновляем остаточную сеть и увеличиваем поток
                    current = sink;
                    while (current != source)
                    {
                        string prev = parent[current];
                        residualGraph.MainGraph[prev][current] -= pathFlow;
                        if (!residualGraph.MainGraph[current].ContainsKey(prev))
                            residualGraph.AddWayFromVertexes(current, prev, 0);
                        residualGraph.MainGraph[current][prev] += pathFlow;
                        current = prev;
                    }

                    maxFlow += pathFlow;
                }

                Console.WriteLine("Максимальный поток: {0}", maxFlow);
            }
        }

        private bool Bfs(Graph residualGraph, string source, string sink, Dictionary<string, string> parent)
        {
            List<string> visited = new List<string>();
            Queue<string> queue = new Queue<string>();

            queue.Enqueue(source);
            visited.Add(source);

            while (queue.Count > 0)
            {
                string u = queue.Dequeue();

                foreach (var v in residualGraph.MainGraph[u])
                {
                    if (!visited.Contains(v.Key) && v.Value > 0)
                    {
                        queue.Enqueue(v.Key);
                        visited.Add(v.Key);
                        parent[v.Key] = u;

                        if (v.Key == sink)
                            return true;
                    }
                }
            }

            return false;
        }
    }




    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// MAIN ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class Program
    {
        static void Main()
        {
            string type = ""; // поле для хранения типа графа
            string inway = "C:\\Users\\Кирилл Кашигин\\Desktop\\graph\\files\\t4.txt"; // поля для хранения путей к файлам
            string inway1 = "C:\\Users\\Кирилл Кашигин\\Desktop\\graph\\files\\merge.txt";
            string outway = "C:\\Users\\Кирилл Кашигин\\Desktop\\graph\\files\\vivod.txt";
            Console.WriteLine("Выберите тип графа");
            Console.WriteLine("Неориентированный невзвешенный граф: t1");
            Console.WriteLine("Неориентированный взвешенный граф: t2");
            Console.WriteLine("Ориентированный невзвешенный граф: t3");
            Console.WriteLine("Ориентированный взвешенный граф: t4");
            string key = Console.ReadLine();
            Graph MyGraph = new Graph(key); // основной граф
            Graph MyGraphCop = new Graph(key); // копия графа
            switch (key)
            {
                case "t1":
                    Console.WriteLine("Выход из программы: esc");
                    Console.WriteLine("Показать изначальный граф: 0");
                    Console.WriteLine("Показать копию графа: 1");
                    Console.WriteLine("Очистить граф: 2");
                    Console.WriteLine("Заполнить граф по файлу: 3");
                    Console.WriteLine("Записать граф в файл: 4");
                    Console.WriteLine("Добавить вершину: add vertex");
                    Console.WriteLine("Добавить ребро: add way");
                    Console.WriteLine("Удалить вершину: delete vertex");
                    Console.WriteLine("Удалить ребро: delete way");
                    Console.WriteLine("Объединить графы: merge");
                    Console.WriteLine("Вывести все вершины, длины кратчайших (по числу дуг) путей от которых до всех остальных не превосходят k: distance");
                    Console.WriteLine("Вывести кратчайшие пути из вершины u во все остальные вершины: dijkstra");
                    type = "t1";
                    while (true)
                    {
                        string key1 = Console.ReadLine();
                        if (key1 == "esc")
                        {
                            break;
                        }
                        else
                        {
                            switch (key1)
                            {
                                case "0":
                                    MyGraph.ShowMainGraph();
                                    break;
                                case "1":
                                    MyGraphCop.ShowMainGraph();
                                    break;
                                case "2":
                                    MyGraphCop = new Graph(type);
                                    break;
                                case "3":
                                    MyGraph = new Graph(inway, type);
                                    MyGraphCop = new Graph(MyGraph);
                                    break;
                                case "4":
                                    MyGraphCop.WrtiteToFile(outway);
                                    break;
                                case "add vertex":
                                    Console.WriteLine("Введите добавляемую вершину");
                                    MyGraphCop.Add_Vertex(Console.ReadLine());
                                    break;
                                case "add way":
                                    Console.WriteLine("Введите первую вершину");
                                    string FirstPointA = Console.ReadLine();
                                    Console.WriteLine("Введите вторую вершину");
                                    string SecondPointA = Console.ReadLine();
                                    MyGraphCop.AddWayFromVertexes(FirstPointA, SecondPointA);
                                    break;
                                case "delete vertex":
                                    Console.WriteLine("Введите удаляемую вершину");
                                    MyGraphCop.Delete_Vertex(Console.ReadLine());
                                    break;
                                case "delete way":
                                    Console.WriteLine("Введите первую вершину");
                                    string FirstPointD = Console.ReadLine();
                                    Console.WriteLine("Введите вторую вершину");
                                    string SecondPointD = Console.ReadLine();
                                    MyGraphCop.DeleteWayFromVertexes(FirstPointD, SecondPointD);
                                    break;
                                case "merge":
                                    Graph first = new Graph(inway1, type);
                                    Graph second = MyGraphCop.Merge(first);
                                    second.ShowMainGraph();
                                    break;
                                case "distance":
                                    Console.WriteLine("Введите расстояние k");
                                    int k = int.Parse(Console.ReadLine());
                                    MyGraphCop.PrintVerticesWithMaxDistanceK(k);
                                    break;
                                case "dijkstra":
                                    Console.WriteLine("Введите вершину");
                                    string u = Console.ReadLine();
                                    MyGraphCop.Dijkstra(u);
                                    break;
                                default:
                                    Console.WriteLine("Такой команды нет");
                                    break;
                            }
                        }
                    }
                    break;
                case "t2":
                    Console.WriteLine("Выход из программы: esc");
                    Console.WriteLine("Показать изначальный граф: 0");
                    Console.WriteLine("Показать копию графа: 1");
                    Console.WriteLine("Очистить граф: 2");
                    Console.WriteLine("Заполнить граф по файлу: 3");
                    Console.WriteLine("Записать граф в файл: 4");
                    Console.WriteLine("Добавить вершину: add vertex");
                    Console.WriteLine("Добавить ребро: add way");
                    Console.WriteLine("Удалить вершину: delete vertex");
                    Console.WriteLine("Удалить ребро: delete way");
                    Console.WriteLine("Объединить графы: merge");
                    Console.WriteLine("Алгоритм Краскала: krascal");
                    Console.WriteLine("Вывести кратчайшие пути из вершины u во все остальные вершины: dijkstra");
                    type = "t2";
                    while (true)
                    {
                        string key2 = Console.ReadLine();
                        if (key2 == "esc")
                        {
                            break;
                        }
                        else
                        {
                            switch (key2)
                            {
                                case "0":
                                    MyGraph.ShowMainGraph();
                                    break;
                                case "1":
                                    MyGraphCop.ShowMainGraph();
                                    break;
                                case "2":
                                    MyGraphCop = new Graph(type);
                                    break;
                                case "3":
                                    MyGraph = new Graph(inway, type);
                                    MyGraphCop = new Graph(MyGraph);
                                    break;
                                case "4":
                                    MyGraphCop.WrtiteToFile(outway);
                                    break;
                                case "add vertex":
                                    Console.WriteLine("Введите добавляемую вершину");
                                    MyGraphCop.Add_Vertex(Console.ReadLine());
                                    break;
                                case "add way":
                                    Console.WriteLine("Введите первую вершину");
                                    string FirstPointA = Console.ReadLine();
                                    Console.WriteLine("Введите вторую вершину");
                                    string SecondPointA = Console.ReadLine();
                                    Console.WriteLine("Введите длину пути");
                                    int Way = int.Parse(Console.ReadLine());
                                    MyGraphCop.AddWayFromVertexes(FirstPointA, SecondPointA, Way);
                                    break;
                                case "delete vertex":
                                    Console.WriteLine("Введите удаляемую вершину");
                                    MyGraphCop.Delete_Vertex(Console.ReadLine());
                                    break;
                                case "delete way":
                                    Console.WriteLine("Введите первую вершину");
                                    string FirstPointD = Console.ReadLine();
                                    Console.WriteLine("Введите вторую вершину");
                                    string SecondPointD = Console.ReadLine();
                                    MyGraphCop.DeleteWayFromVertexes(FirstPointD, SecondPointD);
                                    break;
                                case "merge":
                                    Graph first = new Graph(inway1, type);
                                    Graph second = MyGraphCop.Merge(first);
                                    second.ShowMainGraph();
                                    break;
                                case "krascal":
                                    Graph crasc = MyGraphCop.Krascal();
                                    crasc.ShowMainGraph();
                                    break;
                                case "dijkstra":
                                    Console.WriteLine("Введите вершину");
                                    string u = Console.ReadLine();
                                    MyGraphCop.Dijkstra(u);
                                    break;
                                default:
                                    Console.WriteLine("Такой команды нет");
                                    break;
                            }
                        }
                    }
                    break;
                case "t3":
                    Console.WriteLine("Выход из программы: esc");
                    Console.WriteLine("Показать изначальный граф: 0");
                    Console.WriteLine("Показать копию графа: 1");
                    Console.WriteLine("Очистить граф: 2");
                    Console.WriteLine("Заполнить граф по файлу: 3");
                    Console.WriteLine("Записать граф в файл: 4");
                    Console.WriteLine("Добавить вершину: add vertex");
                    Console.WriteLine("Добавить ребро: add way");
                    Console.WriteLine("Удалить вершину: delete vertex");
                    Console.WriteLine("Удалить ребро: delete way");
                    Console.WriteLine("Вывести полустепень вершины: show half-step");
                    Console.WriteLine("Определить, можно ли попасть из вершины u в вершину v через одну какую-либо вершину орграфа: find way");
                    Console.WriteLine("Подсчитать количество сильно связных компонент орграфа: count");
                    Console.WriteLine("Вывести кратчайшие пути из вершины u во все остальные вершины: dijkstra");
                    Console.WriteLine("Вывести кратчайшие пути из вершины u до v1 и v2: FB");
                    Console.WriteLine("Вывести длины кратчайших путей от u до всех остальных вершин: floyd");
                    type = "t3";
                    while (true)
                    {
                        string key3 = Console.ReadLine();
                        if (key3 == "esc")
                        {
                            break;
                        }
                        else
                        {
                            switch (key3)
                            {
                                case "0":
                                    MyGraph.ShowMainGraph();
                                    break;
                                case "1":
                                    MyGraphCop.ShowMainGraph();
                                    break;
                                case "2":
                                    MyGraphCop = new Graph(type);
                                    break;
                                case "3":
                                    MyGraph = new Graph(inway, type);
                                    MyGraphCop = new Graph(MyGraph);
                                    break;
                                case "4":
                                    MyGraphCop.WrtiteToFile(outway);
                                    break;
                                case "add vertex":
                                    Console.WriteLine("Введите добавляемую вершину");
                                    MyGraphCop.Add_Vertex(Console.ReadLine());
                                    break;
                                case "add way":
                                    Console.WriteLine("Введите первую вершину");
                                    string FirstPointA = Console.ReadLine();
                                    Console.WriteLine("Введите вторую вершину");
                                    string SecondPointA = Console.ReadLine();
                                    MyGraphCop.AddWayFromVertexes(FirstPointA, SecondPointA);
                                    break;
                                case "delete vertex":
                                    Console.WriteLine("Введите удаляемую вершину");
                                    MyGraphCop.Delete_Vertex(Console.ReadLine());
                                    break;
                                case "delete way":
                                    Console.WriteLine("Введите первую вершину");
                                    string FirstPointD = Console.ReadLine();
                                    Console.WriteLine("Введите вторую вершину");
                                    string SecondPointD = Console.ReadLine();
                                    MyGraphCop.DeleteWayFromVertexes(FirstPointD, SecondPointD);
                                    break;
                                case "show half-step":
                                    Console.WriteLine("Введите вершину");
                                    string PointD = Console.ReadLine();
                                    MyGraphCop.ShowHalfStep(PointD);
                                    break;
                                case "find way":
                                    Console.WriteLine("Введите первую вершину");
                                    string Point1 = Console.ReadLine();
                                    Console.WriteLine("Введите вторую вершину");
                                    string Point2 = Console.ReadLine();
                                    MyGraphCop.FindWay(Point1, Point2);
                                    break;
                                case "count":
                                    int k = MyGraphCop.CountComponents();
                                    Console.WriteLine(k);
                                    break;
                                case "dijkstra":
                                    Console.WriteLine("Введите вершину");
                                    string u = Console.ReadLine();
                                    MyGraphCop.Dijkstra(u);
                                    break;
                                case "FB":
                                    Console.WriteLine("Введите вершину u");
                                    string u1 = Console.ReadLine();
                                    Console.WriteLine("Введите вершины v1");
                                    string v1 = Console.ReadLine();
                                    Console.WriteLine("Введите вершины v2");
                                    string v2 = Console.ReadLine();
                                    MyGraphCop.BellmanFord(u1, v1, v2);
                                    break;
                                case "floyd":
                                    Console.WriteLine("Введите вершину u");
                                    string u2 = Console.ReadLine();
                                    MyGraphCop.Floyd(u2);
                                    break;
                                default:
                                    Console.WriteLine("Такой команды нет");
                                    break;
                            }
                        }
                    }
                    break;
                case "t4":
                    Console.WriteLine("Выход из программы: esc");
                    Console.WriteLine("Показать изначальный граф: 0");
                    Console.WriteLine("Показать копию графа: 1");
                    Console.WriteLine("Очистить граф: 2");
                    Console.WriteLine("Заполнить граф по файлу: 3");
                    Console.WriteLine("Записать граф в файл: 4");
                    Console.WriteLine("Добавить вершину: add vertex");
                    Console.WriteLine("Добавить ребро: add way");
                    Console.WriteLine("Удалить вершину: delete vertex");
                    Console.WriteLine("Удалить ребро: delete way");
                    Console.WriteLine("Вывести полустепень вершины: show half-step");
                    Console.WriteLine("Определить, можно ли попасть из вершины u в вершину v через одну какую-либо вершину орграфа: find way");
                    Console.WriteLine("Подсчитать количество сильно связных компонент орграфа: count");
                    Console.WriteLine("Вывести кратчайшие пути из вершины u во все остальные вершины: dijkstra");
                    Console.WriteLine("Вывести кратчайшие пути из вершины u до v1 и v2: FB");
                    Console.WriteLine("Вывести длины кратчайших путей от u до всех остальных вершин: floyd");
                    Console.WriteLine("Найти максимальный поток: streams");
                    type = "t4";
                    while (true)
                    {
                        string key4 = Console.ReadLine();
                        if (key4 == "esc")
                        {
                            break;
                        }
                        else
                        {
                            switch (key4)
                            {
                                case "0":
                                    MyGraph.ShowMainGraph();
                                    break;
                                case "1":
                                    MyGraphCop.ShowMainGraph();
                                    break;
                                case "2":
                                    MyGraphCop = new Graph(type);
                                    break;
                                case "3":
                                    MyGraph = new Graph(inway, type);
                                    MyGraphCop = new Graph(MyGraph);
                                    break;
                                case "4":
                                    MyGraphCop.WrtiteToFile(outway);
                                    break;
                                case "add vertex":
                                    Console.WriteLine("Введите добавляемую вершину");
                                    MyGraphCop.Add_Vertex(Console.ReadLine());
                                    break;
                                case "add way":
                                    Console.WriteLine("Введите первую вершину");
                                    string FirstPointA = Console.ReadLine();
                                    Console.WriteLine("Введите вторую вершину");
                                    string SecondPointA = Console.ReadLine();
                                    Console.WriteLine("Введите длину пути");
                                    int Way = int.Parse(Console.ReadLine());
                                    MyGraphCop.AddWayFromVertexes(FirstPointA, SecondPointA, Way);
                                    break;
                                case "delete vertex":
                                    Console.WriteLine("Введите удаляемую вершину");
                                    MyGraphCop.Delete_Vertex(Console.ReadLine());
                                    break;
                                case "delete way":
                                    Console.WriteLine("Введите первую вершину");
                                    string FirstPointD = Console.ReadLine();
                                    Console.WriteLine("Введите вторую вершину");
                                    string SecondPointD = Console.ReadLine();
                                    MyGraphCop.DeleteWayFromVertexes(FirstPointD, SecondPointD);
                                    break;
                                case "show half-step":
                                    Console.WriteLine("Введите вершину");
                                    string PointD = Console.ReadLine();
                                    MyGraphCop.ShowHalfStep(PointD);
                                    break;
                                case "find way":
                                    Console.WriteLine("Введите первую вершину");
                                    string Point1 = Console.ReadLine();
                                    Console.WriteLine("Введите вторую вершину");
                                    string Point2 = Console.ReadLine();
                                    MyGraphCop.FindWay(Point1, Point2);
                                    break;
                                case "count":
                                    int k = MyGraphCop.CountComponents();
                                    Console.WriteLine(k);
                                    break;
                                case "dijkstra":
                                    Console.WriteLine("Введите вершину");
                                    string u = Console.ReadLine();
                                    MyGraphCop.Dijkstra(u);
                                    break;
                                case "FB":
                                    Console.WriteLine("Введите вершину u");
                                    string u1 = Console.ReadLine();
                                    Console.WriteLine("Введите вершины v1");
                                    string v1 = Console.ReadLine();
                                    Console.WriteLine("Введите вершины v2");
                                    string v2 = Console.ReadLine();
                                    MyGraphCop.BellmanFord(u1, v1, v2);
                                    break;
                                case "floyd":
                                    Console.WriteLine("Введите вершину u");
                                    string u2 = Console.ReadLine();
                                    MyGraphCop.Floyd(u2);
                                    break;
                                case "streams":
                                    Console.WriteLine("Введите исток");
                                    string from = Console.ReadLine();
                                    Console.WriteLine("Введите сток");
                                    string to = Console.ReadLine();
                                    MyGraphCop.FordFulkerson(from, to, MyGraphCop);
                                    break;
                                default:
                                    Console.WriteLine("Такой команды нет");
                                    break;
                            }
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Неизвестная команда");
                    break;
            }
        }
    }
}
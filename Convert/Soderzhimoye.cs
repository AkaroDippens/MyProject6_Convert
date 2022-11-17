using Convert;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Serialization;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Convert
{
    internal class Soderzhimoye
    {
        public static void Nachalo()
        {
            Convert();
        }
        private static void Clavisha()
        {
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
            }
        }
        private static void Convert()
        {
            Shapes rectangle = new Shapes();
            rectangle.Name = "Прямоугольник";
            rectangle.Width = 45;
            rectangle.Height = 11;

            Shapes quadrate = new Shapes();
            quadrate.Name = "Квадрат";
            quadrate.Width = 15;
            quadrate.Height = 15;

            Shapes rectangle2 = new Shapes();
            rectangle2.Name = "Прямоугольник";
            rectangle2.Width = 13;
            rectangle2.Height = 17;

            List<Shapes> shapes = new List<Shapes>();
            shapes.Add(rectangle);
            shapes.Add(quadrate);
            shapes.Add(rectangle2);

            Console.WriteLine("Введите путь до файла, который хотите открыть(.txt/.json/.xml)\n" +
           "------------------------------------------------------------------");
            Console.SetCursorPosition(1, 2);
            string a = Console.ReadLine();
            string text = $"{rectangle.Name}\n{rectangle.Height}\n{rectangle.Width}\n" +
                $"{quadrate.Name}\n{quadrate.Height}\n{quadrate.Width}\n" +
                $"{rectangle2.Name}\n{rectangle2.Height}\n{rectangle2.Width}\n";

            if (a.Contains(".txt"))
            {
                string path = $"C:\\Users\\mirzo\\OneDrive\\Рабочий стол\\{a}";
                if (File.Exists(path))
                {
                    File.AppendAllText($"C:\\Users\\mirzo\\OneDrive\\Рабочий стол\\{a}", text);
                    Console.WriteLine(text);
                }
                else
                {
                    File.Create(path);
                }
                Console.Clear();
                Convert();
                Clavisha();
            }

            else if (a.Contains(".json"))
            {
                string jsonText = $"C:\\Users\\mirzo\\OneDrive\\Рабочий стол\\{a}";
                if (File.Exists(jsonText))
                {
                    string json = JsonConvert.SerializeObject(shapes);
                    File.WriteAllText($"C:\\Users\\mirzo\\OneDrive\\Рабочий стол\\{a}", json);
                    List<Shapes> itog = JsonConvert.DeserializeObject<List<Shapes>>(text);
                    File.WriteAllText($"C:\\Users\\mirzo\\OneDrive\\Рабочий стол\\{a}", text);
                    Console.WriteLine(itog);
                }
                else
                {
                    File.Create(jsonText);
                }
            }

            else if (a.Contains(".xml"))
            {
                string xmlText = $"C:\\Users\\mirzo\\OneDrive\\Рабочий стол\\{a}";
                if (File.Exists(xmlText))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(Shapes));
                    using (FileStream fs = new FileStream($"C:\\Users\\mirzo\\OneDrive\\Рабочий стол\\{a}", FileMode.OpenOrCreate))
                    {
                        xml.Serialize(fs, rectangle);
                        xml.Serialize(fs, quadrate);
                        xml.Serialize(fs, rectangle2);
                    }

                    Shapes shape;
                    XmlSerializer Dexml = new XmlSerializer(typeof(Shapes));
                    using (FileStream ds = new FileStream($"C:\\Users\\mirzo\\OneDrive\\Рабочий стол\\{a}", FileMode.Open))
                    {
                        shape = (Shapes)Dexml.Deserialize(ds);
                    }
                    File.WriteAllText($"C:\\Users\\mirzo\\OneDrive\\Рабочий стол\\{a}", text);
                    Console.WriteLine(text);
                }
                else
                {
                    File.Create(xmlText);   
                }
            }
        }
    }
}

    


           
        
    

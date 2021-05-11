using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Turtle_Command
{
    class Program
    {
        static int x = 0, y = 0;
        static string f = "";

        public static void turtleControl(bool isInput)
        {

            List<string> listOfCommand = new List<string>(new string[] { "PLACE", "MOVE", "LEFT", "RIGHT", "REPORT" });
            List<string> moveMents = new List<string>();

            if (!isInput)
            {
                var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "movements.csv");
                using (var reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        Console.WriteLine(line.Replace("\"",""));
                        moveMents.Add(line.Replace("\"", ""));
                    }
                }
            }
            else
            {
                while (true)
                {
                    var input = Console.ReadLine();
                    var splitInput = input.Split(" ");

                    if (!string.IsNullOrEmpty(input))
                    {

                        if (listOfCommand.Contains(splitInput[0].ToUpper()))
                        {
                            if (moveMents.Count == 0)
                            {
                                if (splitInput[0] == "PLACE")
                                {
                                    moveMents.Add(input);

                                }
                            }
                            else
                            {
                                moveMents.Add(input);
                            }

                            if (input.ToUpper() == "REPORT")
                            {
                                break;
                            }
                        }
                    }
                }
            }


            foreach (var item in moveMents)
            {
                var splitItem = item.Split(" ");
                if (splitItem[0].ToUpper() == "PLACE")
                {
                    var splitCoordinates = splitItem[1].Split(",");
                    if (splitCoordinates[2].ToUpper() == "NORTH" || splitCoordinates[2].ToUpper() == "EAST")
                    {
                        x += Convert.ToInt32(splitCoordinates[0]);
                        y += Convert.ToInt32(splitCoordinates[1]);
                    }
                    else
                    {
                        x -= Convert.ToInt32(splitCoordinates[0]);
                        y -= Convert.ToInt32(splitCoordinates[1]);
                    }

                    f = splitCoordinates[2];
                }

                if (splitItem[0].ToUpper() == "LEFT")
                {
                    if (f.ToUpper() == "NORTH" || f.ToUpper() == "SOUTH")
                    {
                        f = "WEST";
                    }
                    else if (f.ToUpper() == "EAST")
                    {
                        f = "NORTH";
                    }
                    else if (f.ToUpper() == "WEST")
                    {
                        f = "SOUTH";
                    }
                }
                else if (splitItem[0].ToUpper() == "RIGHT")
                {
                    if (f.ToUpper() == "NORTH" || f.ToUpper() == "SOUTH")
                    {
                        f = "EAST";
                    }
                    else if (f.ToUpper() == "EAST")
                    {
                        f = "SOUTH";
                    }
                    else if (f.ToUpper() == "WEST")
                    {
                        f = "NORTH";
                    }
                }


                if (splitItem[0].ToUpper() == "MOVE")
                {
                    if (f.ToUpper() == "NORTH")
                    {
                        y++;
                    }
                    else if (f.ToUpper() == "SOUTH")
                    {
                        y--;
                    }
                    else if (f.ToUpper() == "EAST")
                    {
                        x++;
                    }
                    else if (f.ToUpper() == "WEST")
                    {
                        x--;
                    }
                }
            }


            Console.WriteLine(String.Format("output: {0},{1},{2}", x, y, f.ToUpper()));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("0,0");
            Console.WriteLine("select input:\n[0]:from file\n[1]:standard input\n");
            var inputType = Console.ReadLine();
            var input = true;
            while (true)
            {
                if (inputType == "0" || inputType == "1")
                {
                    input = inputType == "0" ? false : true;
                    break;
                }
            }
            

            while (true)
            {
                turtleControl(input);
                if (!input)
                {
                    break;
                }
            }
            
        }
    }
}

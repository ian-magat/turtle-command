using System;
using System.Collections.Generic;

namespace Turtle_Command
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0, y = 0;
            string f= "";

            List<string> listOfCommand = new List<string>(new string[] { "PLACE", "MOVE", "LEFT","RIGHT","REPORT" });
            List<string> moveMents = new List<string>();

            Console.WriteLine("0,0");

            while (true)
            {
                var input = Console.ReadLine();
                var splitInput = input.Split(" ");
                if ((x >= 5 || y >= 5) || (x == 0 && y == 0))
                {
                    if (splitInput[0].ToUpper() == "PLACE")
                    {
                        x = 0;
                        y = 0;
                       
                    }

                }
                 if (!string.IsNullOrEmpty(input))
                {
                    
                    if (listOfCommand.Contains(splitInput[0].ToUpper()))
                    {
                        moveMents.Add(input);

                        if (input.ToUpper() == "REPORT")
                        {
                            break;
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
                        y += Convert.ToInt32(splitCoordinates[1]);
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


            Console.WriteLine("output: " + x + "," + y + "," + f);
        }
    }
}

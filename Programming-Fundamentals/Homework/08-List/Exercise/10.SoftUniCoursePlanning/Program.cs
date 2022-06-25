using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine().Split(", ").ToList();
            string command = Console.ReadLine();

            while (!command.Equals("course start"))
            {
                string[] tokens = command.Split(':');

                switch (tokens[0])
                {
                    case "Add":
                        if (!schedule.Contains(tokens[1]))
                            schedule.Add(tokens[1]);
                        break;
                    case "Insert":
                        if (!schedule.Contains(tokens[1]))
                            schedule.Insert(int.Parse(tokens[2]), tokens[1]);
                        break;
                    case "Remove":
                        if (!schedule.Contains(tokens[1]))
                            break;

                        int nextIndex = schedule.IndexOf(tokens[1]) + 1;
                        if (nextIndex < schedule.Count && schedule[nextIndex].EndsWith("Exercise"))
                            schedule.RemoveAt(nextIndex);
                        schedule.Remove(tokens[1]);
                        break;
                    case "Swap":
                        if (schedule.Contains(tokens[1]) && schedule.Contains(tokens[2]))
                        {
                            int index1 = schedule.IndexOf(tokens[1]);
                            int index2 = schedule.IndexOf(tokens[2]);

                            bool hasExercise1 = index1 + 1 < schedule.Count && schedule[index1 + 1].EndsWith("Exercise");
                            bool hasExercise2 = index2 + 1 < schedule.Count && schedule[index2 + 1].EndsWith("Exercise");

                            SwapElements(schedule, index1, index2);

                            if (hasExercise1 && hasExercise2)
                                SwapElements(schedule, index1 + 1, index2 + 1);
                            else if (hasExercise1)
                            {
                                string exercise = schedule[index1 + 1];
                                schedule.Remove(exercise);
                                if (index2 + 1 < schedule.Count)
                                    schedule.Insert(index2 + 1, exercise);
                                else
                                    schedule.Add(exercise);
                            }
                            else if (hasExercise2)
                            {
                                string exercise = schedule[index2 + 1];
                                schedule.Remove(exercise);
                                if (index1 + 1 < schedule.Count)
                                    schedule.Insert(index1 + 1, exercise);
                                else
                                    schedule.Add(exercise);
                            }
                        }
                        break;
                    case "Exercise":
                        if (!schedule.Contains(tokens[1]))
                        {
                            schedule.Add(tokens[1]);
                            schedule.Add(tokens[1] + "-Exercise");
                            break;
                        }

                        if (!schedule.Contains(tokens[1] + "-Exercise"))
                            schedule.Insert(schedule.IndexOf(tokens[1]) + 1, tokens[1] + "-Exercise");
                        break;
                }

                command = Console.ReadLine();
            }

            for (int i = 0; i < schedule.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{schedule[i]}");
            }
        }

        private static void SwapElements(IList<string> list, int index1, int index2) 
            => (list[index1], list[index2]) = (list[index2], list[index1]);
    }
}

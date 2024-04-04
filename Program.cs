using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        TaskList taskList = new TaskList();
        Dictionary<int, int> GroupNomreStudentCount = new Dictionary<int, int>();

        while (true)
        {
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Show All Tasks");
            Console.WriteLine("3. Show Next Task");
            Console.WriteLine("4. Complete Task");
            Console.WriteLine("5. Add Group");
            Console.WriteLine("6. Remove Group");
            Console.WriteLine("7. Show All Groups");
            Console.WriteLine("8. Exit");

            Console.WriteLine("Enter your choice:");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter new task:");
                    string newTask = Console.ReadLine();
                    taskList.AddTask(newTask);
                    break;
                case 2:
                    taskList.ShowAllTasks();
                    break;
                case 3:
                    taskList.ShowNextTask();
                    break;
                case 4:
                    taskList.CompleteTask();
                    break;
                case 5:
                    Console.WriteLine("Enter group number:");
                    int groupNumber = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter student count:");
                    int studentCount = Convert.ToInt32(Console.ReadLine());
                    GroupNomreStudentCount.Add(groupNumber, studentCount);
                    break;
                case 6:
                    Console.WriteLine("Enter group number to remove:");
                    int groupToRemove = Convert.ToInt32(Console.ReadLine());
                    GroupNomreStudentCount.Remove(groupToRemove);
                    break;
                case 7:
                    Console.WriteLine("All Groups:");
                    foreach (var group in GroupNomreStudentCount)
                    {
                        Console.WriteLine($"Group Number: {group.Key}, Student Count: {group.Value}");
                    }
                    break;
                case 8:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }
        }
    }
}

class TaskList
{
    private Queue<string> tasks = new Queue<string>();

    public void AddTask(string task)
    {
        tasks.Enqueue(task);
    }

    public void ShowAllTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks in the list.");
            return;
        }

        Console.WriteLine("All Tasks:");
        foreach (var task in tasks)
        {
            Console.WriteLine(task);
        }
    }

    public void ShowNextTask()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks in the list.");
            return;
        }

        Console.WriteLine($"Next Task: {tasks.Peek()}");
    }

    public void CompleteTask()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks in the list.");
            return;
        }

        string completedTask = tasks.Dequeue();
        Console.WriteLine($"Completed Task: {completedTask}");
    }
}

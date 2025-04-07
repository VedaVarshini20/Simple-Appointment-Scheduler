using System.Collections.Generic;
 
class Appointment
{
    public string Date { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
}
 
class AppointmentScheduler
{
    private List<Appointment> appointments = new List<Appointment>();
 
    public bool BookAppointment(string date, string start, string end)
    {
        foreach (var app in appointments)
        {
            if (app.Date == date &&
                !(String.Compare(end, app.StartTime) <= 0 || String.Compare(start, app.EndTime) >= 0))
            {
                return false; // Conflict
            }
        }
 
        appointments.Add(new Appointment { Date = date, StartTime = start, EndTime = end });
        return true;
    }
 
    public void ListAppointments()
    {
        Console.WriteLine("Appointments:");
        foreach (var app in appointments)
        {
            Console.WriteLine($"{app.Date}: {app.StartTime} - {app.EndTime}");
        }
    }
}
 
class Program
{
    static void Main()
    {
        var scheduler = new AppointmentScheduler();
 
        Console.WriteLine("Booking appointment on 2025-04-08 from 10:00 to 11:00");
        if (scheduler.BookAppointment("2025-04-08", "10:00", "11:00"))
        {
            Console.WriteLine("Appointment booked successfully.");
        }
        else
        {
            Console.WriteLine("Failed to book appointment (conflict or full).");
        }
 
        scheduler.ListAppointments();
    }
}
[07/04, 2:39 pm] MOTHUKURI CHANDANA SRI: using System;
using System.Collections.Generic;
 
class Task
{
    public string Description { get; set; }
    public string Priority { get; set; }
    public bool Completed { get; set; } = false;
}
 
class TaskManager
{
    private List<Task> tasks = new List<Task>();
 
    public void AddTask(string desc, string priority)
    {
        tasks.Add(new Task { Description = desc, Priority = priority });
    }
 
    public void ListTasks()
    {
        Console.WriteLine("Tasks:");
        int index = 1;
        foreach (var task in tasks)
        {
            string status = task.Completed ? "Done" : "Pending";
            Console.WriteLine($"{index++}. [{status}] {task.Priority} - {task.Description}");
        }
    }
 
    public void CompleteTask(int index)
    {
        if (index >= 0 && index < tasks.Count)
        {
            tasks[index].Completed = true;
        }
    }
 
    public void DeleteTask(int index)
    {
        if (index >= 0 && index < tasks.Count)
        {
            tasks.RemoveAt(index);
        }
    }
}
 
class Program
{
    static void Main()
    {
        var manager = new TaskManager();
 
        Console.WriteLine("Adding a high priority task.");
        manager.AddTask("Finish C# project", "High");
 
        manager.ListTasks();
 
        Console.WriteLine("Marking first task as completed.");
        manager.CompleteTask(0);
 
        manager.ListTasks();
    }
}

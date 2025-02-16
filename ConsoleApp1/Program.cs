using System;
using System.IO;

class Program
{
            // These are the Simple Questions.
        // Kadane’s Algorithm (Maximum Subarray Sum).
    static int MaxSubarraySum(int [] arr)
    {
        int max = arr[0], current = arr[0];
        for(int i=1; i<arr.Length; i++)
        {
            current = Math.Max(arr[i], current + arr[i]);
            max = Math.Max(max, current);
        }
        return max;
    }


    // Intersection and Union of Two Unsorted Arrays

    static void Intersection(int[] arr1, int[] arr2)
    {
        HashSet <int> set = new HashSet<int>(arr1);
        foreach (int num in arr2)
        {
            if(set.Contains(num))
            {
                Console.Write(num + " ");
                set.Remove(num);
            }
        }
    }
    static void Union(int[] arr1, int[] arr2)
    {
        HashSet<int> set = new HashSet<int>(arr1);
        foreach (int num in arr2) set.Add(num);
        foreach (int num in set) Console.Write(num + " ");
    }

    // 3. Sparse Matrix Multiplication
    static int[,] MultiplySparseMatrices(int[,] mat1, int[,] mat2)
    {
        int rows1 = mat1.GetLength(0);
        int cols1 = mat1.GetLength(1);
        int cols2 = mat2.GetLength(1);
        int[,] result = new int[rows1, cols2];

        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols2; j++)
            {
                for (int k = 0; k < cols1; k++)
                {
                    result[i, j] += mat1[i, k] * mat2[k, j];
                }
            }
        }
        return result;
    }

    // 4. First Missing Positive Integer
    static int FirstMissingPositive(int[] nums)
    {
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
            {
                int temp = nums[nums[i] - 1];
                nums[nums[i] - 1] = nums[i];
                nums[i] = temp;
            }
        }
        for (int i = 0; i < n; i++)
        {
            if (nums[i] != i + 1) return i + 1;
        }
        return n + 1;
    }

    // 5. Rotate 2D Matrix 90 Degrees Clockwise
    static void RotateMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int i = 0; i < n / 2; i++)
        {
            for (int j = i; j < n - i - 1; j++)
            {
                int temp = matrix[i, j];
                matrix[i, j] = matrix[n - j - 1, i];
                matrix[n - j - 1, i] = matrix[n - i - 1, n - j - 1];
                matrix[n - i - 1, n - j - 1] = matrix[j, n - i - 1];
                matrix[j, n - i - 1] = temp;
            }
        }
    }
            
            // Advance Questions (Inheritence)
        //1
    class TaskScheduler
{
    private PriorityQueue<Task, int> taskQueue = new PriorityQueue<Task, int>();

    public void AddTask(string name, int priority)
    {
        Task newTask = new Task(name);
        taskQueue.Enqueue(newTask, priority);
        Console.WriteLine($"Task '{name}' added with priority {priority}.");
    }

    public void ExecuteNextTask()
    {
        if (taskQueue.Count > 0)
        {
            Task nextTask = taskQueue.Dequeue();
            Console.WriteLine($"Executing task: {nextTask.Name}");
        }
        else
        {
            Console.WriteLine("No tasks to execute.");
        }
    }

    public void ShowTasks()
    {
        if (taskQueue.Count == 0)
        {
            Console.WriteLine("No tasks in the queue.");
            return;
        }

        Console.WriteLine("Tasks in the queue:");
        foreach (var (task, priority) in taskQueue.UnorderedItems)
        {
            Console.WriteLine($"Task: {task.Name}, Priority: {priority}");
        }
    }
}

class Task
{
    public string Name { get; }

    public Task(string name)
    {
        Name = name;
    }
}

class CentralBank {
    public virtual void InterestRate() {
        Console.WriteLine("Central Bank Interest Rate: 5%");
    }
}


//2
class NationalBank : CentralBank {
    public override void InterestRate() {
        Console.WriteLine("National Bank Interest Rate: 6%");
    }
}

class LocalBank : NationalBank {
    public override void InterestRate() {
        Console.WriteLine("Local Bank Interest Rate: 7%");
    }
}

class Vehicle {
    public virtual void Drive() {
        Console.WriteLine("Vehicle is driving");
    }
}

class ElectricCar : Vehicle {
    public override void Drive() {
        Console.WriteLine("Electric car is driving silently");
    }
}

class GasCar : Vehicle {
    public override void Drive() {
        Console.WriteLine("Gas car is driving with engine sound");
    }
}

class SelfDrivingCar : ElectricCar {
    public override void Drive() {
        Console.WriteLine("Self-driving car is navigating automatically");
    }
}

class HybridCar : GasCar {
    public override void Drive() {
        Console.WriteLine("Hybrid car is switching between electric and gas mode");
    }
}


//3
class Employee {
    public virtual void CalculateBonus() {
        Console.WriteLine("Employee bonus: 10%");
    }
}

class Manager : Employee {
    public override void CalculateBonus() {
        Console.WriteLine("Manager bonus: 20%");
    }
}

class Director : Employee {
    public override void CalculateBonus() {
        Console.WriteLine("Director bonus: 30%");
    }
}

    static void Main()

    
    {
        {
        string filePath = "mcq_answers.txt";
        string[] mcqAnswers = {
            "Q1: A",
            "Q2: B",
            "Q3: B",
            "Q4: C",
            "Q5: B",
            "Q6: B",
            "Q7: D",
            "Q8: 3",
            "Q9: 5",
            "Q10: 1"
        };

        try
        {
            File.WriteAllLines(filePath, mcqAnswers);
            Console.WriteLine("MCQ answers have been written to the file successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
        // 1. Kadane’s Algorithm
        int[] arr = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        Console.WriteLine("Max Subarray Sum: " + MaxSubarraySum(arr));

        // 2. Intersection and Union
        int[] arr1 = { 1, 2, 3, 4, 5 };
        int[] arr2 = { 3, 4, 5, 6, 7 };
        Console.Write("Intersection: ");
        Intersection(arr1, arr2);
        Console.WriteLine();
        Console.Write("Union: ");
        Union(arr1, arr2);
        Console.WriteLine();

        // 3. Sparse Matrix Multiplication
        int[,] mat1 = { { 1, 0, 0 }, { 0, 0, 2 } };
        int[,] mat2 = { { 0, 3 }, { 0, 0 }, { 4, 0 } };
        int[,] result = MultiplySparseMatrices(mat1, mat2);
        Console.WriteLine("Sparse Matrix Multiplication Result:");
        for (int i = 0; i < result.GetLength(0); i++)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
                Console.Write(result[i, j] + " ");
            }
            Console.WriteLine();
        }

        // 4. First Missing Positive Integer
        int[] nums = { 3, 4, -1, 1 };
        Console.WriteLine("First Missing Positive: " + FirstMissingPositive(nums));

        // 5. Rotate 2D Matrix 90 Degrees Clockwise
        int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        RotateMatrix(matrix);
        Console.WriteLine("Rotated Matrix:");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }

               // Advance Questions (Inheritence)
        

        // 1 
        CentralBank cb = new CentralBank();
        cb.InterestRate();
        
        NationalBank nb = new NationalBank();
        nb.InterestRate();
        
        LocalBank lb = new LocalBank();
        lb.InterestRate();

        //2

        Vehicle v = new Vehicle();
        v.Drive();
        
        ElectricCar ec = new ElectricCar();
        ec.Drive();
        
        GasCar gc = new GasCar();
        gc.Drive();
        
        SelfDrivingCar sdc = new SelfDrivingCar();
        sdc.Drive();
        
        HybridCar hc = new HybridCar();
        hc.Drive();


        //3
        Employee e = new Employee();
        e.CalculateBonus();
        
        Manager m = new Manager();
        m.CalculateBonus();
        
        Director d = new Director();
        d.CalculateBonus();
    
    }

}
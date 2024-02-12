public static class FileTaskRunner
{
    public static void RunAllTaskSets(string directory)
    {
        var files = Directory.GetFiles(directory);
        for (var i = 0; i < files.Length; i+=2)
        {
            RunTaskSet(
                testFile: files[i],
                answerFile: files[i + 1]);
        }

        Console.WriteLine("Solution is correct!");
    }

    public static void RunTaskSet(string testFile, string answerFile)
    {
        using var taskReader = File.OpenText(testFile);
        using var answerReader = File.OpenText(answerFile);

        var taskCount = Int32.Parse(taskReader.ReadLine());
        for (var i = 0; i < taskCount; i++)
        {
            var linesCount = Int32.Parse(taskReader.ReadLine());
            var task = new string[linesCount];
            for (var j = 0; j < linesCount; j++)
            {
                task[j] = taskReader.ReadLine();
            }

            var expectedAnswer = answerReader.ReadLine();
            var actualAnswer = "";

            try
            {
                actualAnswer = Solution.GetAnswer(task);
                if (actualAnswer != expectedAnswer)
                    throw new InvalidOperationException("Invalid solution");
            }
            catch
            {
                Console.WriteLine("Incorrect answer");
                Console.WriteLine();
                Console.WriteLine("Task:");
                foreach (var taskLine in task)
                {
                    Console.WriteLine(taskLine);
                }
                Console.WriteLine();
                Console.WriteLine("Actual answer:");
                Console.WriteLine(actualAnswer);
                Console.WriteLine("Expected answer:");
                Console.WriteLine(expectedAnswer);
                Console.WriteLine();
                Console.WriteLine($"Test file: {testFile}");
                Console.WriteLine();
                throw;
            }
        }
    }
}
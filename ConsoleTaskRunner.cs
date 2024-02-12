public static class ConsoleTaskRunner
{
    public static void RunTaskSet()
    {
        var taskReader = Console.In;

        var taskCount = Int32.Parse(taskReader.ReadLine());
        for (var i = 0; i < taskCount; i++)
        {
            var linesCount = Int32.Parse(taskReader.ReadLine());
            var task = new string[linesCount];
            for (var j = 0; j < linesCount; j++)
            {
                task[j] = taskReader.ReadLine();
            }

            var answer = Solution.GetAnswer(task);

            Console.WriteLine(answer);
        }
    }
}
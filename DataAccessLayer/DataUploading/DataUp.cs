using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using DataAccessLayer.Models; 
using DataAccessLayer.EF;

namespace DataAccessLayer.DataUploading 
{
    public class DataUp
    {
        private readonly CodeBattleDBContext _context; 

        public DataUp(CodeBattleDBContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task ImportTasksFromFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                throw new DirectoryNotFoundException($"Папка не найдена: {folderPath}");
            }

            await ImportTasks(folderPath);
            await ImportTestCases(folderPath);
            await ImportAnswerCases(folderPath);
        }

        private async System.Threading.Tasks.Task ImportTasks(string folderPath)
        {
            var taskFolders = Directory.GetDirectories(folderPath, "task*", SearchOption.TopDirectoryOnly);

            foreach (var taskFolder in taskFolders)
            {
                var taskMdFile = Path.Combine(taskFolder, "task.md");
                if (File.Exists(taskMdFile))
                {
                    string taskContent = await ReadFileToStringAsync(taskMdFile);
                    await AddTaskToDatabase(taskContent);
                }
            }
        }

        private async System.Threading.Tasks.Task ImportTestCases(string folderPath)
        {
            var testCasesPath = Path.Combine(folderPath, "tests");
            await ImportTextFilesToDatabase(testCasesPath, "TaskCases");
        }

        private async System.Threading.Tasks.Task ImportAnswerCases(string folderPath)
        {
            var answerCasesPath = Path.Combine(folderPath, "answers");
            await ImportTextFilesToDatabase(answerCasesPath, "AnswerCases");
        }

        private async System.Threading.Tasks.Task ImportTextFilesToDatabase(string folderPath, string tableName)
        {
            if (Directory.Exists(folderPath))
            {
                var files = Directory.GetFiles(folderPath, "*.txt");

                foreach (var file in files)
                {
                    string content = await ReadFileToStringAsync(file);
                    await AddContentToDatabase(tableName, content);
                }
            }
        }

        private async System.Threading.Tasks.Task AddTaskToDatabase(string taskContent)
        {
            var newTask = new Models.Task() // Замените TaskModel на вашу модель задачи
            {
                Value = taskContent
            };

            _context.Task.Add(newTask); // Замените Tasks на имя DbSet для задач
            await _context.SaveChangesAsync();
        }

        private async System.Threading.Tasks.Task AddContentToDatabase(string tableName, string content)
        {
       
            if (tableName == "TaskCases")
            {
                _context.TestCase.Add(new TestCase { Test = content });
            }
            else if (tableName == "AnswerCases")
            {
                _context.Solution.Add(new Solution { CaseSolution = content });
            }

            await _context.SaveChangesAsync();
        }

        private async Task<string> ReadFileToStringAsync(string filePath)
        {
            using (var reader = new StreamReader(filePath, Encoding.UTF8))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}

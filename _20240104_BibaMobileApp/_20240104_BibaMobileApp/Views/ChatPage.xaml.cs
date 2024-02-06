using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Reflection;
using _20240104_BibaMobileApp.Classes;

namespace _20240104_BibaMobileApp.Views
{
    public class Test
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        public ChatPage()
        {
            InitializeComponent();

            //CreateChatJsonFile();
           CreateJsonFile();
        }

        //create the json file method
        private void CreateJsonFile()
        {
            // Create a sample object to serialize to JSON
            var person = new Test
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 30
            };

            // Specify the file path where you want to save the JSON file
            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "_20240104_BibaMobileApp");
            string filePath = Path.Combine(directoryPath, "test.json");

            // Create the directory if it doesn't exist
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Serialize the object to JSON
            string jsonString = JsonSerializer.Serialize(person, new JsonSerializerOptions { WriteIndented = true });

            // Write the JSON string to a file
            File.WriteAllText(filePath, jsonString);

            Console.WriteLine($"JSON file created at: {filePath}");

            // Read the JSON file content
            string jsonStringRead = File.ReadAllText(filePath);

            // Deserialize the JSON into a Person object
            Test personRead = JsonSerializer.Deserialize<Test>(jsonStringRead);

            // Access and print the date
            if (person != null)
            {
                Console.WriteLine($"Name: {person.FirstName} {person.LastName}, Age: {person.Age}");
            }
            else
            {
                Console.WriteLine("Failed to deserialize the JSON file.");
            }
        } 

        private string GetQuestion()
        {
            /*string entryText = Question.Text;

            if (entryText == null && entryText == " ")
            {
                entryText = "This invalide question! Please rewrite your question.";
            }*/

            //for test
            Random random = new Random();
            int number = random.Next(0, 100);
            string entryText = $"this is test {number}";

            return entryText;
        }

        private string GenerateAnswer() 
        {
            string answer = "I apologize! I can not give the answer for your question right now!";

            return answer;
        }

        private Object AddObject(Object obj)
        {
            if (obj is QuestionStorage)
            {
                obj = new QuestionStorage
                {
                    Text = GetQuestion()
                };
            }
            else if (obj is AnswerStorage) 
            {
                obj = new AnswerStorage
                {
                    Text = GenerateAnswer()
                };
            }

            return obj;
        }

        private string CreateJsonFile(string fileName)
        {
            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "_20240104_BibaMobileApp");
            string filePath = Path.Combine(directoryPath, fileName);

            // Create the directory if it doesn't exist
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            return filePath;
        }

        private void WriteDataToJsonFile(string filePath, Object obj)
        {
            // Serialize the object to JSON
            string jsonString = JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });

            // Write the JSON string to a file
            File.WriteAllText(filePath, jsonString);

            Console.WriteLine($"JSON file created at: {filePath}");
        }

        private void ReadDataFromJsonFile(string filePath, Object obj)
        {
            // Read the JSON file content
            string jsonString = File.ReadAllText(filePath);

            // Deserialize the JSON into a Person object
            if (obj is QuestionStorage)
            {
                obj = JsonSerializer.Deserialize<QuestionStorage>(jsonString);
            }
            else if(obj is AnswerStorage)
            {
                obj = JsonSerializer.Deserialize<AnswerStorage>(jsonString);
            }

            // Access and print the date
            if (obj != null)
            {
                Console.WriteLine($"Data: {jsonString}");
            }
            else
            {
                Console.WriteLine("Failed to deserialize the JSON file.");
            }
        }

        private void CreateChatJsonFile()
        {
            string questionStorageFileName = "questionData.json";
            string answerStorageFileName = "answerData.json";

            string questionFilePath = CreateJsonFile(questionStorageFileName);
            string answerFilePath = CreateJsonFile(answerStorageFileName);

            string questionString = File.ReadAllText(questionFilePath);
            string answerString = File.ReadAllText(answerFilePath);

            // Deserialize the JSON into a list of Person objects
            List<QuestionStorage> questionList = JsonSerializer.Deserialize<List<QuestionStorage>>(questionString);
            List<AnswerStorage> answerList = JsonSerializer.Deserialize<List<AnswerStorage>>(answerString);

            QuestionStorage question = new QuestionStorage();
            question = (QuestionStorage)AddObject(question);

            AnswerStorage answer = new AnswerStorage();
            answer = (AnswerStorage)AddObject(answer);

            // Add the new person to the list
            questionList.Add(question);
            answerList.Add(answer);

            WriteDataToJsonFile(questionFilePath, question);
            WriteDataToJsonFile(answerFilePath, answer);

            ReadDataFromJsonFile(questionFilePath, question);
        }
        /*
         private void CreateJsonFile()
        {
            // Specify the file path where you want to save the JSON file
            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "_20240104_BibaMobileApp");
           
            string questionFilePath = Path.Combine(directoryPath, "questionData.json");
            string answerFilePath = Path.Combine(directoryPath, "answerData.json");

            // Read the existing JSON data from the file
            string jsonQuestionString = File.ReadAllText(questionFilePath);
            string jsonAnswerString = File.ReadAllText(answerFilePath);

            // Create the directory if it doesn't exist
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Deserialize the JSON into a list of Person objects
            List<QuestionsStorage> questionList = JsonSerializer.Deserialize<List<QuestionsStorage>>(jsonQuestionString);
            List<AnswerStorage> answerList = JsonSerializer.Deserialize<List<AnswerStorage>>(jsonAnswerString);

            // Create a sample object to serialize to JSON
            var question = new QuestionsStorage
            {
                Text = Question.Text
            };

            var answer = new AnswerStorage
            {
                Text = $"answer for: {Question.Text}"
            };

            // Add the new person to the list
            questionList.Add(question);
            answerList.Add(answer);

            // Serialize the object to JSON
            string jsonStringQuestion = JsonSerializer.Serialize(question, new JsonSerializerOptions { WriteIndented = true });
            string jsonStringAnswer = JsonSerializer.Serialize(answer, new JsonSerializerOptions { WriteIndented = true });

            // Write the JSON string to a file
            File.WriteAllText(questionFilePath, jsonStringQuestion);
            File.WriteAllText(answerFilePath, jsonStringAnswer);

            // Read the JSON file content
            string questionJsonStringRead = File.ReadAllText(questionFilePath);
            string answerJsonStringRead = File.ReadAllText(answerFilePath);

            // Deserialize the JSON into a Person object
            QuestionsStorage questionReader = JsonSerializer.Deserialize<QuestionsStorage>(questionJsonStringRead);
            AnswerStorage answerReader = JsonSerializer.Deserialize<AnswerStorage>(answerJsonStringRead);

            // Access and print the date
            if (questionReader != null)
            {
                foreach (var item in questionList)
                {
                    Console.WriteLine(item.Text);
                }
                Console.WriteLine($"Text: {questionReader.Text}");
            }
            else
            {
                Console.WriteLine("Failed to deserialize the JSON file.");
            }
        }

         */

        public void SendMessage(object sender, EventArgs e)
        {
            // Assuming you have an Entry named 'yourEntry' in your XAML
            string entryText = Question.Text;

            // Create a new Frame
            Frame newFrame = new Frame
            {
                Style = (Style)Application.Current.Resources["MessageFrame"]
            };

            if (entryText != null && entryText != " ")
            {

                // Create a new Label
                Label newLabel = new Label
                {
                    Text = entryText,
                    Style = (Style)Application.Current.Resources["AskedLabel"]
                };

                // Add the Label to the Frame
                newFrame.Content = newLabel;

                // Add the new Label to the StackLayout
                MessageBlock.Children.Add(newFrame);

                AnswerMessage(sender, e);
            }
            else
            {
                Label errorLable = new Label
                {
                    Text = "This invalide question! Please rewrite your question.",
                    Style = (Style)Application.Current.Resources["ErrorLabel"]
                };
                newFrame.BackgroundColor = Color.White;
                newFrame.Content = errorLable;

                MessageBlock.Children.Add(newFrame);
            }
        }

        private void AnswerMessage(object sender, EventArgs e)
        {
            Frame newFrame = new Frame
            {
                Style = (Style)Application.Current.Resources["MessageFrame"]
            };

            Label newLabel = new Label
            {
                Text = "I apologize! I can not give the answer for your question right now!",
                Style = (Style)Application.Current.Resources["AnsweredLabel"]
            };

            newFrame.Content = newLabel;

            MessageBlock.Children.Add(newFrame);
        }
    }
}
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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        #region ==ClassVariables==

        private string filePath;
        protected List<string> messages = new List<string>();

        #endregion

        #region ==PROPs==
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }


        #endregion
        public ChatPage()
        {
            InitializeComponent();
            TaskStructure();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            AddObjectToStorage();
        }

        private void CreateJsonFile()
        {
            // Specify the file path where you want to save the JSON file
            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "_20240104_BibaMobileApp");
            FilePath = Path.Combine(directoryPath, "test.json");
            // Create the directory if it doesn't exist
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

        }

        //create the json file method
        private void TaskStructure()
        {
            CreateJsonFile();

            ReadChatStorege();

            WriteChatHistory();
            
        }

        private void WriteChatHistory()
        {
            int counter = 0;
            foreach (string message in messages) 
            {
                if (counter%2 == 0)
                {
                    CreateMessageBlock("AnsweredLabel", message);
                }
                else
                {
                    CreateMessageBlock("AskedLabel", message);
                }
                counter++;
            }
        }

        private void ReadChatStorege() //what do if in file is more than one objects
        {
            // Read the JSON file content
            string jsonStringRead = File.ReadAllText(FilePath);


            // Deserialize the JSON into a Person object
            try
            {
                messages = JsonSerializer.Deserialize<List<string>>(jsonStringRead);
            }
            catch (Exception ex)
            {
                Console.WriteLine("===========================================================");
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                Console.WriteLine("===========================================================");
            }
        }

        private string GetQuestion()
        {
            string entryText = Question.Text;

            if (entryText == null && entryText == " ")
            {
                entryText = "This invalide question! Please rewrite your question.";
            }

            return entryText;
        }

        private string GenerateAnswer(string question)
        {
            string answer = "I apologize! I can not give the answer for your question right now!";

            return answer;
        }

        private void AddObjectToStorage()
        {
            // Serialize the object to JSON
            string jsonString = JsonSerializer.Serialize(messages, new JsonSerializerOptions { WriteIndented = true });

            // Write the JSON string to a file
            File.WriteAllText(FilePath, jsonString);
        }

        private void CreateMessageBlock(string labelStyle, string text)
        {
            // Create a new Frame
            Frame frame = new Frame
            {
                Style = (Style)Application.Current.Resources["MessageFrame"]
            };

            Label lable = new Label
            {
                Text = text,
                Style = (Style)Application.Current.Resources[labelStyle]
            };
            frame.Content = lable;

            MessageBlock.Children.Add(frame);
        }

        public void SendMessage(object sender, EventArgs e)
        {
            string entryText = GetQuestion();
            //Messages message = CreateObject(entryText);
            messages.Add(entryText);
            Console.WriteLine("===========================================================");
            Console.WriteLine($"Text: {entryText}");
            Console.WriteLine("===========================================================");

            if (entryText != null && entryText != " ")
            {
                CreateMessageBlock("AskedLabel", entryText);
                
                string answer = GenerateAnswer(entryText);
                messages.Add(answer);
                CreateMessageBlock("AnsweredLabel", answer);
            }
            else
            {
                string errorText = "This invalide question! Please rewrite your question.";
                CreateMessageBlock("ErrorLabel", errorText);
            }
        }        
    }
}
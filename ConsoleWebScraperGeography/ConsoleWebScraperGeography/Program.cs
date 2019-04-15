using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWebScraperGeography
{
    class Program
    {

        static void Main(string[] args)
        {
            string url = "https://mycourses.binghamton.edu/webapps/assessment/review/review.jsp?attempt_id=_3449906_1&course_id=_56807_1&content_id=_731659_1&return_content=1&step=";
            string saveFile = "D:\\GeographyPageDownloads\\Test2.txt";

            string[] fileText = File.ReadAllLines(saveFile);

            List<Question> questions = new List<Question>();

            int counter = 0;
            while (counter < fileText.Length) {
            

                string questionText;
                string correctText;
                List<string> incorrects = new List<string>();
                questionText = fileText[counter];
                counter++;
                correctText = fileText[counter].Substring(15);
                counter++;
                
                while (fileText[counter].Length > 3 && fileText[counter].Substring(0, 4).Equals("NOT ")){
                    if(!incorrects.Contains(fileText[counter].Substring(3)))
                        incorrects.Add(fileText[counter].Substring(3));
                   
                    counter++;
                        
                }
                counter++;
                
                Question qToAdd = new Question(questionText, incorrects, correctText);
                questions.Add(qToAdd);
            }
            questions.AddRange(LoadURL(url, questions));

            File.Delete(saveFile);
            
            foreach (Question q in questions) {
                q.printQuestions(saveFile);
            }

            
        }
        
        private static List<Question> LoadURL(string url, List<Question> curQuestions)
        {
            string path = "C:\\Users\\Public\\GeographyTest\\Test4.html";
            path = "D:\\GeographyPageDownloads\\Test5.html";
            string htmlString = File.ReadAllText(path);
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(htmlString);
            var questionListHTML = document.DocumentNode.Descendants("ul")
                .Where(node => node.GetAttributeValue("id", "")
                .Equals("content_listContainer"))
                .ToList()[0]
                .Descendants("li")
                .Where(node => node.GetAttributeValue("id", "")
                .Contains("contentListItem:"));
            //GO THROUGH EACH QUESTION AND PARSE CORRECT ANSWER
            List<Question> newQuestions = new List<Question>();
            foreach (var question in questionListHTML) {
                string correctText = question.Descendants("td")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("reviewTestSubCellForIconBig"))
                    .Last()
                    .Descendants("img")
                    .Last()
                    .GetAttributeValue("title", "default");

                bool correctBool = correctText.Equals("Correct") ? true : false;


                var choices = question.Descendants("div")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("vtbegenerated inlineVtbegenerated"));

                string questionText = choices.ToList()[0].Descendants("span").ToList()[0].InnerText.Replace("&quot;", "\"");

                string choice = choices.ToList()[1].Descendants("span").ToList()[0].InnerText;

                List<string> choiceStrings = new List<string>();

                for (int i = 2; i <= 6; i++) {
                    choiceStrings.Add(choices.ToList()[i].Descendants("span").ToList()[0].InnerText);
                }
                bool containsQuestion = false;
                foreach (Question q in curQuestions) {
                    if (q.question.Equals(questionText))
                    {
                        containsQuestion = true;
                        if (correctBool)
                        {
                            q.correctChoice = choice;
                            q.incorrect.Clear();
                        }
                        else {
                            if (!q.incorrect.Contains(choice)) 
                                q.incorrect.Add(choice);
                        }
                    }
                }
                if (!containsQuestion) {
                    Question newQuestion = new Question(questionText, choice, correctBool);
                    newQuestions.Add(newQuestion);
                }

                
            }
            Console.WriteLine();
            return newQuestions;
        }

       
    }
    class Question
    {

        public string question; 
        public List<string> incorrect;
        public string correctChoice;
        public bool written;
        public Question(string questionText, string chose, bool correct) {
            questionText = questionText.Trim();
            question = questionText;
            incorrect = new List<string>();
            correctChoice = "Unknown";
            written = false;
            chose = chose.Trim();
            if (correct)
            {
                correctChoice = chose;
            }
            else {
                incorrect.Add(chose);
            }
            

        }
        public Question(string questionText, List<string> incorrects, string correct) {
            questionText.Trim();
            question = questionText;
            List<string> trimmedInc = new List<string>();
            foreach (string s in incorrects) {trimmedInc.Add(s.Trim()); }
            incorrect = trimmedInc;
            correct = correct.Trim();
            correctChoice = correct;
            written = true;
            
        }
        public void printQuestions(string saveFileAddress) {

           // if (!written)
            {
                if (saveFileAddress == "")
                {
                    Console.WriteLine(question);
                    Console.WriteLine("Correct Choice: " + correctChoice);
                    foreach (string s in incorrect)
                    {
                        Console.WriteLine("NOT " + s);
                    }
                    Console.WriteLine();
                }
                else
                {
                    StreamWriter outFile = File.AppendText(saveFileAddress);
                    outFile.WriteLine(question);
                    outFile.WriteLine("Correct Choice: " + correctChoice);
                    foreach (string s in incorrect)
                    {
                        outFile.WriteLine("NOT " + s);
                    }
                    outFile.WriteLine();
                    outFile.Close();
                }
            }
            
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Diagnostics;

namespace GeographyWebScraper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generateFileClick(object sender, EventArgs e)
        {
            //GENERATES THE SAVEFILE WITH UPDATED ANSWERS FROM THE LAST TAKEN QUIZ


            string saveFile = "D:\\GeographyPageDownloads\\" + this.saveFileBox.Text;
            readFile(saveFile);

            //Reads in the new html file to parse and adds each question it finds if it is not a duplicate
            //Rewrites the savefile with the new questions
            questions.AddRange(LoadURL(questions));
            File.Delete(saveFile);
            foreach (Question q in questions)
            {
                q.printQuestions(saveFile);
            }
            numQuestions.Text = questions.Count.ToString();
        }


        private void loadQuiz_Click(object sender, EventArgs e) {
            //Attempts to find the answers to the current quiz by scanning through the savefile

            Label[] answerLabels = { Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9, Q10 }; //Labels to display answers

            string saveFile = "D:\\GeographyPageDownloads\\" + this.saveFileBox.Text;

            readFile(saveFile);

            curQuestions = new List<Question>();
            string path = "D:\\GeographyPageDownloads\\" + this.InputHtmlBox.Text + ".html";

            List<string> lookingFor = new List<string>();

            //Parses the current quiz html to find the questions to look for
            if (!File.Exists(path)) { return; }
            string htmlString = File.ReadAllText(path);
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(htmlString);
            var questionListHTML = document.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("id", "")
                .Equals("dataCollectionContainer"))
                .ToList()[0]
                .Descendants("div")
                .Where(node => node.GetAttributeValue("id", "")
                .Contains("stepcontent"));
            Console.WriteLine();

            foreach (var question in questionListHTML) {
                string temp = question
                    .Descendants("div")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("vtbegenerated inlineVtbegenerated"))
                    .ToList()[0]
                    .InnerText;
                lookingFor.Add(temp);
                Console.WriteLine();


            }

            //Checks to see if there is a saved answer for each question in the current quiz
            for (int i = 0; i < 10; i++) {
                bool foundAnswer = false;
                Debug.WriteLine(lookingFor[i]);
                Debug.WriteLine("");
                lookingFor[i] = lookingFor[i].Replace("&quot;", "\"");
                foreach (Question q in questions) {
                    Debug.WriteLine(q.question);
                    if (lookingFor[i].Contains(q.question)) {
                        curQuestions.Add(q);
                        foundAnswer = true;
                        answerLabels[i].Text = (i + 1) + ": " + q.correctChoice;
                        break;
                    }
                }
                if (foundAnswer == false)
                {
                    curQuestions.Add(null);
                    answerLabels[i].Text = (i + 1) + ": No question data";
                }
            }

            numQuestions.Text = questions.Count.ToString();
        }

        void readFile(string saveFile) {

            //Reads the savefile into the current question list
            string[] fileText;

            //Clear existing question list
            questions = new List<Question>();

            //If there is an existing Save File, read in the questions already contained in it so they are not overwritten
            if (File.Exists(saveFile))
            {
                fileText = File.ReadAllLines(saveFile);

                int counter = 0;
                while (counter < fileText.Length)
                {
                    string questionText;
                    string correctText;
                    List<string> incorrects = new List<string>();

                    //Reads in the question and the correct answer
                    questionText = fileText[counter];
                    counter++;
                    correctText = fileText[counter].Substring(15);
                    counter++;

                    //Reads in each choice known to be incorrect
                    while (fileText[counter].Length > 3 && fileText[counter].Substring(0, 4).Equals("NOT "))
                    {
                        if (!incorrects.Contains(fileText[counter].Substring(3)))
                            incorrects.Add(fileText[counter].Substring(3));

                        counter++;

                    }
                    counter++;

                    //Store the question in main question list
                    Question qToAdd = new Question(questionText, incorrects, correctText);
                    questions.Add(qToAdd);
                }

            }
        }
        

        private List<Question> LoadURL(List<Question> curQuestions)
        {
            //Loads the html of the latest saved test and stores the answers into the current list of questions if there are new ones
            

            //Parses the html to find the list of answers
            string path = "D:\\GeographyPageDownloads\\" + this.InputHtmlBox.Text+ ".html";
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
            foreach (var question in questionListHTML)
            {
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

                for (int i = 2; i <= 6; i++)
                {
                    choiceStrings.Add(choices.ToList()[i].Descendants("span").ToList()[0].InnerText);
                }
                bool containsQuestion = false;
                foreach (Question q in curQuestions)
                {
                    if (q.question.Equals(questionText))
                    {
                        containsQuestion = true;
                        if (correctBool)
                        {
                            q.correctChoice = choice;
                            q.incorrect.Clear();
                        }
                        else
                        {
                            if (!q.incorrect.Contains(choice))
                                q.incorrect.Add(choice);
                        }
                    }
                }
                if (!containsQuestion)
                {
                    Question newQuestion = new Question(questionText, choice, correctBool);
                    newQuestions.Add(newQuestion);
                }


            }

            //Stores the html of the current quiz into a different folder to avoid clutter
            Console.WriteLine();
            int counter = 0;
            while (File.Exists("D:\\GeographyPageDownloads\\OldTests\\" + this.InputHtmlBox.Text + counter + ".html")){
                counter++;
            }
            File.Move(path, "D:\\GeographyPageDownloads\\OldTests\\" + this.InputHtmlBox.Text + counter + ".html");
            return newQuestions;
        }

        #region
        private void Q10_Click(object sender, EventArgs e)
        {
            if (curQuestions[9] == null) { return; }
            QuestionLabel.Text = curQuestions[9].question;
            
            Label[] answerLabels = { IQ1, IQ2, IQ3, IQ4, IQ5 };
            Label[] labels = { Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9, Q10 };
            for (int i = 0; i < labels.Length; i++) {
                if (i == 9)
                {
                    labels[i].ForeColor = Color.Blue;
                }
                else {
                    labels[i].ForeColor = Color.Black;
                }
            }
            for (int i = 0; i < curQuestions[9].incorrect.Count; i++)
            {
                answerLabels[i].Text = "NOT " + curQuestions[9].incorrect[i];
            }
        }
        private void Q9_Click(object sender, EventArgs e)
        {

            if (curQuestions[8] == null) { return; }
            QuestionLabel.Text = curQuestions[8].question;
            Label[] answerLabels = { IQ1, IQ2, IQ3, IQ4, IQ5 };
            Label[] labels = { Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9, Q10 };
            for (int i = 0; i < labels.Length; i++)
            {
                if (i == 8)
                {
                    labels[i].ForeColor = Color.Blue;
                }
                else
                {
                    labels[i].ForeColor = Color.Black;
                }
            }
            for (int i = 0; i < curQuestions[8].incorrect.Count; i++)
            {
                answerLabels[i].Text = "NOT " + curQuestions[8].incorrect[i];
            }
        }
        private void Q8_Click(object sender, EventArgs e)
        {
            
            
            if (curQuestions[7] == null) { return; }
            QuestionLabel.Text = curQuestions[7].question;
            Label[] answerLabels = { IQ1, IQ2, IQ3, IQ4, IQ5 };
            Label[] labels = { Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9, Q10 };
            for (int i = 0; i < labels.Length; i++)
            {
                if (i == 7)
                {
                    labels[i].ForeColor = Color.Blue;
                }
                else
                {
                    labels[i].ForeColor = Color.Black;
                }
            }
            for (int i = 0; i < curQuestions[7].incorrect.Count; i++)
            {
                answerLabels[i].Text = "NOT " + curQuestions[7].incorrect[i];
            }
        }
        private void Q7_Click(object sender, EventArgs e)
        {

            if (curQuestions[6] == null) { return; }
            QuestionLabel.Text = curQuestions[6].question;
            Label[] answerLabels = { IQ1, IQ2, IQ3, IQ4, IQ5 };
            Label[] labels = { Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9, Q10 };
            for (int i = 0; i < labels.Length; i++)
            {
                if (i == 6)
                {
                    labels[i].ForeColor = Color.Blue;
                }
                else
                {
                    labels[i].ForeColor = Color.Black;
                }
            }
            for (int i = 0; i < curQuestions[6].incorrect.Count; i++)
            {
                answerLabels[i].Text = "NOT " + curQuestions[6].incorrect[i];
            }
        }
        private void Q6_Click(object sender, EventArgs e)
        {
            if (curQuestions[5] == null) { return; }
            QuestionLabel.Text = curQuestions[5].question;
            Label[] answerLabels = { IQ1, IQ2, IQ3, IQ4, IQ5 };
            Label[] labels = { Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9, Q10 };
            for (int i = 0; i < labels.Length; i++)
            {
                if (i == 5)
                {
                    labels[i].ForeColor = Color.Blue;
                }
                else
                {
                    labels[i].ForeColor = Color.Black;
                }
            }
            for (int i = 0; i < curQuestions[5].incorrect.Count; i++)
            {
                answerLabels[i].Text = "NOT " + curQuestions[5].incorrect[i];
            }
        }
        private void Q5_Click(object sender, EventArgs e)
        {
            if (curQuestions[4] == null) { return; }
            QuestionLabel.Text = curQuestions[4].question;
            Label[] answerLabels = { IQ1, IQ2, IQ3, IQ4, IQ5 };
            Label[] labels = { Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9, Q10 };
            for (int i = 0; i < labels.Length; i++)
            {
                if (i == 4)
                {
                    labels[i].ForeColor = Color.Blue;
                }
                else
                {
                    labels[i].ForeColor = Color.Black;
                }
            }
            for (int i = 0; i < curQuestions[4].incorrect.Count; i++)
            {
                answerLabels[i].Text = "NOT " + curQuestions[4].incorrect[i];
            }
        }
        private void Q4_Click(object sender, EventArgs e)
        {
            if(curQuestions[3] == null) { return; }
            QuestionLabel.Text = curQuestions[3].question;
            Label[] answerLabels = { IQ1, IQ2, IQ3, IQ4, IQ5 };
            Label[] labels = { Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9, Q10 };
            for (int i = 0; i < labels.Length; i++)
            {
                if (i ==3)
                {
                    labels[i].ForeColor = Color.Blue;
                }
                else
                {
                    labels[i].ForeColor = Color.Black;
                }
            }
            for (int i = 0; i < curQuestions[3].incorrect.Count; i++)
            {
                answerLabels[i].Text = "NOT " + curQuestions[3].incorrect[i];
            }
        }
        private void Q3_Click(object sender, EventArgs e)
        {
            if (curQuestions[2] == null) { return; }
            QuestionLabel.Text = curQuestions[2].question;
            Label[] answerLabels = { IQ1, IQ2, IQ3, IQ4, IQ5 };
            Label[] labels = { Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9, Q10 };
            for (int i = 0; i < labels.Length; i++)
            {
                if (i == 2)
                {
                    labels[i].ForeColor = Color.Blue;
                }
                else
                {
                    labels[i].ForeColor = Color.Black;
                }
            }
            for (int i = 0; i < curQuestions[2].incorrect.Count; i++)
            {
                answerLabels[i].Text = "NOT " + curQuestions[2].incorrect[i];
            }
        }
        private void Q2_Click(object sender, EventArgs e)
        {
            if (curQuestions[1] == null) { return; }
            QuestionLabel.Text = curQuestions[1].question;
            Label[] answerLabels = { IQ1, IQ2, IQ3, IQ4, IQ5 };
            Label[] labels = { Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9, Q10 };
            for (int i = 0; i < labels.Length; i++)
            {
                if (i == 1)
                {
                    labels[i].ForeColor = Color.Blue;
                }
                else
                {
                    labels[i].ForeColor = Color.Black;
                }
            }
            for (int i = 0; i < curQuestions[1].incorrect.Count; i++)
            {
                answerLabels[i].Text = "NOT " + curQuestions[1].incorrect[i];
            }
           
        }
        private void Q1_Click(object sender, EventArgs e)
        {
            if (curQuestions[0] == null) { return; }
            QuestionLabel.Text = curQuestions[0].question;
            Label[] answerLabels = { IQ1, IQ2, IQ3, IQ4, IQ5 };
            Label[] labels = { Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9, Q10 };
            for (int i = 0; i < labels.Length; i++)
            {
                if (i == 0)
                {
                    labels[i].ForeColor = Color.Blue;
                }
                else
                {
                    labels[i].ForeColor = Color.Black;
                }
            }
            for (int i = 0; i < curQuestions[0].incorrect.Count; i++)
            {
                answerLabels[i].Text = "NOT " + curQuestions[0].incorrect[i];
            }
        }
        #endregion

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            if (e.Name.Contains('.') && e.Name.Substring(e.Name.IndexOf('.')).Equals(".html"))
            {
                InputHtmlBox.Text = e.Name.Remove(e.Name.IndexOf('.'));
            }
            
        }
    }
    public class Question
    {

        public string question;
        public List<string> incorrect;
        public string correctChoice;
        public bool written;
        public Question(string questionText, string chose, bool correct)
        {
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
            else
            {
                incorrect.Add(chose);
            }


        }
        public Question(string questionText, List<string> incorrects, string correct)
        {
            questionText.Trim();
            question = questionText;
            List<string> trimmedInc = new List<string>();
            foreach (string s in incorrects) { trimmedInc.Add(s.Trim()); }
            incorrect = trimmedInc;
            correct = correct.Trim();
            correctChoice = correct;
            written = true;

        }
        public void printQuestions(string saveFileAddress)
        {

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

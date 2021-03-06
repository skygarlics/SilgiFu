﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace SilgiFU.module
{
    class Problem
    {
        public string title { get; internal set; }
        public string question { get; internal set; }
        public string answer { get; internal set; }

        public Problem()
        {

        }

        public Problem(StreamReader reader)
        {
            Parser(reader);
        }

        public Problem(string text)
        {
            Parser(text);
        }

        public void Parser(StreamReader reader)
        {
            const string TITLE_MARKER = "[title]";
            const string QUESTION_MARKER = "[question]";
            const string ANSWER_MARKER = "[answer]";

            string target = "";
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                if (line == TITLE_MARKER || line == QUESTION_MARKER || line == ANSWER_MARKER)
                {
                    target = line;
                }
                else
                {
                    if (target == TITLE_MARKER) title += line + "\n";
                    else if (target == QUESTION_MARKER) question += line + "\n";
                    else if (target == ANSWER_MARKER) answer += line + "\n";
                }
            }
        }

        public void Parser(string text)
        {
            const string TITLE_MARKER = "[title]";
            const string QUESTION_MARKER = "[question]";
            const string ANSWER_MARKER = "[answer]";

            using (StringReader reader = new StringReader(text))
            {
                string target = "";
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line == TITLE_MARKER || line == QUESTION_MARKER || line == ANSWER_MARKER)
                    {
                        target = line;
                    }
                    else
                    {
                        if (target == TITLE_MARKER) title += line + "\n";
                        else if (target == QUESTION_MARKER) question += line + "\n";
                        else if (target == ANSWER_MARKER) answer += line + "\n";
                    }
                }
            }

            title = title.Trim();
            question = question.Trim();
            answer = answer.Trim();

        }

        public static Problem Test()
        {
            string teststring = @"[title]
this is title

[question]
this is question

[answer]
this is answer";
            return new Problem(teststring);
        }

        public static List<Problem> TestList()
        {
            string teststring = @"[title]
this is title

[question]
this is question

[answer]
this is answer";

            List<Problem> p = new List<Problem>();
            p.Add(Problem.Test());

            return p;
        }

    }
}

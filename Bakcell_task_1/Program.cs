using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text.Json;

namespace Bakcell_task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class BakcellVacancy
    {
        public string Job_name { get; set; }
        public decimal Salary { get; set; }
        public string Location { get; set; }
        public List<Candidate> candidates { get; set; }


        public List<Candidate> GetAcceptedCandidates()
        {
            List<Candidate> tempList = new List<Candidate>();

            foreach (Candidate candidate in candidates)
            {
                if (!string.IsNullOrEmpty(candidate.Fin))
                {
                    tempList.Add(candidate);
                }
            }
            return tempList;
        }
    }

    class Candidate
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        private string email;
        private string fin;

        public string Fin
        {
            get { return fin; }
            set {
                if (value.Length != 7)
                {
                    throw new Exception("Fin 7 koddan ibaret olmalidir");
                }
                fin = value; 
            }
        }
        public string Email
        {
            get { 
                return email; 
            }
            set {

                string pattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";

                if (!Regex.IsMatch(email, pattern))
                {
                    throw new Exception("Daxil etdiyiniz Email standartlara uygun deyil.");
                }

                email = value;
            }
        }

    }
}

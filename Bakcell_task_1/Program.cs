using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text.Json;

namespace Bakcell_task_1
{
    class Program
    {
        //Entry Point
        static void Main(string[] args)
        {
            //Create a job vacancy
            BakcellVacancy job = new BakcellVacancy()
            {
                Job_name = "C# Developer",
                Salary = 2000,
                Location = "Baku, Azerbaijan",
            };

            //Create candidates
            Candidate candidate2 = new Candidate("Qedir", "Memmedli", "test@gmail.com");
            Candidate candidate3 = new Candidate("Nicat", "Demirov", "demirov@mail.com");
            Candidate candidate4 = new Candidate("Samir", "Kerimov", "samir@gmail.com", "6587asd");
            Candidate candidate5 = new Candidate("Merdan", "Kerimov", "kerimov@gmail.com");
            Candidate candidate6 = new Candidate("Rovsen", "Gahramanov", "roshen@gmail.com", "055asdf");


            //add candidates to the list of bakcell vacancy
            job.candidateList.Add(new Candidate("Mahmud", "Garibov", "qaribovmahmud@gmail.com", "71eraj4"));
            job.candidateList.Add(candidate2);
            job.candidateList.Add(candidate3);
            job.candidateList.Add(candidate4);
            job.candidateList.Add(candidate5);
            job.candidateList.Add(candidate6);


            // Get Candidates who has been accepted
            Console.WriteLine(job.GetAcceptedCandidates()); 
        }
    }

    class BakcellVacancy
    {
        public string Job_name { get; set; }
        public decimal Salary { get; set; }
        public string Location { get; set; }
        public List<Candidate> candidateList = new List<Candidate>();


        public string GetAcceptedCandidates()
        {
            List<Candidate> tempList = new List<Candidate>();

            foreach (Candidate candidate in candidateList)
            {
                if (!string.IsNullOrEmpty(candidate.Fin))
                {
                    tempList.Add(candidate);
                }
            }
            return JsonSerializer.Serialize(tempList);
        }
    }

    class Candidate
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        private string email;
        private string fin;
        public Candidate(string argName, string argLastName, string argEmail, string argFin = null)
        {
            Name = argName;
            LastName = argName;
            Email = argEmail;
            Fin = argFin;
        }

        public string Fin
        {
            get { return fin; }
            set {
                if (value!=null && value.Length != 7)
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

                if (!Regex.IsMatch(value, pattern))
                {
                    throw new Exception("Daxil etdiyiniz Email standartlara uygun deyil.");
                }

                email = value;
            }
        }

    }
}

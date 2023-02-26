using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMonitor.Models
{
    [Serializable]
    public class Student
    {
        private float average_score = 0;
        private int[] scores = { 0, 0, 0, 0 };
        private string name = "";

        public Student() { }

        public Student(string name, int score0, int score1, int score2, int score3)
        {
            this.name = name;
            scores[0] = score0;
            scores[1] = score1;
            scores[2] = score2;
            scores[3] = score3;
            average_score = Average_Score;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Subject0
        {
            get => scores[0];
            set => scores[0] = value;
        }
        public int Subject1
        {
            get => scores[1];
            set => scores[1] = value;
        }
        public int Subject2
        {
            get => scores[2];
            set => scores[2] = value;
        }
        public int Subject3
        {
            get => scores[3]; 
            set => scores[3] = value;
        }
        public float Average_Score
        {
            get
            {
                average_score = 0;
                foreach(int num in scores)
                {
                    average_score += num;
                }
                average_score/= scores.Length;
                return average_score;
            }
        }
    }

    [Serializable]
    public class Students
    {
        public List<Student> StudentsList { get; set; } = new List<Student>();
        public Students() { }
    }

}

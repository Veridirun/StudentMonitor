using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using Avalonia.Media;
using JetBrains.Annotations;
using ReactiveUI;
using StudentMonitor.Models;
using System.Xml.Serialization;

namespace StudentMonitor.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Student[] students;
        private int[] scores = { 0, 0, 0, 0 };
        private string studName = "";
        private int index = -1;
        private float[] averageScores = { 0, 0, 0, 0, 0};
        public MainWindowViewModel()
        {
            Students = new Student[]
            {
                new Student("Иванчик Руслан", 2, 2, 1, 2),
                new Student("Балбес Богдан", 0, 1, 0, 0),
                new Student("Аббасов Анар", 1, 2, 1, 2)
            };

            AddStudent = ReactiveCommand.Create(() =>
            {
                if (studName != "")
                {
                    
                    Student[] temp = students;
                    Array.Resize(ref temp, temp.Length + 1);
                    temp[temp.Length - 1] = new Student(studName, scores[0], scores[1], scores[2], scores[3]);
                    Students = temp;
                    StudName = "";
                    CalculateAverage();
                    CalculateColor();
                }
            });

            RemoveStudent = ReactiveCommand.Create(() =>
            {
                if (index != -1)
                {
                    Student[] temp = students;
                    for(int i = index; i< temp.Length-1; i++)
                    {
                        temp[i] = temp[i + 1];
                    }
                    Array.Resize(ref temp, temp.Length - 1);
                    Students = temp;
                    Index = -1;
                    CalculateAverage();
                    CalculateColor();
                }
            });

            SaveFile = ReactiveCommand.Create(() =>
            {
                Serializer<Student[]>.Save("data.xml", students);
            });
            LoadFile = ReactiveCommand.Create(() =>
            {
                Students = Serializer<Student[]>.Load("data.xml");
                CalculateAverage();
            });

            CalculateAverage();
            CalculateColor();
        }
        public Student[] Students
        {
            get => students;
            set => this.RaiseAndSetIfChanged(ref students, value);
        }
        
        public int Score0
        {
            get => scores[0];
            set
            {
                scores[0] = value;
            }
        }
        public int Score1
        {
            get => scores[1];
            set
            {
                scores[1] = value;
            }
        }
        public int Score2
        {
            get => scores[2];
            set
            {
                scores[2] = value;
            }
        }
        public int Score3
        {
            get => scores[3];
            set
            {
                scores[3] = value;
            }
        }
        public string StudName
        {
            get => studName;
            set
            {
                this.RaiseAndSetIfChanged(ref studName, value);
            }
        }
        public int Index
        {
            get => index;
            set
            {
                index = value;
            }
        }
        public ReactiveCommand<Unit, Unit> AddStudent { get; }
        public ReactiveCommand<Unit, Unit> RemoveStudent { get; }
        public float Average0{ get => averageScores[0]; set=> this.RaiseAndSetIfChanged(ref averageScores[0], value); }
        public float Average1 { get => averageScores[1]; set => this.RaiseAndSetIfChanged(ref averageScores[1], value); }
        public float Average2 { get => averageScores[2]; set => this.RaiseAndSetIfChanged(ref averageScores[2], value); }
        public float Average3 { get => averageScores[3]; set => this.RaiseAndSetIfChanged(ref averageScores[3], value); }
        public float Average4 { get => averageScores[4]; set => this.RaiseAndSetIfChanged(ref averageScores[4], value); }

        private void CalculateAverage()
        {
            Average0 = 0;
            Average1 = 0;
            Average2 = 0;
            Average3 = 0;
            Average4 = 0;
            foreach(Student student in students)
            {
                Average0 += student.Subject0;
                Average1 += student.Subject1;
                Average2 += student.Subject2;
                Average3 += student.Subject3;
                Average4 += student.Average_Score;
            }
            Average0 /= students.Length;
            Average1 /= students.Length;
            Average2 /= students.Length;
            Average3 /= students.Length;
            Average4 /= students.Length;
        }

        private SolidColorBrush setColor(float num)
        {
            if (num < 1) return new SolidColorBrush(Colors.Red);
            if (num < 1.5) return new SolidColorBrush(Colors.Yellow);
            else return new SolidColorBrush(Colors.Green);
        }

        private void CalculateColor()
        {
            Color0 = setColor(averageScores[0]);
            Color1 = setColor(averageScores[1]);
            Color2 = setColor(averageScores[2]);
            Color3 = setColor(averageScores[3]);
            Color4 = setColor(averageScores[4]);
        }
        private SolidColorBrush[] colorBrush = new SolidColorBrush[5];
        public SolidColorBrush Color0 { get => colorBrush[0]; set => this.RaiseAndSetIfChanged(ref colorBrush[0], value); }
        public SolidColorBrush Color1 { get => colorBrush[1]; set => this.RaiseAndSetIfChanged(ref colorBrush[1], value); }
        public SolidColorBrush Color2 { get => colorBrush[2]; set => this.RaiseAndSetIfChanged(ref colorBrush[2], value); }
        public SolidColorBrush Color3 { get => colorBrush[3]; set => this.RaiseAndSetIfChanged(ref colorBrush[3], value); }
        public SolidColorBrush Color4 { get => colorBrush[4]; set => this.RaiseAndSetIfChanged(ref colorBrush[4], value); }

        public ReactiveCommand<Unit, Unit> SaveFile { get; }
        public ReactiveCommand<Unit, Unit> LoadFile { get; }

    }
}

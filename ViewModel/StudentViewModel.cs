using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module02Activity01.Model;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Module02Activity01.ViewModel
{
    
    public class StudentViewModel : INotifyPropertyChanged
    {
        //role of ViewModel

        private Student _student;

        private string _fullName; //variable for data conversion


        public StudentViewModel()
        {
            //Initialize sample student model. Coordination with model.
            _student = new Student {FirstName="John", LastName="Doe", Age=23 };
            //UI thread management
            LoadStudentDataCommand = new Command(async () => await LoadStudentDataAsync());

            Students= new ObservableCollection<Student> 
            {
                new Student {FirstName="John", LastName="Doe", Age=21 },
                new Student {FirstName="Jane", LastName="Doe", Age=22 },
                new Student {FirstName="Deez", LastName="Doe", Age=23 },
                new Student {FirstName="Ellen", LastName="Doe", Age=24 },
            };

        }
        public ObservableCollection<Student> Students { get; set; }
        //2 way data binding and data conversion
        public string FullName
        {
            get => _fullName;
            set {
                if(_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }
        //UI Thread Management
        public ICommand LoadStudentDataCommand { get; }


        private async Task LoadStudentDataAsync()
        {
            await Task.Delay(1000); // I/O operation
            FullName = $"{_student.FirstName} {_student.LastName}"; //Data Conversion
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
    }
}

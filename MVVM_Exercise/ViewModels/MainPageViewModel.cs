using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.ObjectModel;
using MVVM_Exercise.Models;

namespace MVVM_Exercise.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Note> AllNotes { get; set; } //Defines an ObservableCollection which will contain all the notes written

        public event PropertyChangedEventHandler PropertyChanged; //Implementation of INotifyPropertyChanged

        Note theNote;

        void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string TheNote
        {
            get => theNote.Text; //Getter
            set
            {
                theNote.Text = value;
                OnPropertyChanged();
            }
        } //Setter which invokes the PropertyChanged Event with the note

        public Command SaveCommand { get; } //Decleration of both commands
        public Command DeleteCommand { get; }
        public MainPageViewModel()
        {
            theNote = new Note();
            AllNotes = new ObservableCollection<Note>();
            DeleteCommand = new Command(() =>
            {
                TheNote = string.Empty;
                AllNotes.Clear();
            }); //Defines delete command with anonymous method which removes the contents of TheNote Property

            SaveCommand = new Command(() =>
            {

                AllNotes.Add(new Note() { Text = TheNote });

                TheNote = string.Empty;
            }); //Defines save command with anonymous method which adds TheNote Property to the observable collection and removes the contents of the property
        } // Constructor



        
    }
}

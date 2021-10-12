using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;


namespace ToDoListApp.Models
{
    internal sealed class ToDoModel : INotifyPropertyChanged
    {
        #region Fields

        private bool _isDone;
        private string _text;
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion


        #region Properties

        [JsonProperty(PropertyName = "creationDate")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [JsonProperty(PropertyName = "isDone")]
        public bool IsDone
        {
            get => _isDone;
            set
            {
                if (_isDone == value)
                {
                    return;
                }
                _isDone = value;
                OnPropertyChanged(nameof(IsDone));
            }
        }

        [JsonProperty(PropertyName = "text")]
        public string Text
        {
            get => _text;
            set
            {
                if (_text == value)
                {
                    return;
                }
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        #endregion


        #region Methods

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}

using HoGentMaui.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoGentMaui.ViewModels.JokeList
{
    public class JokeViewModel : ViewModel
    {
        public string Id { get; set; }

        private string _jokeText;

        public string? JokeText
        {
            get => _jokeText;
            set
            {
                _jokeText = value;

                NotifyPropertyChanged();
            }
        }

    }
}

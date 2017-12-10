using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace OneBelote.Model
{
    public class ScoreLine : INotifyPropertyChanged
    {
        private int _them;

        public int Them
        {
            get { return _them; }
            set {
                _them = value;
                OnPropertyChanged();
            }
        }

        private int _us;

        public int Us
        {
            get { return _us; }
            set {
                _us = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

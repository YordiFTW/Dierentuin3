using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Windows.Input;

namespace Dierentuin3
{
    public class Animal
    {
        public ObservableCollection<string> Animals { get; set; }
        public int Id { get; set; }

        public string Name { get; set; }

        public int Energy { get; set; }

        public void Eat()
        {
            Energy += 25;
        }
    }
}

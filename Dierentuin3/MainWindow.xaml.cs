using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Dierentuin3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        int gold = 0;
        int workers = 0;
        int workerprice = 10;
        int investors = 0;
        int investorprice = 10;

        public List<Animal> myAnimals { get; set; }

        public Animal animal { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            myAnimals = new List<Animal>();

            Animal animal1 = new Animal();
            animal1.Name = "Aap";
            animal1.Energy = 60;

            Animal animal2 = new Animal();
            animal2.Name = "Olifant";
            animal2.Energy = 150;

            Animal animal3 = new Animal();
            animal3.Name = "Leeuw";
            animal3.Energy = 100;


            myAnimals.Add(animal1);
            myAnimals.Add(animal2);
            myAnimals.Add(animal3);

            DataContext = this;

            TimerMain();

        }

        public void TimerMain()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(5000);
            timer.Tick += UseEnergy;
            timer.Tick += UseWorker;
            timer.Tick += UseInvestor;
            timer.Start();
        }


        //Add Animal
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Animal animalnew = new Animal();
            animalnew.Name = Textbox1.Text;

            if (Textbox1.Text == "Aap" || Textbox1.Text == "aap")
            {
                animalnew.Energy = 60;
            }
            else
            {
                animalnew.Energy = 100;
            }

            myAnimals.Add(animalnew);

            ListView1.Items.Refresh();

            Textbox1.Text = "";

            
        }

        //feed all
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            foreach (var animal in myAnimals)
            {
                if (animal.Name == "Aap" || animal.Name == "aap")
                animal.Energy = animal.Energy + 10;

                else if (animal.Name == "Leeuw" || animal.Name == "leeuw")
                    animal.Energy = animal.Energy + 25;

                else if (animal.Name == "Olifant" || animal.Name == "olifant")
                    animal.Energy = animal.Energy + 50;

                else
                    animal.Energy = animal.Energy + 25;
            }

            ListView1.Items.Refresh();
        }

        //feed apes
        public void Button5_Click(object sender, RoutedEventArgs e)
        {
            foreach (var animal in myAnimals)
            {
                if (animal.Name == "Aap" || animal.Name == "aap")
                {
                    animal.Energy = animal.Energy + 10;
                }
            }
            ListView1.Items.Refresh();
        }

        //feed lions
        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            foreach (var animal in myAnimals)
            {
                if (animal.Name == "Leeuw" || animal.Name == "leeuw")
                {
                    animal.Energy = animal.Energy + 25;
                }
            }
            ListView1.Items.Refresh();
        }

        //feed elephants
        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            foreach (var animal in myAnimals)
            {
                if (animal.Name == "Olifant" || animal.Name == "olifant")
                {
                    animal.Energy = animal.Energy + 50;
                }
            }
            ListView1.Items.Refresh();
        }

        private void ListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        public void UseEnergy(object sender, EventArgs e)
        {
            foreach (var animal in myAnimals.ToList())
            {
                if (animal.Name == "Aap" || animal.Name == "aap")
                    animal.Energy = animal.Energy - 2;

                else if (animal.Name == "Leeuw" || animal.Name == "leeuw")
                    animal.Energy = animal.Energy - 10;

                else if (animal.Name == "Olifant" || animal.Name == "olifant")
                    animal.Energy = animal.Energy - 5;

                else
                    animal.Energy = animal.Energy - 10;

                ListView1.Items.Refresh();
                OnDeath();
            }
        }

        public void OnDeath()
        {
            foreach (var animal in myAnimals.ToList())
                if(animal.Energy < 0)
                {
                    myAnimals.Remove(animal);
                }

            ListView1.Items.Refresh();
        }

        public void Button8_Click(object sender, RoutedEventArgs e)
        {
            foreach (var animal in myAnimals)
            {
                if (animal.Name == "Aap" || animal.Name == "aap")
                    animal.Energy = animal.Energy + 1;

                else if (animal.Name == "Leeuw" || animal.Name == "leeuw")
                    animal.Energy = animal.Energy + 1;

                else if (animal.Name == "Olifant" || animal.Name == "olifant")
                    animal.Energy = animal.Energy + 1;

                else
                    animal.Energy = animal.Energy + 1;
            }

            gold = gold + 1;
            textBlock2.Text = gold.ToString();
            ListView1.Items.Refresh();
        }

        private void UseWorker(object sender, EventArgs e)
        {
            foreach (var animal in myAnimals)
            {
                if (animal.Name == "Aap" || animal.Name == "aap")
                    animal.Energy = animal.Energy + workers;

                else if (animal.Name == "Leeuw" || animal.Name == "leeuw")
                    animal.Energy = animal.Energy + workers;

                else if (animal.Name == "Olifant" || animal.Name == "olifant")
                    animal.Energy = animal.Energy + workers;

                else
                    animal.Energy = animal.Energy + workers;
            }
            ListView1.Items.Refresh();
        }

        public void buyWorker_Click(object sender, RoutedEventArgs e)
        {
            if (gold >= workerprice)
            {
                gold = gold - workerprice;
                workers = workers + 1;
                textBlock3.Text = workers.ToString();
                textBlock2.Text = gold.ToString();
            }

            else
            {

            }
        }

        private void buyInvestor_Click(object sender, RoutedEventArgs e)
        {
            if (gold >= investorprice)
            {
                gold = gold - investorprice;
                investors = investors + 1;
                textBlock4.Text = investors.ToString();
                textBlock2.Text = gold.ToString();
            }

            else
            {

            }
        }

        private void UseInvestor(object sender, EventArgs e)
        {
            gold = gold + investors;
            textBlock2.Text = gold.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
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

namespace Age
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void AgeClick(object sender, RoutedEventArgs even)
        {
            Output.Text = "";
            DateTime? birthday = Dp.SelectedDate;
            if (birthday.HasValue)
            {
                int bDay = birthday.Value.Day;
                int mDay = birthday.Value.Month;
                int yDay = birthday.Value.Year;
                var age = AgeCalculate(bDay, mDay, yDay);
                Output.Inlines.Add("Вам " + age.Item1.ToString() + " года и " 
                                    + age.Item2.ToString() + " м.");
            }
        }

        private (int,int) AgeCalculate(int birthDay, int birthMonth, int birthYear)
        {
            DateTime now = DateTime.Now;
            int currentDay = now.Day;
            int currentMonth = now.Month;
            int currentYear = now.Year;
            
            int[] month = { 31, 28, 31, 30, 31, 30,
                            31, 31, 30, 31, 30, 31 };
            
            if (birthDay > currentDay)
                currentMonth--;
            
            if (birthMonth > currentMonth)
            {
                currentYear--;
                currentMonth += 12;
            }
            
            return (currentYear- birthYear, currentMonth - birthMonth);
        }
    }
}
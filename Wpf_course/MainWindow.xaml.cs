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

namespace Wpf_course
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
        
        private void button1_Click(object sender, RoutedEventArgs e) //кнопка армстронга
        {
            int y = 1, n;
            string armstrongs = "";

            n = isDigit(textBox1.Text);//проверяем число ли введено

            if (n >= 10000)//проверяем что бы оно удовлетворяло условию
            {
                n = 0;
                MessageBox.Show("Ввoдите число не более 4 цифр!");                
            }
            

            while (y <= n) { armstrongs=IsArmstrong(y, armstrongs); y++; } // находим все числа армстронга меньшие данного числа и пишем их в строку
            textBox2.Text = armstrongs; //выводим пользователю
        }


        public static string IsArmstrong(int chislo, string str)
        {
            int ch = chislo;

            var cifr = new List<int>(4);
            while (chislo > 0) // в этом цикле разбиваем число на цифры
            {
                cifr.Add(chislo % 10);
                chislo /= 10;
            }

            var cifr_v_st = cifr.ToArray(); // для цифр, возведенных в n-ю степень

            for (int j = 0; j < (cifr_v_st.Length - 1); j++)
            {
                for (int i = 0; i < cifr_v_st.Length; i++)
                {
                    cifr_v_st[i] *= cifr[i];
                }
            }

            var sum = cifr_v_st.Sum(); // считаем сумму
            if (sum == ch)
                return str = String.Concat(str, $" {ch}");
            else
                return str;
        }

        public static int isDigit(string str) 
        {
            if (str.Any(c => char.IsLetter(c))||str=="")
            {
                if(str!="")
                MessageBox.Show("Вводить можно только числа");
                return 0;
            }
            else
                return (int)uint.Parse(str);
        }


        /**/private void button2_Click(object sender, RoutedEventArgs e) 
        {

            int a, b;

            a = isDigit(textBox1.Text);
            b = isDigit(textBox3.Text);

            if (a != 0 && b != 0)
            {
                if (naity_a_in_chis(textBox1.Text, textBox3.Text))
                    textBox2.Text = "цифра есть в числе";
                else textBox2.Text = "цифры нет в числе";
            }
        }

        public static bool naity_a_in_chis(string chislo, string a) // нахождение цифры в числе
        {
            for (int i = 0; i < chislo.Length; i++) //проходим по числу (строке) как по массиву
                if (chislo[i] == a[0]) // если в числе найдена цифра
                    return true;

            return false;
        }



    }
}

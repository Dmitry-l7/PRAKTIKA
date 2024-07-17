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

namespace PRAKTIKA
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Zadaca> zadacas = new List<Zadaca>(); //  Создание  поля  которое представляет собой список объектов 
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AddZadacaButton_Click(object sender, RoutedEventArgs e) // нажатие на кнопку "добавить задачу"
        {
            Zadaca newZadaca = new Zadaca // создание нового объекта 
            {
                Name = ZadacaName.Text,
                Priority = (ZadacaPriorit)Prioritet.SelectedIndex, //Установка свойств объекта на основе значений из текстового поля, комбо-бокса и выбранной даты.
                Deadline = Deadline.SelectedDate,

            };

            zadacas.Add(newZadaca);// добавление новой задачи  
            UpdateZadacaList(); // обновление сптска задач
        }

        private void DeleteZadacaButton_Click(object sender, RoutedEventArgs e) // нажатие на кнопку "удалить задачу"
        {
            if (ZadacaList.SelectedItem is Zadaca zadaca) // Проверка выбран ли элемент  в списке.
            {
                zadacas.Remove(zadaca); // удаление задачи из списка
                UpdateZadacaList();// обновление спсика задач

            }
        }
        private void SdelanoZadacaButton_Click(Object sender, RoutedEventArgs e)
        {
            if (ZadacaList.SelectedItem is Zadaca zadaca)
            {
                zadaca.Name = "ВЫПОЛНЕНО: " + zadaca.Name;
                UpdateZadacaList(); // Обновляем список задач


            }
        }
        private void UpdateZadacaList()
        {
            ZadacaList.Items.Clear();
            for (int i = 0; i < zadacas.Count; i++)
            {
                ZadacaList.Items.Add(zadacas[i]);

            }
        }
    }

    public class Zadaca // класс 
    {
        public string Name { get; set; }
        public ZadacaPriorit Priority { get; set; }
        public DateTime? Deadline { get; set; }

        public override string ToString()
        {

            return $"{Name} - Приоретет: {Priority}; Дедлайн(сделать до): {Deadline}";// возвращение строки с информацией 
        }
    }

    public enum ZadacaPriorit // перечесление 
    {
        Низкойважности,
        Среднейважности, // константы 
        Важно
    }
}
    


using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace DuftPunk
{
    /// <summary>
    /// Логика взаимодействия для ProjectSetupWindow.xaml
    /// </summary>
    public partial class ProjectSetupWindow : Window
    {
        public ProjectSetupWindow()
        {
            InitializeComponent();         
        }

        private void UpdateMethodologies(bool isSingleUser)
        {
            panelMethodologies.Children.Clear();

            if (isSingleUser)
            {
                AddMethodologyButton("Scrum", () => OpenScrumWindow());
            }
            else
            {
                AddMethodologyButton("Scrum", () => OpenScrumWindow());
                //AddMethodologyButton("Gantt Chart", () => OpenGanttChartWindow());
                //AddMethodologyButton("Kanban", () => OpenKanbanWindow());
            }
        }

        private void AddMethodologyButton(string content, Action clickAction)
        {
            var button = new Button { Content = content, Margin = new Thickness(5) };
            button.Click += (sender, e) => clickAction();
            panelMethodologies.Children.Add(button);
        }

        private void OpenScrumWindow()
        {
            var scrumWindow = new ScrumWindow();
            scrumWindow.ShowDialog();
        }

        //private void OpenGanttChartWindow()
        //{
        //    var ganttChartWindow = new GanttChartWindow();
        //    ganttChartWindow.ShowDialog();
        //}

        //private void OpenKanbanWindow()
        //{
        //    var kanbanWindow = new KanbanWindow();
        //    kanbanWindow.ShowDialog();
        //}

        private void BtnContinue_Click(object sender, RoutedEventArgs e)
        {
            bool isSingleUser = radioSingleUser.IsChecked ?? true;
            if (isSingleUser)
            {
                OpenScrumWindow();
            }
            else
            {
                if (panelMethodologies.Children.Count > 0)
                {
                    Button selectedMethodologyButton = panelMethodologies.Children[0] as Button;
                    if (selectedMethodologyButton != null)
                    {
                        switch (selectedMethodologyButton.Content.ToString())
                        {
                            case "Scrum":
                                OpenScrumWindow();
                                break;
                            //case "Gantt Chart":
                            //    OpenGanttChartWindow();
                            //    break;
                            //case "Kanban":
                            //    OpenKanbanWindow();
                            //    break;
                        }
                    }
                }
            }
        }

        private void RadioSingleUser_Checked(object sender, RoutedEventArgs e)
        {
            UpdateMethodologies(true);
        }

        private void RadioMultipleUsers_Checked(object sender, RoutedEventArgs e)
        {
            UpdateMethodologies(false);
        }
    }
}

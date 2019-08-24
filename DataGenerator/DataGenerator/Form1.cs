using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGenerator
{ 
    public partial class DataGenerator : Form
    {
        private static int elements;
        private static dynamic[] tabOne;
        private static dynamic[] tabTwo;
        private static dynamic[] tabThree;
        private static dynamic[] tabFour;
        private static dynamic[] tabFive;

        public DataGenerator()
        {
            InitializeComponent();
            NumberCombobox.SelectedIndex = 0;
            TypeCombobox1.SelectedIndex = 0;
            TypeCombobox2.SelectedIndex = 0;
            TypeCombobox3.SelectedIndex = 0;
            TypeCombobox4.SelectedIndex = 0;
            TypeCombobox5.SelectedIndex = 0;
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            if(ElementsTextbox.Text != "")
            {
                elements = Convert.ToInt32(ElementsTextbox.Text);
                tabOne = new dynamic[elements];
                tabTwo = new dynamic[elements];
                tabThree = new dynamic[elements];
                tabFour = new dynamic[elements];
                tabFive = new dynamic[elements];
                if (NumberCombobox.SelectedIndex == 0)
                {
                    Combobox1(sender, e);
                    saveToFile(1);
                }
                else if (NumberCombobox.SelectedIndex == 1)
                {
                    Combobox1(sender, e);
                    Combobox2(sender, e);
                    saveToFile(2);
                }
                else if (NumberCombobox.SelectedIndex == 2)
                {
                    Combobox1(sender, e);
                    Combobox2(sender, e);
                    Combobox3(sender, e);
                    saveToFile(3);
                }
                else if (NumberCombobox.SelectedIndex == 3)
                {
                    Combobox1(sender, e);
                    Combobox2(sender, e);
                    Combobox3(sender, e);
                    Combobox4(sender, e);
                    saveToFile(4);
                }
                else if (NumberCombobox.SelectedIndex == 4)
                {
                    Combobox1(sender, e);
                    Combobox2(sender, e);
                    Combobox3(sender, e);
                    Combobox4(sender, e);
                    Combobox5(sender, e);
                    saveToFile(5);
                }
            }
        }

        private void Combobox1(object sender, EventArgs e)
        {
            if (TypeCombobox1.SelectedItem.ToString().Equals("Integer"))
            {
                tabOne = GenIntTab(elements);
            }
            else if (TypeCombobox1.SelectedItem.ToString().Equals("Float"))
            {
                tabOne = GenFloatTab(elements);
            }
            else if (TypeCombobox1.SelectedItem.ToString().Equals("Char"))
            {
                tabOne = GenCharTab(elements);
            }
            else if (TypeCombobox1.SelectedItem.ToString().Equals("String"))
            {
                tabOne = GenStringTab(elements);
            }
        }

        private void Combobox2(object sender, EventArgs e)
        {
            if (TypeCombobox2.SelectedItem.ToString().Equals("Integer"))
            {
                tabTwo = GenIntTab(elements);
            }
            else if (TypeCombobox2.SelectedItem.ToString().Equals("Float"))
            {
                tabTwo = GenFloatTab(elements);
            }
            else if (TypeCombobox2.SelectedItem.ToString().Equals("Char"))
            {
                tabTwo = GenCharTab(elements);
            }
            else if (TypeCombobox2.SelectedItem.ToString().Equals("String"))
            {
                tabTwo = GenStringTab(elements);
            }
        }

        private void Combobox3(object sender, EventArgs e)
        {
            if (TypeCombobox3.SelectedItem.ToString().Equals("Integer"))
            {
                tabThree = GenIntTab(elements);
            }
            else if (TypeCombobox3.SelectedItem.ToString().Equals("Float"))
            {
                tabThree = GenFloatTab(elements);
            }
            else if (TypeCombobox3.SelectedItem.ToString().Equals("Char"))
            {
                tabThree = GenCharTab(elements);
            }
            else if (TypeCombobox3.SelectedItem.ToString().Equals("String"))
            {
                tabThree = GenStringTab(elements);
            }
        }

        private void Combobox4(object sender, EventArgs e)
        {
            if (TypeCombobox4.SelectedItem.ToString().Equals("Integer"))
            {
                tabFour = GenIntTab(elements);
            }
            else if (TypeCombobox4.SelectedItem.ToString().Equals("Float"))
            {
                tabFour = GenFloatTab(elements);
            }
            else if (TypeCombobox4.SelectedItem.ToString().Equals("Char"))
            {
                tabFour = GenCharTab(elements);
            }
            else if (TypeCombobox4.SelectedItem.ToString().Equals("String"))
            {
                tabFour = GenStringTab(elements);
            }
        }

        private void Combobox5(object sender, EventArgs e)
        {
            if (TypeCombobox5.SelectedItem.ToString().Equals("Integer"))
            {
                tabFive = GenIntTab(elements);
            }
            else if (TypeCombobox5.SelectedItem.ToString().Equals("Float"))
            {
                tabFive = GenFloatTab(elements);
            }
            else if (TypeCombobox5.SelectedItem.ToString().Equals("Char"))
            {
                tabFive = GenCharTab(elements);
            }
            else if (TypeCombobox5.SelectedItem.ToString().Equals("String"))
            {
                tabFive = GenStringTab(elements);
            }
        }

        private dynamic[] GenIntTab(int elements)
        {
            dynamic[] tab = new dynamic[elements];
            for (int i = 0; i < elements; i++)
            {
                if(i != 0)
                {
                    do
                    {
                        Random random = new Random(DateTime.Now.Ticks.GetHashCode());
                        tab[i] = random.Next(0, 100);
                    } while (tab[i] == tab[i - 1]);
                }
                else
                {
                    Random random = new Random(DateTime.Now.Ticks.GetHashCode());
                    tab[i] = random.Next(0, 100);
                }
            }
            return tab;
        }

        private dynamic[] GenFloatTab(int elements)
        {
            dynamic[] tab = new dynamic[elements];
            for (int i = 0; i < elements; i++)
            {
                if (i != 0)
                {
                    do
                    {
                        Random random = new Random(DateTime.Now.Ticks.GetHashCode());
                        tab[i] = random.NextDouble() * 100;
                    } while (tab[i] == tab[i - 1]);
                }
                else
                {
                    Random random = new Random(DateTime.Now.Ticks.GetHashCode());
                    tab[i] = random.NextDouble() * 100;
                }
            }
            return tab;
        }

        private dynamic[] GenCharTab(int elements)
        {
            dynamic[] tab = new dynamic[elements];
            for (int i = 0; i < elements; i++)
            {
                if (i != 0)
                {
                    do
                    {
                        Random random = new Random(DateTime.Now.Ticks.GetHashCode());
                        tab[i] = (char)random.Next('a', 'z');
                    } while (tab[i] == tab[i - 1]);
                }
                else
                {
                    Random random = new Random(DateTime.Now.Ticks.GetHashCode());
                    tab[i] = (char)random.Next('a', 'z');
                }
            }
            return tab;
        }

        private dynamic[] GenStringTab(int elements)
        {
            int length = 10;
            dynamic[] tab = new dynamic[elements];
            for (int i = 0; i < elements; i++)
            {
                if (i != 0)
                {
                    do
                    {
                        Random random = new Random(DateTime.Now.Ticks.GetHashCode());
                        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                        tab[i] = new string(Enumerable.Repeat(chars, length)
                          .Select(s => s[random.Next(s.Length)]).ToArray());
                    } while (tab[i] == tab[i - 1]);
                }
                else
                {
                    Random random = new Random(DateTime.Now.Ticks.GetHashCode());
                    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    tab[i] = new string(Enumerable.Repeat(chars, length)
                      .Select(s => s[random.Next(s.Length)]).ToArray());
                }
            }
            return tab;
        }

        private void NumberCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(NumberCombobox.SelectedIndex == 0)
            {
                TypeCombobox1.Enabled = true;
                TypeCombobox2.Enabled = false;
                TypeCombobox3.Enabled = false;
                TypeCombobox4.Enabled = false;
                TypeCombobox5.Enabled = false;
            }
            else if(NumberCombobox.SelectedIndex == 1)
            {
                TypeCombobox1.Enabled = true;
                TypeCombobox2.Enabled = true;
                TypeCombobox3.Enabled = false;
                TypeCombobox4.Enabled = false;
                TypeCombobox5.Enabled = false;
            }
            else if (NumberCombobox.SelectedIndex == 2)
            {
                TypeCombobox1.Enabled = true;
                TypeCombobox2.Enabled = true;
                TypeCombobox3.Enabled = true;
                TypeCombobox4.Enabled = false;
                TypeCombobox5.Enabled = false;
            }
            else if (NumberCombobox.SelectedIndex == 3)
            {
                TypeCombobox1.Enabled = true;
                TypeCombobox2.Enabled = true;
                TypeCombobox3.Enabled = true;
                TypeCombobox4.Enabled = true;
                TypeCombobox5.Enabled = false;
            }
            else 
            {
                TypeCombobox1.Enabled = true;
                TypeCombobox2.Enabled = true;
                TypeCombobox3.Enabled = true;
                TypeCombobox4.Enabled = true;
                TypeCombobox5.Enabled = true;
            }
        }

        private void saveToFile(int columns)
        {
            string path = @"C:\Users\pawel\Desktop\MyTest.txt";

            if (File.Exists(path))
            {
                File.Delete(path);
            }
            FileStream fs = File.Create(path);

            fs.Close();

            var txt = new StringBuilder();

            for (int i = 0; i < elements; i++)
            {
                if(columns == 1)
                {
                    var newLine = string.Format(tabOne[i]);
                    txt.AppendLine(newLine);
                }
                else if(columns == 2)
                {
                    var newLine = string.Format(tabOne[i] + "," + tabTwo[i]);
                    txt.AppendLine(newLine);
                }
                else if(columns == 3)
                {
                    var newLine = string.Format(tabOne[i] + "," + tabTwo[i] + "," + tabThree[i]);
                    txt.AppendLine(newLine);
                }
                else if(columns == 4)
                {
                    var newLine = string.Format(tabOne[i] + "," + tabTwo[i] + "," + tabThree[i] + "," + tabFour[i]);
                    txt.AppendLine(newLine);
                }
                else if(columns == 5)
                {
                    var newLine = string.Format(tabOne[i] + "," + tabTwo[i] + "," + tabThree[i] + "," + tabFour[i] + "," + tabFive[i]);
                    txt.AppendLine(newLine);
                }
            }
            File.WriteAllText(path, txt.ToString());
        }
    }
}

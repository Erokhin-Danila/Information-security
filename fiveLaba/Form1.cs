using GroupDocs.Merger;
using GroupDocs.Merger.Domain.Options;
using System;
using System.IO;
using System.Windows.Forms;

namespace fiveLaba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string name;
        string secret_password;

        OpenFileDialog openFileDialog = new OpenFileDialog();

        
        private void password_Click(object sender, EventArgs e)
        {
            // для повторной генерации пароля
            Click_pov();

            name = textBox1.Text;
            Random rand = new Random();

            int stringLength = rand.Next(7, 20);

            int randValue;
            string passwordLine = "";
            char letter; // Один символ

            for (int i = 0; i < stringLength; i++)
            {
                randValue = rand.Next(0, 26); // 26 букв английского алфавита
                letter = Convert.ToChar(randValue + 97); // конвертация в символ Unicod(1 буква начинается c 97 символа)
                passwordLine += letter; // Запись всех символов в переменную String
            }

            secret_password = passwordLine;
            passwordLine = "";

            // в файле содержится сгенерированный пароль
            string path = "C:\\Users\\HP\\Рабочий стол\\семестр 5\\Основы теории безопасностти\\fiveLaba\\пароль.txt";

            StreamWriter Password = new StreamWriter(path, false);
            Password.WriteLine(secret_password);
            Password.Close();

            AddPasswordOptions addOptions = new AddPasswordOptions(secret_password);

            if (name != "")
            {
                using (Merger merger = new Merger(name)) 
                {
                    merger.AddPassword(addOptions);
                    merger.Save(name);
                }
            }
        }
            

        private void remove_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;

            string path = "C:\\Users\\HP\\Рабочий стол\\семестр 5\\Основы теории безопасностти\\fiveLaba\\пароль.txt";

            StreamReader reader = new StreamReader(path);
            secret_password = reader.ReadLine();
            reader.Close();

            LoadOptions loadOptions = new LoadOptions(secret_password);

            if (name != "")
            {
                using (Merger merger = new Merger(name, loadOptions))
                {
                    merger.RemovePassword();
                    merger.Save(name);
                }
            }

        }
        // Выбираем какой файл открыть
        private void openFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                textBox1.Text = openFileDialog.FileName;
        }

        // После повторного нажатия для генерации пароля, очищаем содержимое файла
        public void Click_pov()
        {
            string path = "C:\\Users\\HP\\Рабочий стол\\семестр 5\\Основы теории безопасностти\\fiveLaba\\пароль.txt";

            StreamReader reader = new StreamReader(path);
            secret_password = reader.ReadLine();
            reader.Close();
            if (secret_password != "")
            {
                StreamWriter Password = new StreamWriter(path, false);
                Password.Write(string.Empty);
                Password.Close();
            }
        }
    }
}  
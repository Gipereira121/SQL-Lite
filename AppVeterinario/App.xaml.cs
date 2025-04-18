using AppVeterinario.Helpers;

namespace AppVeterinario
{
    public partial class App : Application
    {
        static SQLiteDataBaseHelpers _db;
        public static SQLiteDataBaseHelpers Db
        {
            get
            {
                if (_db == null) //criando o banco de dados 
                {
                    string path = Path.Combine( //caminho para o banco de dados ser salvo
                        Environment.GetFolderPath( //pega a pasta que o arquivo foi salvo e junta o arquivo a pasta do projeto
                            Environment.SpecialFolder.LocalApplicationData), //mostra onde a aplicação esta instalada
                                "banco_sqlite_especies.db3"); //nome do arquivo

                    _db = new SQLiteDataBaseHelpers(path);
                    
                }
                return _db;
            }
        }
        
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}

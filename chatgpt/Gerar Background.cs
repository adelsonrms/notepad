


/*
Prompt : 
Preciso que me gere um codigo em uma classe em C# dedicada em uma Aplicação ASP NET MVC 4 que seja inicializada no Application_Start para que realize a seguinte ação : Executar em loop infinito em thread separada. Dentro desse loop, verifica a cada segundo o conteudo de uma tabela em um banco de dados SQL. De acordo com o resultado dessa tabela, tomar uma decição e executar uma Action ou um metodo qualquer. As caracteristicas da classe deve ser similar a um Worker Service ou um Background Job. A execução deve ser assyncrona e nao pode interferir a execução da trhead principal A liguagem deve ser C#
*/

//Criação da classe `DatabaseMonitor


using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace YourNamespace
{
    public class DatabaseMonitor
    {
        private CancellationTokenSource _cancellationTokenSource;
        private bool _isPaused;
        private readonly object _lock = new object();

        public DatabaseMonitor()
        {
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void Start()
        {
            if (_cancellationTokenSource.IsCancellationRequested || _isPaused)
            {
                _cancellationTokenSource = new CancellationTokenSource();
                _isPaused = false;
                Task.Run(async () => await MonitorDatabaseAsync(_cancellationTokenSource.Token));
            }
        }

        private async Task MonitorDatabaseAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    lock (_lock)
                    {
                        if (_isPaused)
                        {
                            Monitor.Wait(_lock);
                        }
                    }

                    using (var connection = new SqlConnection("your-connection-string"))
                    {
                        await connection.OpenAsync(cancellationToken);
                        using (var command = new SqlCommand("SELECT TOP 1 YourColumn FROM YourTable", connection))
                        {
                            var result = await command.ExecuteScalarAsync(cancellationToken);
                            if (result != null)
                            {
                                ProcessResult(result);
                            }
                        }
                    }

                    await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
                }
                catch (OperationCanceledException)
                {
                    // O loop foi cancelado de forma controlada
                    break;
                }
                catch (Exception ex)
                {
                    // Tratar exceções e logar se necessário
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }
        }

        public void Pause()
        {
            lock (_lock)
            {
                _isPaused = true;
            }
        }

        public void Resume()
        {
            lock (_lock)
            {
                if (_isPaused)
                {
                    _isPaused = false;
                    Monitor.Pulse(_lock);
                }
            }
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
        }

        private void ProcessResult(object result)
        {
            // Implementar a lógica de processamento do resultado
            Console.WriteLine($"Resultado: {result}");
            ExecuteAction();
        }

        private void ExecuteAction()
        {
            // Implementar a ação desejada
            Console.WriteLine("Ação executada!");
        }
    }
}


//Esse codigo registra o DI do Ninject

using Ninject;
using Ninject.Web.Common;
using System.Web.Mvc;
using YourNamespace;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(YourMvcApplication.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(YourMvcApplication.App_Start.NinjectWebCommon), "Stop")]

namespace YourMvcApplication.App_Start
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            return kernel;
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<DatabaseMonitor>().ToSelf().InSingletonScope();
        }
    }
}



//Global.asax
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using YourNamespace;

namespace YourMvcApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private DatabaseMonitor _databaseMonitor;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Obtenha a instância de DatabaseMonitor a partir do contêiner de DI
            _databaseMonitor = DependencyResolver.Current.GetService<DatabaseMonitor>();
            _databaseMonitor?.Start();
        }

        protected void Application_End()
        {
            _databaseMonitor?.Stop();
        }
    }
}

/*
### Explicação:

-   **`DatabaseMonitor`**: Classe dedicada que realiza a tarefa de monitorar a base de dados em loop infinito em uma thread separada usando `Task.Run` para iniciar a execução de forma assíncrona.
-   **Conexão com o banco**: O código se conecta a um banco de dados SQL, consulta uma tabela e toma uma decisão com base no resultado.
-   **Thread separada**: A execução é feita em uma thread separada para não interferir na execução da thread principal do ASP.NET MVC.
-   **Controle de interrupção**: O `CancellationToken` é usado para encerrar a execução de forma controlada.

Esse código garante que o monitoramento é executado de forma assíncrona e não bloqueia a thread principal.
*/

namespace WebApiTemplate.Services
{
    public class ServiceContinue : IHostedService
    {
        private readonly IWebHostEnvironment _env;
        private readonly string fileName = "archivoconfirmacion.txt";
        private Timer timer;

        public ServiceContinue(IWebHostEnvironment env)
        {
            _env = env;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            WriteOnFile("Proceso iniciado a las: "+ DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "clase ServiceContinues");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer.Dispose();
            WriteOnFile("Proceso finalizadoa las: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "clase ServiceContinues ");
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            WriteOnFile("Proceso en ejecucion: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "clase ServiceContinues");
        }

        //Metodo auxiliar para escribir en el archivo.
        private void WriteOnFile(string message)
        {
            var path = $@"{_env.ContentRootPath}\wwwroot\{fileName}";
            using (StreamWriter writer = new StreamWriter(path,append:true))    //append: true permite agregar al fichero y no sobreescribir
            {
                writer.WriteLine(message);
            }
        }

    }
}

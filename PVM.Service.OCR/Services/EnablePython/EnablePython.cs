using System.ComponentModel.DataAnnotations;
using Python.Runtime;
using System.Diagnostics;


namespace PVM.Service.OCR.Services.EnablePython
{
    public class EnablePython : IEnablePython
    {
        public Task InitializeService()
        {
             try
            {
                // Get the path to the dll Python runtime
                //Runtime.PythonDLL = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @".nuget\packages\python\3.11.5\tools\python311.dll");
                Runtime.PythonDLL = @"C:\Users\Gonzalo Romero\AppData\Local\Programs\Python\Python310\python310.dll";

                // Initialize the Python runtime
                PythonEngine.Initialize();

                return Task.CompletedTask;

            }
            catch (System.TypeInitializationException e)
            {
                throw new Exception($"FATAL, Unable to load Python, dll={Runtime.PythonDLL}", e);
            }
            catch (Exception e)
            {
                throw new Exception($"Python initialization Exception, {e.Message}", e);
            }

            //throw new NotImplementedException();
                 
        }
    }
}

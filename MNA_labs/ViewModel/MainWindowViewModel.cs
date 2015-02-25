using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using Kindruk.lab7.ViewModel;
using MathBase;
using Microsoft.Win32;
using MNA_labs.Model;

namespace MNA_labs.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _inputFile, _outputFile;

        public enum Method
        {
            Gauss, GaussWithSelection, SimpleIterations, Zeidel
        }

        public ObservableCollection<string> Log { get; set; }
        public Method ChoosenMethod { get; set; }

        public string InputFile
        {
            get { return _inputFile; }
            set
            {
                _inputFile = value;
                OnPropertyChanged("InputFile");
            }
        }

        public string OutputFile
        {
            get { return _outputFile; }
            set
            {
                _outputFile = value;
                OnPropertyChanged("OutputFile");
            }
        }

        #region constructors

        public MainWindowViewModel()
        {
            Log = new ObservableCollection<string>();
            InputFile = Directory.GetCurrentDirectory() + @"\lab1.in";
            OutputFile = Directory.GetCurrentDirectory() + @"\lab1.out";
        }

        #endregion

        public ICommand OpenFileDialog
        {
            get { return new RelayCommand(OpenFileDialogExecute);}
        }

        public ICommand SaveFileDialog
        {
            get { return new RelayCommand(SaveFileDialogExecute);}
        }

        public ICommand GaussMethodChoosen
        {
            get { return new RelayCommand(GaussMethodChoosenExecute); }
        }

        public ICommand GaussWithSelectionMethodChoosen
        {
            get { return new RelayCommand(GaussWithSelectionMethodChoosenExecute); }
        }

        public ICommand SimpleIterationsMethodChoosen
        {
            get { return new RelayCommand(SimpleIterationsMethodChoosenExecute); }
        }

        public ICommand ZeidelMethodChoosen
        {
            get { return new RelayCommand(ZeidelMethodChoosenExecute); }
        }

        public ICommand DoAction
        {
            get { return new RelayCommand(DoActionExecute);}
        }

        public void OpenFileDialogExecute()
        {
            var dialog = new OpenFileDialog
            {
                Title = "Open File",
                InitialDirectory = Directory.GetCurrentDirectory(),
                RestoreDirectory = false,
                DefaultExt = "in",
                Filter = "Input files (*.in)|*.in"
            };
            dialog.ShowDialog();
            InputFile = dialog.FileName;
        }

        public void SaveFileDialogExecute()
        {
            var dialog = new SaveFileDialog
            {
                Title = "Save File As",
                InitialDirectory = Directory.GetCurrentDirectory(),
                RestoreDirectory = false,
                DefaultExt = "out",
                Filter = "Output files (*.out)|*.out"
            };
            dialog.ShowDialog();
            OutputFile = dialog.FileName;
        }

        public void GaussMethodChoosenExecute()
        {
            ChoosenMethod = Method.Gauss;
        }

        public void GaussWithSelectionMethodChoosenExecute()
        {
            ChoosenMethod = Method.GaussWithSelection;
        }

        public void SimpleIterationsMethodChoosenExecute()
        {
            ChoosenMethod = Method.SimpleIterations;
        }

        public void ZeidelMethodChoosenExecute()
        {
            ChoosenMethod = Method.Zeidel;
        }

        public void DoActionExecute()
        {
            DoubleMatrix matrix;
            DoubleVector values, answers = new DoubleVector();
            var solutionResult = "Error";
            try
            {
                using (var file = File.OpenRead(InputFile))
                {
                    using (var reader = new StreamReader(file))
                    {
                        SlaeIOManager.LoadSlae(reader, out matrix, out values);
                    }
                }
                Log.Add(string.Format(">>> Loaded data from {0}", InputFile));
                switch (ChoosenMethod)
                {
                    case Method.Gauss:
                        solutionResult = Kindruk.lab1.SlaeSolver.SolveGaussMethod(matrix, values, out answers).ToString();
                        break;
                    case Method.GaussWithSelection:
                        solutionResult = Kindruk.lab1.SlaeSolver.SolveGaussMethodWithSelection(matrix, values, out answers).ToString();
                        break;
                    case Method.SimpleIterations:
                        solutionResult = Kindruk.lab2.SlaeSolver.SimpleIterationMethod(matrix, values, out answers).ToString();
                        break;
                    case Method.Zeidel:
                        solutionResult = Kindruk.lab2.SlaeSolver.ZeidelMethod(matrix, values, out answers).ToString();
                        break;
                }
                Log.Add(string.Format("{0} method result: {1}", ChoosenMethod, solutionResult));
                using (var file = File.OpenWrite(OutputFile))
                {
                    using (var writer = new StreamWriter(file))
                    {
                        SlaeIOManager.SaveAnswer(writer, answers, solutionResult);
                    }
                }
                Log.Add(string.Format("Successfully saved to {0}", OutputFile));
            }
            catch (Exception e)
            {
                Log.Add(e.Message);
            }
        }
    }
}

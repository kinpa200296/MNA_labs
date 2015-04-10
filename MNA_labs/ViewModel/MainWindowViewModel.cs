using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Kindruk.lab3;
using Kindruk.lab4;
using Kindruk.lab5;
using Kindruk.lab7;
using Kindruk.lab7.ViewModel;
using Kindruk.lab8;
using Kindruk.lab9;
using MathBase;
using Microsoft.Win32;
using MNA_labs.Model;

namespace MNA_labs.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _inputFile, _outputFile;
        private double _a, _b, _c, _x, _y, _l, _r, _step, _left, _right, _val, _epsDiff, _epsIntegral, _val8, _left8, _right8, _left9, _right9, _eps9, _a9, _m9, _y09, _left10, _right10, _eps10, _a10, _m10, _y010, _y110;
        private int _nodeCount;

        public enum Method
        {
            Gauss, GaussWithSelection, SimpleIterations, Zeidel
        }

        public enum Method3
        {
            Binary, Newton, Chords
        }

        public enum Method4
        {
            SimpleIterations, Newton
        }

        public enum Function
        {
            Exp, Log, Sinh, Cosh, Atan, Tanh, Tan, Sqrt, Sqrt1, X1
        }

        public enum Method8
        {
            Simpson, Trapezoids, Averages
        }

        public enum Method9
        {
            RungeKutt, Eiler
        }

        #region properties

        public ObservableCollection<string> Log { get; set; }
        public ObservableCollection<string> Log3 { get; set; }
        public ObservableCollection<string> Log4 { get; set; }
        public ObservableCollection<string> Log5 { get; set; }
        public ObservableCollection<string> Log7 { get; set; }
        public ObservableCollection<string> Log8 { get; set; }
        public ObservableCollection<string> Log9 { get; set; }
        public ObservableCollection<string> Log10 { get; set; }
        public Method ChoosenMethod { get; set; }
        public Method3 ChoosenMethod3 { get; set; }
        public Method4 ChoosenMethod4{ get; set; }
        public Function ChoosenFunction { get; set; }
        public Method8 ChoosenMethod8 { get; set; }
        public Method9 ChoosenMethod9 { get; set; }

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

        public double A
        {
            get { return _a; }
            set
            {
                _a = value;
                OnPropertyChanged("A");
            }
        }

        public double B
        {
            get { return _b; }
            set
            {
                _b = value;
                OnPropertyChanged("B");
            }
        }

        public double C
        {
            get { return _c; }
            set
            {
                _c = value;
                OnPropertyChanged("C");
            }
        }

        public double X
        {
            get { return _x; }
            set
            {
                _x = value;
                OnPropertyChanged("X");
            }
        }

        public double Y
        {
            get { return _y; }
            set
            {
                _y = value;
                OnPropertyChanged("Y");
            }
        }

        public double L
        {
            get { return _l; }
            set
            {
                _l = value;
                OnPropertyChanged("L");
            }
        }

        public double R
        {
            get { return _r; }
            set
            {
                _r = value;
                OnPropertyChanged("R");
            }
        }

        public double Step
        {
            get { return _step; }
            set
            {
                _step = value;
                OnPropertyChanged("Step");
            }
        }

        public double Left
        {
            get { return _left; }
            set
            {
                _left = value;
                OnPropertyChanged("Left");
            }
        }

        public double Right
        {
            get { return _right; }
            set
            {
                _right = value;
                OnPropertyChanged("Right");
            }
        }

        public int NodeCount
        {
            get { return _nodeCount; }
            set
            {
                _nodeCount = value;
                OnPropertyChanged("NodeCount");
            }
        }

        public double Val
        {
            get { return _val; }
            set
            {
                _val = value;
                OnPropertyChanged("Val");
            }
        }

        public double EpsDiff
        {
            get { return _epsDiff; }
            set
            {
                _epsDiff = value;
                OnPropertyChanged("EpsDiff");
            }
        }

        public double EpsIntegral
        {
            get { return _epsIntegral; }
            set
            {
                _epsIntegral = value;
                OnPropertyChanged("EpsIntegral");
            }
        }

        public double Left8
        {
            get { return _left8; }
            set
            {
                _left8 = value;
                OnPropertyChanged("Left8");
            }
        }

        public double Right8
        {
            get { return _right8; }
            set
            {
                _right8 = value;
                OnPropertyChanged("Right8");
            }
        }

        public double Val8
        {
            get { return _val8; }
            set
            {
                _val8 = value;
                OnPropertyChanged("Val8");
            }
        }

        public double Left9
        {
            get { return _left9; }
            set
            {
                _left9 = value;
                OnPropertyChanged("Left9");
            }
        }

        public double Right9
        {
            get { return _right9; }
            set
            {
                _right9 = value;
                OnPropertyChanged("Right9");
            }
        }

        public double A9
        {
            get { return _a9; }
            set
            {
                _a9 = value;
                OnPropertyChanged("A9");
            }
        }

        public double M9
        {
            get { return _m9; }
            set
            {
                _m9 = value;
                OnPropertyChanged("M9");
            }
        }

        public double Eps9
        {
            get { return _eps9; }
            set
            {
                _eps9 = value;
                OnPropertyChanged("Eps9");
            }
        }

        public double Y09
        {
            get { return _y09; }
            set
            {
                _y09 = value;
                OnPropertyChanged("Y09");
            }
        }

        public double Left10
        {
            get { return _left10; }
            set
            {
                _left10 = value;
                OnPropertyChanged("Left10");
            }
        }

        public double Right10
        {
            get { return _right10; }
            set
            {
                _right10 = value;
                OnPropertyChanged("Right10");
            }
        }

        public double A10
        {
            get { return _a10; }
            set
            {
                _a10 = value;
                OnPropertyChanged("A10");
            }
        }

        public double M10
        {
            get { return _m10; }
            set
            {
                _m10 = value;
                OnPropertyChanged("M10");
            }
        }

        public double Eps10
        {
            get { return _eps10; }
            set
            {
                _eps10 = value;
                OnPropertyChanged("Eps10");
            }
        }

        public double Y010
        {
            get { return _y010; }
            set
            {
                _y010 = value;
                OnPropertyChanged("Y010");
            }
        }

        public double Y110
        {
            get { return _y110; }
            set
            {
                _y110 = value;
                OnPropertyChanged("Y110");
            }
        }

        #endregion

        #region constructors

        public MainWindowViewModel()
        {
            Log = new ObservableCollection<string>();
            Log3 = new ObservableCollection<string>();
            Log4 = new ObservableCollection<string>();
            Log5 = new ObservableCollection<string>();
            Log7 = new ObservableCollection<string>();
            Log8 = new ObservableCollection<string>();
            Log9 = new ObservableCollection<string>();
            Log10 = new ObservableCollection<string>();
            InputFile = Directory.GetCurrentDirectory() + @"\lab1.in";
            OutputFile = Directory.GetCurrentDirectory() + @"\lab1.out";
            A = 2.65804;
            B = -28.0640;
            C = 21.9032;
            X = SnleSolver.InitialSolution[0];
            Y = SnleSolver.InitialSolution[1];
            L = -10;
            R = 10;
            Step = 0.01;
            ChoosenFunction = Function.Sqrt1;
            Left = 1;
            Right = 3;
            Val = 1;
            NodeCount = 6;
            EpsDiff = 0.01;
            EpsIntegral = 1e-6;
            Left8 = 1;
            Right8 = 2;
            Val8 = 1.5;
            Left9 = 0;
            Right9 = 1;
            Y09 = 0;
            A9 = 1.1;
            M9 = 2.0;
            Eps9 = 0.001;
            Left10 = 0;
            Right10 = 1;
            Y010 = 0;
            Y110 = 0.034722;
            A10 = 1.1;
            M10 = 2.0;
            Eps10 = 0.001;
        }

        #endregion

        #region commands

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

        public ICommand DoAction3
        {
            get { return new RelayCommand(DoAction3Execute); }
        }

        public ICommand DoAction4
        {
            get { return new RelayCommand(DoAction4Execute); }
        }

        public ICommand DoAction5
        {
            get { return new RelayCommand(DoAction5Execute); }
        }

        public ICommand NleBinaryMethodChoosen
        {
            get { return new RelayCommand(NleBinaryMethodChoosenExecute); }
        }

        public ICommand NleChordsMethodChoosen
        {
            get { return new RelayCommand(NleChordsMethodChoosenExecute); }
        }

        public ICommand NleNewtonMethodChoosen
        {
            get { return new RelayCommand(NleNewtonMethodChoosenExecute); }
        }

        public ICommand SnleNewtonMethodChoosen
        {
            get { return new RelayCommand(SnleNewtonMethodChoosenExecute); }
        }

        public ICommand SnleSimpleIterationsMethodChoosen
        {
            get { return new RelayCommand(SnleSimpleIterationsMethodChoosenExecute); }
        }

        public ICommand DoAction7
        {
            get { return new RelayCommand(DoAction7Execute); }
        }

        public ICommand AtanFunctionChoosen
        {
            get { return new RelayCommand(AtanFunctionChoosenExecute); }
        }

        public ICommand CoshFunctionChoosen
        {
            get { return new RelayCommand(CoshFunctionChoosenExecute); }
        }

        public ICommand LogFunctionChoosen
        {
            get { return new RelayCommand(LogFunctionChoosenExecute); }
        }

        public ICommand ExpFunctionChoosen
        {
            get { return new RelayCommand(ExpFunctionChoosenExecute); }
        }

        public ICommand SinhFunctionChoosen
        {
            get { return new RelayCommand(SinhFunctionChoosenExecute); }
        }

        public ICommand SqrtFunctionChoosen
        {
            get { return new RelayCommand(SqrtFunctionChoosenExecute); }
        }

        public ICommand Sqrt1FunctionChoosen
        {
            get { return new RelayCommand(Sqrt1FunctionChoosenExecute); }
        }

        public ICommand TanFunctionChoosen
        {
            get { return new RelayCommand(TanFunctionChoosenExecute); }
        }

        public ICommand TanhFunctionChoosen
        {
            get { return new RelayCommand(TanhFunctionChoosenExecute); }
        }

        public ICommand X1FunctionChoosen
        {
            get { return new RelayCommand(X1FunctionChoosenExecute); }
        }

        public ICommand DoAction8
        {
            get { return new RelayCommand(DoAction8Execute); }
        }

        public ICommand ChoosenSimpsonMethod
        {
            get { return new RelayCommand(ChoosenSimpsonMethodExecute); }
        }

        public ICommand ChoosenAveragesMethod
        {
            get { return new RelayCommand(ChoosenAveragesMethodExecute); }
        }

        public ICommand ChoosenTrapezoidsMethod
        {
            get { return new RelayCommand(ChoosenTrapezoidsMethodExecute); }
        }

        public ICommand DoAction9
        {
            get { return new RelayCommand(DoAction9Execute); }
        }

        public ICommand RungeKuttMethodChoosen
        {
            get { return new RelayCommand(RungeKuttMehodChoosenExecute); }
        }

        public ICommand EilerMethodChoosen
        {
            get { return new RelayCommand(EilerMehodChoosenExecute); }
        }

        public ICommand DoAction10
        {
            get { return new RelayCommand(DoAction10Execute); }
        }

        #endregion

        #region methods

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
                using (var file = File.Create(OutputFile))
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

        public void NleBinaryMethodChoosenExecute()
        {
            ChoosenMethod3 = Method3.Binary;
        }

        public void NleChordsMethodChoosenExecute()
        {
            ChoosenMethod3 = Method3.Chords;
        }

        public void NleNewtonMethodChoosenExecute()
        {
            ChoosenMethod3 = Method3.Newton;
        }

        public void SnleNewtonMethodChoosenExecute()
        {
            ChoosenMethod4 = Method4.Newton;
        }

        public void SnleSimpleIterationsMethodChoosenExecute()
        {
            ChoosenMethod4 = Method4.SimpleIterations;
        }

        public void DoAction3Execute()
        {
            Log3.Clear();
            Log3.Add(string.Format("Solving equation x^3 + ({0})*x^2 + ({1})*x + ({2}) = 0",
                A.ToString(CultureInfo.InvariantCulture), B.ToString(CultureInfo.InvariantCulture),
                C.ToString(CultureInfo.InvariantCulture)));
            var polynom = new Polynom(new[] {C, B, A, 1});
            Log3.Add(string.Format("{0} method is choosen", ChoosenMethod3));
            Log3.Add(string.Format("Shturm root count: {0}", NleSolver.ShturmRootCount(polynom, L, R)));
            var roots = NleSolver.FindRoots(polynom, L, R, Step);
            foreach (var root in roots)
            {
                Log3.Add(string.Format("Root found on interval [{0}; {1}]", root.ToString(CultureInfo.InvariantCulture),
                    (root + Step).ToString(CultureInfo.InvariantCulture)));
            }
            for (var i = 0; i < roots.Length; i++)
            {
                switch (ChoosenMethod3)
                {
                    case Method3.Binary:
                        Log3.Add(string.Format("x{0} = {1}", i,
                            NleSolver.FindRootBinarySearchMethod(polynom, roots[i], Step)
                                .ToString(CultureInfo.InvariantCulture)));
                        break;
                    case Method3.Chords:
                        Log3.Add(string.Format("x{0} = {1}", i,
                            NleSolver.FindRootChordsMethod(polynom, roots[i], Step)
                                .ToString(CultureInfo.InvariantCulture)));
                        break;
                    case Method3.Newton:
                        Log3.Add(string.Format("x{0} = {1}", i,
                            NleSolver.FindRootNewtonMethod(polynom, roots[i]).ToString(CultureInfo.InvariantCulture)));
                        break;
                }
            }
        }

        public void DoAction4Execute()
        {
            Log4.Clear();
            Log4.Add(string.Format("{0} method choosen", ChoosenMethod4));
            Log4.Add(string.Format("Initial value by x: {0}", X.ToString(CultureInfo.InvariantCulture)));
            Log4.Add(string.Format("Initial value by y: {0}", Y.ToString(CultureInfo.InvariantCulture)));
            SnleSolver.InitialSolution = new[] {X, Y};
            var result = new DoubleVector();
            switch (ChoosenMethod4)
            {
                case Method4.SimpleIterations:
                    result = SnleSolver.SolveWithSimpleIterationsMethod(SnleSolver.Phi);
                    break;
                case Method4.Newton:
                    result = SnleSolver.SolveWithNewtonMethod(SnleSolver.F, SnleSolver.J);
                    break;
            }
            Log4.Add(string.Format("x = {0}", result[0].ToString(CultureInfo.InvariantCulture)));
            Log4.Add(string.Format("y = {0}", result[1].ToString(CultureInfo.InvariantCulture)));
        }

        public void DoAction5Execute()
        {
            DoubleMatrix matrix, eigenVectors;
            DoubleVector eigenValues;
            try
            {
                using (var file = File.OpenRead(InputFile))
                {
                    using (var reader = new StreamReader(file))
                    {
                        matrix = MatrixIoManager.LoadMatrix(reader);
                    }
                }
                Log5.Add(string.Format(">>> Loaded data from {0}", InputFile));
                EigenSolver.FindEigenValues(matrix, out eigenVectors, out eigenValues);
                Log5.Add("Successfully solved!");
                using (var file = File.Create(OutputFile))
                {
                    using (var writer = new StreamWriter(file))
                    {
                        writer.WriteLine("Eigen values:");
                        VectorIoManager.SaveVector(writer, eigenValues);
                        writer.WriteLine("Eigen vectors:");
                        for (var i = 0; i < eigenVectors.ColumnCount; i++)
                        {
                            VectorIoManager.SaveVector(writer, eigenVectors.GetVerticalVector(i));
                        }
                    }
                }
                Log5.Add(string.Format("Successfully saved to {0}", OutputFile));
            }
            catch (Exception e)
            {
                Log5.Add(e.Message);
            }
        }

        public void ExpFunctionChoosenExecute()
        {
            ChoosenFunction = Function.Exp;
        }

        public void AtanFunctionChoosenExecute()
        {
            ChoosenFunction = Function.Atan;
        }

        public void CoshFunctionChoosenExecute()
        {
            ChoosenFunction = Function.Cosh;
        }

        public void LogFunctionChoosenExecute()
        {
            ChoosenFunction = Function.Log;
        }

        public void SinhFunctionChoosenExecute()
        {
            ChoosenFunction = Function.Sinh;
        }

        public void SqrtFunctionChoosenExecute()
        {
            ChoosenFunction = Function.Sqrt;
        }

        public void Sqrt1FunctionChoosenExecute()
        {
            ChoosenFunction = Function.Sqrt1;
        }

        public void TanFunctionChoosenExecute()
        {
            ChoosenFunction = Function.Tan;
        }

        public void TanhFunctionChoosenExecute()
        {
            ChoosenFunction = Function.Tanh;
        }

        public void X1FunctionChoosenExecute()
        {
            ChoosenFunction = Function.X1;
        }

        public void DoAction7Execute()
        {
            Log7.Clear();
            try
            {
                var cubicSpline = new CubicSpline(0);
                switch (ChoosenFunction)
                {
                    case Function.Atan:
                        Log7.Add(
                            String.Format("Building cubic spline for function y(x) = arctg(x) on interval [{0}; {1}]",
                                Left.ToString("F6", CultureInfo.InvariantCulture),
                                Right.ToString("F6", CultureInfo.InvariantCulture)));
                        cubicSpline = CubicSpline.Build(Left, Right, NodeCount, x => Math.Atan(x));
                        break;
                    case Function.Cosh:
                        Log7.Add(
                            String.Format("Building cubic spline for function y(x) = ch(x) on interval [{0}; {1}]",
                                Left.ToString("F6", CultureInfo.InvariantCulture),
                                Right.ToString("F6", CultureInfo.InvariantCulture)));
                        cubicSpline = CubicSpline.Build(Left, Right, NodeCount, x => Math.Cosh(x));
                        break;
                    case Function.Exp:
                        Log7.Add(
                            String.Format("Building cubic spline for function y(x) = e^(-x) on interval [{0}; {1}]",
                                Left.ToString("F6", CultureInfo.InvariantCulture),
                                Right.ToString("F6", CultureInfo.InvariantCulture)));
                        cubicSpline = CubicSpline.Build(Left, Right, NodeCount, x => Math.Exp(-x));
                        break;
                    case Function.Log:
                        Log7.Add(
                            String.Format("Building cubic spline for function y(x) = ln(x) on interval [{0}; {1}]",
                                Left.ToString("F6", CultureInfo.InvariantCulture),
                                Right.ToString("F6", CultureInfo.InvariantCulture)));
                        cubicSpline = CubicSpline.Build(Left, Right, NodeCount, x => Math.Log(x));
                        break;
                    case Function.Sinh:
                        Log7.Add(
                            String.Format("Building cubic spline for function y(x) = sh(x) on interval [{0}; {1}]",
                                Left.ToString("F6", CultureInfo.InvariantCulture),
                                Right.ToString("F6", CultureInfo.InvariantCulture)));
                        cubicSpline = CubicSpline.Build(Left, Right, NodeCount, x => Math.Sinh(x));
                        break;
                    case Function.Sqrt:
                        Log7.Add(
                            String.Format("Building cubic spline for function y(x) = x^(-1/2) on interval [{0}; {1}]",
                                Left.ToString("F6", CultureInfo.InvariantCulture),
                                Right.ToString("F6", CultureInfo.InvariantCulture)));
                        cubicSpline = CubicSpline.Build(Left, Right, NodeCount, x => Math.Sqrt(x));
                        break;
                    case Function.Sqrt1:
                        Log7.Add(
                            String.Format("Building cubic spline for function y(x) = 1/x^(1/2) on interval [{0}; {1}]",
                                Left.ToString("F6", CultureInfo.InvariantCulture),
                                Right.ToString("F6", CultureInfo.InvariantCulture)));
                        cubicSpline = CubicSpline.Build(Left, Right, NodeCount, x => 1.0 / Math.Sqrt(x));
                        break;
                    case Function.Tan:
                        Log7.Add(
                            String.Format("Building cubic spline for function y(x) = tg(x) on interval [{0}; {1}]",
                                Left.ToString("F6", CultureInfo.InvariantCulture),
                                Right.ToString("F6", CultureInfo.InvariantCulture)));
                        cubicSpline = CubicSpline.Build(Left, Right, NodeCount, x => Math.Tan(x));
                        break;
                    case Function.Tanh:
                        Log7.Add(
                            String.Format("Building cubic spline for function y(x) = th(x) on interval [{0}; {1}]",
                                Left.ToString("F6", CultureInfo.InvariantCulture),
                                Right.ToString("F6", CultureInfo.InvariantCulture)));
                        cubicSpline = CubicSpline.Build(Left, Right, NodeCount, x => Math.Tanh(x));
                        break;
                    case Function.X1:
                        Log7.Add(
                            String.Format("Building cubic spline for function y(x) = 1/x on interval [{0}; {1}]",
                                Left.ToString("F6", CultureInfo.InvariantCulture),
                                Right.ToString("F6", CultureInfo.InvariantCulture)));
                        cubicSpline = CubicSpline.Build(Left, Right, NodeCount, x => 1.0 / x);
                        break;
                }
                Log7.Add(string.Format("Value of cubic spline at x = {0}  :  {1}",
                    Val.ToString("F6", CultureInfo.InvariantCulture),
                    cubicSpline.Calculate(Val).ToString("F6", CultureInfo.InvariantCulture)));
                Log7.Add("Splines:");
                for (var i = 0; i < cubicSpline.Count; i++)
                {
                    var builder =
                        new StringBuilder(string.Format("[{0}; {1}]: ",
                            cubicSpline[i].Left.ToString("F6", CultureInfo.InvariantCulture),
                            cubicSpline[i].Right.ToString("F6", CultureInfo.InvariantCulture)));
                    builder.Append(Math.Abs(cubicSpline[i].A) > 1e-12
                        ? string.Format("{0} + ", cubicSpline[i].A.ToString("F6", CultureInfo.InvariantCulture))
                        : "");
                    builder.Append(Math.Abs(cubicSpline[i].B) > 1e-12
                        ? string.Format("{0}*(x - {1}) + ",
                            cubicSpline[i].B.ToString("F6", CultureInfo.InvariantCulture),
                            cubicSpline[i].Left.ToString("F6", CultureInfo.InvariantCulture))
                        : "");
                    builder.Append(Math.Abs(cubicSpline[i].C) > 1e-12
                        ? string.Format("{0}*(x - {1})^2 + ",
                            cubicSpline[i].C.ToString("F6", CultureInfo.InvariantCulture),
                            cubicSpline[i].Left.ToString("F6", CultureInfo.InvariantCulture))
                        : "");
                    builder.Append(Math.Abs(cubicSpline[i].D) > 1e-12
                        ? string.Format("{0}*(x - {1})^3",
                            cubicSpline[i].D.ToString("F6", CultureInfo.InvariantCulture),
                            cubicSpline[i].Left.ToString("F6", CultureInfo.InvariantCulture))
                        : "");
                    Log7.Add(builder.ToString());
                }
            }
            catch (Exception e)
            {
                Log7.Add(e.Message);
            }
        }

        public void ChoosenSimpsonMethodExecute()
        {
            ChoosenMethod8 = Method8.Simpson;
        }

        public void ChoosenTrapezoidsMethodExecute()
        {
            ChoosenMethod8 = Method8.Trapezoids;
        }

        public void ChoosenAveragesMethodExecute()
        {
            ChoosenMethod8 = Method8.Averages;
        }

        public void DoAction8Execute()
        {
            Log8.Clear();
            try
            {
                var func = new Func<double, double>(x => Math.Cos(x)/x);
                Log8.Add("f(x) = cos(x)/x");
                Log8.Add(string.Format("f'({0}) = {1}", Val8.ToString("F6", CultureInfo.InvariantCulture),
                    FunctionCalculator.CalculateFirstDerivative(Val8, EpsDiff, func)
                        .ToString("F6", CultureInfo.InvariantCulture)));
                Log8.Add(string.Format("f''({0}) = {1}", Val8.ToString("F6", CultureInfo.InvariantCulture),
                    FunctionCalculator.CalculateSecondDerivative(Val8, EpsDiff, func)
                        .ToString("F6", CultureInfo.InvariantCulture)));
                Log8.Add(string.Format("Integrating with {0} method on inteval [{1}; {2}]", ChoosenMethod8,
                    Left8.ToString("F6", CultureInfo.InvariantCulture),
                    Right8.ToString("F6", CultureInfo.InvariantCulture)));
                switch (ChoosenMethod8)
                {
                    case Method8.Simpson:
                        Log8.Add(string.Format("result = {0}",
                            FunctionCalculator.IntegrateSimpsonMethod(Left8, Right8, EpsIntegral, func)
                                .ToString("F6", CultureInfo.InvariantCulture)));
                        break;
                    case Method8.Averages:
                        Log8.Add(string.Format("result = {0}",
                            FunctionCalculator.IntegrateAveragesMethod(Left8, Right8, EpsIntegral, func)
                                .ToString("F6", CultureInfo.InvariantCulture)));
                        break;
                    case Method8.Trapezoids:
                        Log8.Add(string.Format("result = {0}",
                            FunctionCalculator.IntegrateTrapezoidsMethod(Left8, Right8, EpsIntegral, func)
                                .ToString("F6", CultureInfo.InvariantCulture)));
                        break;
                }

            }
            catch (Exception e)
            {
                Log8.Add(e.Message);
            }
        }

        public void RungeKuttMehodChoosenExecute()
        {
            ChoosenMethod9 = Method9.RungeKutt;
        }

        public void EilerMehodChoosenExecute()
        {
            ChoosenMethod9 = Method9.Eiler;
        }

        public void DoAction9Execute()
        {
            Log9.Clear();
            try
            {
                Log9.Add(string.Format("Solving differential equation with {2} method on interval [{0}; {1}]",
                    Left9.ToString("F6", CultureInfo.InvariantCulture),
                    Right9.ToString("F6", CultureInfo.InvariantCulture), ChoosenMethod9));
                Log9.Add(string.Format("y'(x) = {0}*(1 - y^2)/((1 + {1})x^2 + y^2 + 1)",
                    A9.ToString("F6", CultureInfo.InvariantCulture), M9.ToString("F6", CultureInfo.InvariantCulture)));
                Log9.Add(string.Format("y0 = {0}", Y09.ToString("F6", CultureInfo.InvariantCulture)));
                var xVector = new DoubleVector();
                var yVector = new DoubleVector();
                switch (ChoosenMethod9)
                {
                    case Method9.Eiler:
                        DeSolver.EilerMethod(Left9, Right9, Eps9, (x, y) => A9*(1 - y*y)/((1 + M9)*x*x + y*y + 1),
                            out xVector, out yVector, Y09);
                        break;
                    case Method9.RungeKutt:
                        DeSolver.RungeKuttMethod(Left9, Right9, Eps9, (x, y) => A9*(1 - y*y)/((1 + M9)*x*x + y*y + 1),
                            out xVector, out yVector, Y09);
                        break;
                }
                foreach (
                    var item in
                        xVector.Select(
                            (x, i) =>
                                string.Format("x = {0}; y = {1}", x.ToString("F6", CultureInfo.InvariantCulture),
                                    yVector[i].ToString("F6", CultureInfo.InvariantCulture))))
                {
                    Log9.Add(item);
                }
            }
            catch (Exception e)
            {
                Log9.Add(e.Message);
            }
        }

        public void DoAction10Execute()
        {
            Log10.Clear();
            try
            {
                Log10.Add(string.Format("Solving differential equation with Adams method on interval [{0}; {1}]",
                    Left10.ToString("F6", CultureInfo.InvariantCulture),
                    Right10.ToString("F6", CultureInfo.InvariantCulture)));
                Log10.Add(string.Format("y'(x) = {0}*(1 - y^2)/((1 + {1})x^2 + y^2 + 1)",
                    A10.ToString("F6", CultureInfo.InvariantCulture), M10.ToString("F6", CultureInfo.InvariantCulture)));
                Log10.Add(string.Format("y0 = {0}", Y010.ToString("F6", CultureInfo.InvariantCulture)));
                DoubleVector xVector, yVector;
                Kindruk.lab10.DeSolver.AdamsMethod(Left10, Right10, Eps10,
                    (x, y) => A10*(1 - y*y)/((1 + M10)*x*x + y*y + 1),
                    out xVector, out yVector, Y010, Y110);
                foreach (
                    var item in
                        xVector.Select(
                            (x, i) =>
                                string.Format("x = {0}; y = {1}", x.ToString("F6", CultureInfo.InvariantCulture),
                                    yVector[i].ToString("F6", CultureInfo.InvariantCulture))))
                {
                    Log10.Add(item);
                }
            }
            catch (Exception e)
            {
                Log10.Add(e.Message);
            }
        }

        #endregion
    }
}

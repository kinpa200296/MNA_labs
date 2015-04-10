using System;
using System.Collections.Generic;
using System.Linq;

namespace Kindruk.lab7
{
    public class CubicSpline
    {
        private Spline[] _splines;

        public CubicSpline(int n)
        {
            _splines = new Spline[n];
            for (var i = 0; i < n; i++)
            {
                _splines[i] = new Spline();
            }
        }

        public CubicSpline(IEnumerable<Spline> data)
        {
            _splines = data.ToArray();
        }

        public int Count
        {
            get { return _splines.Length; }
        }

        public Spline this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException("index", "Index of inner Spline is invalid.");
                }
                return _splines[index];
            }
        }

        public static CubicSpline Build(double left, double right, int n, Func<double, double> f)
        {
            var res = new Spline[n + 1];
            for (var i = 0; i <= n; i++)
            {
                res[i] = new Spline();
            }
            var h = (right - left)/n;
            var x = new double[n + 1];
            var y = new double[n + 1];
            for (var i = 0; i <= n; i++)
            {
                x[i] = left + i*h;
                y[i] = f(x[i]);
            }
            for (var i = 0; i < n; i++)
            {
                res[i].A = y[i];
                res[i].Left = x[i];
                res[i].Right = x[i + 1];
            }
            res[0].C = 0;
            res[n].C = 0;
            var alpha = new double[n];
            var beta = new double[n];
            for (var i = 1; i < n; i++)
            {
                var hi = x[i] - x[i - 1];
                var hi1 = x[i + 1] - x[i];
                var a = hi/3;
                var b = 2.0/3.0*(hi + hi1);
                var c = hi1/3.0;
                var d = (y[i + 1] - y[i])/hi1 - (y[i] - y[i - 1])/h;
                alpha[i] = -c/(a*alpha[i - 1] + b);
                beta[i] = (d - a*beta[i - 1])/(a*alpha[i - 1] + b);
            }
            for (var i = n-1; i >= 0; i--)
            {
                res[i].C = alpha[i]*res[i + 1].C + beta[i];
            }
            for (var i = n-1; i >= 0; i--)
            {
                var hi = x[i] - x[i + 1];
                res[i].D = (res[i].C - res[i + 1].C)/hi;
                res[i].B = hi * (2.0 * res[i].C + res[i + 1].C) / 6.0 + (y[i] - y[i + 1]) / hi;
            }
            return new CubicSpline(res.Where((q, i) => i != n));
        }

        public double Calculate(double x)
        {
            if (_splines == null)
                return double.NaN;
            var num = -1;
            if (x < _splines[0].Left)
                throw new ArgumentOutOfRangeException("x", "CubicSpline is not builded for this value");
            if (x > _splines[Count - 1].Right)
                throw new ArgumentOutOfRangeException("x", "CubicSpline is not builded for this value");
            for (var i = 0; i < Count; i++)
            {
                if (x >= _splines[i].Left && x <= _splines[i].Right)
                {
                    num = i;
                }
            }
            return this[num].Calculate(x);
        }
    }
}

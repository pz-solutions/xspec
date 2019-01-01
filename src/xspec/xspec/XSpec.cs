using System;
using System.Collections.Generic;
using System.Linq;

namespace xspec
{
    public abstract class Spec
    {
        private Stack<DescribeScope> _scopes = new Stack<DescribeScope>(new[] { new DescribeScope() });
        public DescribeScope CurrentScope => _scopes.Peek();
        public List<Test> Tests { get; } = new List<Test>();


        public void RunAll()
        {
            this.Run(this.Tests);
        }
        private void Run(IEnumerable<Test> t)
        {
            Test[] tests = t.ToArray();
            this.InvokeAll(tests.SelectMany(o => o.BeforeAlls));
            foreach (var test in tests)
            {
                try
                {
                    InvokeAll(test.BeforeEaches);
                    test.Action();
                    InvokeAll(test.AfterEaches);
                }
                catch (Exception e)
                {
                    Console.WriteLine(string.Join(" / ", test.Descriptions) + " / " + test.Description);
                    Console.WriteLine(e);
                }

            }
            this.InvokeAll(tests.SelectMany(o => o.AfterAlls));

        }

        protected void Describe(string description, Action action)
        {
            _scopes.Push(new DescribeScope() { Description = description });
            action();
            _scopes.Pop();

        }

        private void InvokeAll(IEnumerable<Action> actions)
        {
            foreach (var action in actions)
            {
                action();
            }
        }

        protected void Test(string someAssertion, Action action)
        {
            this.Tests.Add(new Test()
            {
                Action = action,
                DescribeScopes = this._scopes.ToList(),
                Description = someAssertion,
                Descriptions = this._scopes.Select(o => o.Description).ToArray(),
                BeforeEaches = this._scopes.SelectMany(o => o.BeforeEaches).ToArray(),
                AfterEaches = this._scopes.SelectMany(o => o.AfterEaches).ToArray(),
            });
        }

        protected void AfterEach(Action action)
        {
            this.CurrentScope.AfterEaches.Add(action);
        }

        protected void BeforeEach(Action action)
        {
            this.CurrentScope.BeforeEaches.Add(action);
        }

        protected void AfterAll(Action action)
        {
            this.CurrentScope.AfterAlls.Add(action);
        }

        protected void BeforeAll(Action action)
        {
            this.CurrentScope.BeforeAlls.Add(action);
        }
    }
}
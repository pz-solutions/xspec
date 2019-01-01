using System;

namespace xspec
{
    public class SomeXSpec : Spec
    {
        private Random random = new Random();

        public SomeXSpec()
        {
            var n = random.Next(100);
            this.BeforeAll(() =>
            {
                n = random.Next(100);
                Console.WriteLine(n);
            });

            this.AfterAll(() =>
            {

                Console.WriteLine(n);
            });

            this.BeforeEach(() =>
            {
                n = random.Next(100);
                Console.WriteLine(n);
            });

            this.AfterEach(() =>
            {
                Console.WriteLine(n);
            });

            this.Test("some assertion", () =>
            {
                Console.WriteLine(n);
            });

            this.Describe("asd asd", () =>
            {
                this.BeforeAll(() =>
                {
                    n = random.Next(100);
                    Console.WriteLine(n);
                });

                this.AfterAll(() =>
                {

                    Console.WriteLine(n);
                });

                this.BeforeEach(() =>
                {
                    n = random.Next(100);
                    Console.WriteLine(n);
                });

                this.AfterEach(() =>
                {
                    Console.WriteLine(n);
                });

                this.Test("Vienna <3 sausage", () =>
                {
                    Console.WriteLine(n);
                });

                this.Test("San Juan <3 plantains", () =>
                {
                    Console.WriteLine(n);
                });
            });
        }
    }
}
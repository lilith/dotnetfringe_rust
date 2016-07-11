using System;
using System.Runtime.InteropServices;
using Xunit;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;
using BenchmarkDotNet.Attributes;


namespace ConsoleApplication
{
    public class Program
    {

        [DllImport("libhellorust")]
        public static extern bool in_portland();

        [DllImport("libhellorust")]
        public static extern long rust_factorial(long n);

        public static long factorial(long n){
            long val = 1;
            for (long i = 2; i <= n; i++){
                val *= i;
            }
            return val;
        }


        [Theory] 
        [InlineData(0, 1)] 
        [InlineData(1, 1)] 
        [InlineData(8, 40320)] 
        public void TestFactorial_cs(int value, int expected_result) 
        { 
            Assert.Equal(expected_result, factorial(value)); 
        } 

        [Theory] 
        [InlineData(0, 1)] 
        [InlineData(1, 1)] 
        [InlineData(8, 40320)] 
        public void TestFactorial_rust(int value, int expected_result) 
        { 
            Assert.Equal(expected_result, rust_factorial(value)); 
        } 

        [Benchmark]
        public long BenchmarkRust() 
        { 
            return rust_factorial(10000000); 
        } 
        [Benchmark]
        public long BenchmarkCSharp() 
        { 
            return factorial(10000000); 
        } 

        [Fact]
        public void RunBenchmarks(){
            var summary = BenchmarkRunner.Run<Program>();
            Console.WriteLine(summary);
        }

        public void TestPortland(int value, int expected_result) 
        { 
            Assert.Equal(in_portland(), true); 
        } 
    }

}

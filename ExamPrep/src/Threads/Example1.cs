using System;
using System.Threading;

public static void ThreadMethod1()
{
	for (int i = 0; i < 5; i++)
	{
		Console.WriteLine("ThreadProc: {0}", i);
		Thread.Sleep(1);
	}
}

public static void ThreadMethod(object who) // string would be nicer, but parameterizedThreadStart needs object
{
	for (int i = 0; i < 10; i++)
	{
		Console.WriteLine("ThreadProc: {0} {1}", who,i);
		Thread.Sleep(1);
	}
}


Thread t1 = new Thread( ThreadMethod1); // can create a thread from a method
t1.Start();

Thread t2 = new Thread( () => ThreadMethod("two")); // or a lambda
t2.IsBackground=true; // if it's a background thread, program can terminate before the thread
t2.Start();

Thread t3 = new Thread( new ParameterizedThreadStart(ThreadMethod)); // or ParameterizedThreadStart
t3.IsBackground=true; // notice background
t3.Start("three");

for (int i = 0; i < 5; i++)
{
	Console.WriteLine("Main thread: Do some work.");
	Thread.Sleep(1);
}
// could do things like
//t1.Join();

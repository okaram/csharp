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

public static void ThreadMethod(object who) // string would be nicer, but ParameterizedThreadStart needs object
{
	for (int i = 0; i < 10; i++)
	{
		Console.WriteLine("ThreadProc: {0} {1}", who,i);
		Thread.Sleep(1);
	}
}



// instead of
// Thread t2 = new Thread( () => ThreadMethod("two")); 
for (int i = 0; i < 10; i++) {
	ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadMethod),i); // notice we need to pass the i, or it may get captured
}
for (int i = 0; i < 5; i++)
{
	Console.WriteLine("Main thread: Do some work.");
	Thread.Sleep(1);
}

Thread.Sleep(100); // to let all threads in the pool finish
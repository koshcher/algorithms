using Lab4;

Console.WriteLine("Stack");
var stack = new RomanStack<int>();
Track.Add("Push", stack.Push, 4);
Track.Add("Push", stack.Push, 1);
Track.Add("Push", stack.Push, 3);
Track.Remove<int>("Pop", stack.TryPop);
Track.Add("Push", stack.Push, 8);
Track.Remove<int>("Pop", stack.TryPop);

Console.WriteLine();

Console.WriteLine("Queue");
var queue = new RomanQueue<int>();
Track.Add("Enqueue", queue.Enqueue, 4);
Track.Add("Enqueue", queue.Enqueue, 1);
Track.Add("Enqueue", queue.Enqueue, 3);
Track.Remove<int>("Dequeue", queue.TryDequeue);
Track.Add("Enqueue", queue.Enqueue, 8);
Track.Remove<int>("Dequeue", queue.TryDequeue);
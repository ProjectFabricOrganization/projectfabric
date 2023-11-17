// Using start
using ProjectFabric.Pipeline;

// Read pipeline
var pipeline = new Pipeline();
Console.WriteLine(pipeline);

// Startup pipeline
var result = pipeline.Run();
Console.WriteLine(result);

// End
Console.Read();
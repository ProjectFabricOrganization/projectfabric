namespace ProjectFabric.Pipeline;

internal sealed class RunPipelineResult
{
    public string Customer { get; set; }

    public CustomerType CustomerType { get; set; }

    public string Artifact { get; set; }

    public bool IsCompleted { get; set; }

    public decimal Value { get; set; }

    public override string ToString()
    {
        return $"Run Pipeline result:\n" +
               $"Customer: {Customer}\n" +
               $"Customer type: {CustomerType}\n" +
               $"Artifact: {Artifact}\n" +
               $"IsCompleted: {IsCompleted}\n" +
               $"Value: {Value}\n";
    }
}
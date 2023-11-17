using System.Xml.Serialization;

namespace ProjectFabric.Pipeline;

internal sealed class Pipeline
{
    private readonly string _name;
    private readonly Dictionary<string, UserObject> _userObjects;
    private readonly Dictionary<string, MxCell> _mxCells;
    private readonly string _xml;

    public Pipeline(string xml = "StartupFactory.drawio")
    {
        _xml = xml;
        if (!File.Exists(xml)) throw new Exception("File not exist");
        using var fs = File.Open(_xml, FileMode.Open);
        var serializer = new XmlSerializer(typeof(Mxfile));
        var mxFile = (Mxfile)serializer.Deserialize(fs)!;

        _name = xml.Replace(".drawio", "");
        _userObjects = mxFile.Diagram.MxGraphModel.Root.UserObject.ToDictionary(x => x.Id);
    }

    public RunPipelineResult Run()
    {
        //foreach (var userObject in _userObjects.Values)
        //    Console.WriteLine($"User object: {userObject.Label}\nTooltip: {userObject.Tooltip}\n");

        var customer = _userObjects.Values.FirstOrDefault(x => x.Label == "Customer");
        var customerTooltip = customer.Tooltip.Split('\n');
        var customerType = Enum.Parse<CustomerType>(customerTooltip.First().Replace("Type: ", ""));
        var customerName = customerTooltip.Last();
        var artifact = $"C:\\Users\\DeLL\\Downloads\\Startups\\{customerType}\\{customerName}\\{_name}";

        // result
        return new RunPipelineResult
        {
            Customer = customerName,
            CustomerType = customerType,
            Artifact = artifact,
            IsCompleted = true,
            Value = default
        };
    }

    public override string ToString()
    {
        return $"{nameof(Pipeline)}\n" +
               $"Source pipeline: {_xml}\n" +
               $"{string.Join('\n', _userObjects.Select(x => $"{x.Value.Label}: {x.Value.Tooltip}\n"))}";
    }
}
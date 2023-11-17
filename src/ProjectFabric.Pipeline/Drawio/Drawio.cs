using System.Xml.Serialization;

[XmlRoot(ElementName = "mxCell")]
public class MxCell
{

    [XmlAttribute(AttributeName = "id")]
    public string Id { get; set; }

    [XmlAttribute(AttributeName = "parent")]
    public int Parent { get; set; }

    [XmlElement(ElementName = "mxGeometry")]
    public MxGeometry MxGeometry { get; set; }

    [XmlAttribute(AttributeName = "style")]
    public string Style { get; set; }

    [XmlAttribute(AttributeName = "vertex")]
    public int Vertex { get; set; }

    [XmlAttribute(AttributeName = "value")]
    public string Value { get; set; }

    [XmlAttribute(AttributeName = "tooltip")]
    public string Tooltip { get; set; }
}

[XmlRoot(ElementName = "mxGeometry")]
public class MxGeometry
{

    [XmlAttribute(AttributeName = "x")]
    public double X { get; set; }

    [XmlAttribute(AttributeName = "y")]
    public double Y { get; set; }

    [XmlAttribute(AttributeName = "width")]
    public double Width { get; set; }

    [XmlAttribute(AttributeName = "height")]
    public double Height { get; set; }

    [XmlAttribute(AttributeName = "as")]
    public string As { get; set; }
}

[XmlRoot(ElementName = "UserObject")]
public class UserObject
{

    [XmlElement(ElementName = "mxCell")]
    public MxCell MxCell { get; set; }

    [XmlAttribute(AttributeName = "label")]
    public string Label { get; set; }

    [XmlAttribute(AttributeName = "tooltip")]
    public string Tooltip { get; set; }

    [XmlAttribute(AttributeName = "id")]
    public string Id { get; set; }

    [XmlAttribute(AttributeName = "link")]
    public string Link { get; set; }
}

[XmlRoot(ElementName = "root")]
public class Root
{

    [XmlElement(ElementName = "mxCell")]
    public List<MxCell> MxCell { get; set; }

    [XmlElement(ElementName = "UserObject")]
    public List<UserObject> UserObject { get; set; }
}

[XmlRoot(ElementName = "mxGraphModel")]
public class MxGraphModel
{

    [XmlElement(ElementName = "root")]
    public Root Root { get; set; }

    [XmlAttribute(AttributeName = "dx")]
    public int Dx { get; set; }

    [XmlAttribute(AttributeName = "dy")]
    public int Dy { get; set; }

    [XmlAttribute(AttributeName = "grid")]
    public int Grid { get; set; }

    [XmlAttribute(AttributeName = "gridSize")]
    public int GridSize { get; set; }

    [XmlAttribute(AttributeName = "guides")]
    public int Guides { get; set; }

    [XmlAttribute(AttributeName = "tooltips")]
    public int Tooltips { get; set; }

    [XmlAttribute(AttributeName = "connect")]
    public int Connect { get; set; }

    [XmlAttribute(AttributeName = "arrows")]
    public int Arrows { get; set; }

    [XmlAttribute(AttributeName = "fold")]
    public int Fold { get; set; }

    [XmlAttribute(AttributeName = "page")]
    public int Page { get; set; }

    [XmlAttribute(AttributeName = "pageScale")]
    public int PageScale { get; set; }

    [XmlAttribute(AttributeName = "pageWidth")]
    public int PageWidth { get; set; }

    [XmlAttribute(AttributeName = "pageHeight")]
    public int PageHeight { get; set; }

    [XmlAttribute(AttributeName = "math")]
    public int Math { get; set; }

    [XmlAttribute(AttributeName = "shadow")]
    public int Shadow { get; set; }
}

[XmlRoot(ElementName = "diagram")]
public class Diagram
{

    [XmlElement(ElementName = "mxGraphModel")]
    public MxGraphModel MxGraphModel { get; set; }

    [XmlAttribute(AttributeName = "name")]
    public string Name { get; set; }

    [XmlAttribute(AttributeName = "id")]
    public string Id { get; set; }
}

[XmlRoot(ElementName = "mxfile")]
public class Mxfile
{

    [XmlElement(ElementName = "diagram")]
    public Diagram Diagram { get; set; }

    [XmlAttribute(AttributeName = "host")]
    public string Host { get; set; }

    [XmlAttribute(AttributeName = "modified")]
    public DateTime Modified { get; set; }

    [XmlAttribute(AttributeName = "agent")]
    public string Agent { get; set; }

    [XmlAttribute(AttributeName = "etag")]
    public string Etag { get; set; }

    [XmlAttribute(AttributeName = "version")]
    public string Version { get; set; }

    [XmlAttribute(AttributeName = "type")]
    public string Type { get; set; }
}


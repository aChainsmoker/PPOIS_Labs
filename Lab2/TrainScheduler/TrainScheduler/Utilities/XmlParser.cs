using CommunityToolkit.Maui.Storage;
using System.Xml;
using TrainScheduler.Model;

namespace TrainScheduler.Utilities;

public static class XmlParser
{
    public static async void LoadToXML(List<TrainModel> trains)
    {
        XmlDocument doc = new XmlDocument();

        XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
        doc.AppendChild(xmlDeclaration);

        XmlElement root = doc.CreateElement("Trains");
        doc.AppendChild(root);

        foreach (var train in trains)
        {
            XmlElement trainElem = doc.CreateElement("Train");

            XmlElement idElem = doc.CreateElement("Id");
            idElem.InnerText = train.Id.ToString();
            trainElem.AppendChild(idElem);

            XmlElement numberElem = doc.CreateElement("Number");
            numberElem.InnerText = train.Number.ToString();
            trainElem.AppendChild(numberElem);

            XmlElement departureElem = doc.CreateElement("DepartureStation");
            departureElem.InnerText = train.DepartureStation;
            trainElem.AppendChild(departureElem);

            XmlElement arrivalElem = doc.CreateElement("ArrivalStation");
            arrivalElem.InnerText = train.ArrivalStation;
            trainElem.AppendChild(arrivalElem);

            XmlElement departureTimeElem = doc.CreateElement("DepartureTime");
            departureTimeElem.InnerText = train.DepartureTime.ToString("o");
            trainElem.AppendChild(departureTimeElem);

            XmlElement arrivalTimeElem = doc.CreateElement("ArrivalTime");
            arrivalTimeElem.InnerText = train.ArrivalTime.ToString("o");
            trainElem.AppendChild(arrivalTimeElem);

            root.AppendChild(trainElem);
        }

        await SaveFileViaDilagueWindow(doc);
    }

    public static async Task<List<TrainModel>> LoadFromXML()
    {
        List<TrainModel> trains = new List<TrainModel>();
        try
        {
            using (XmlReader reader = await LoadFileViaDialogueWindow())
            {
                if (reader == null)
                    return null;
                while (await reader.ReadAsync())
                {
                    if (reader.IsStartElement() && reader.Name == "Train")
                    {
                        TrainModel train = new TrainModel();

                        using (XmlReader inner = reader.ReadSubtree())
                        {
                            await inner.ReadAsync();

                            while (await inner.ReadAsync())
                            {
                                if (inner.NodeType == XmlNodeType.Element)
                                {
                                    string elementName = inner.Name;
                                    await inner.ReadAsync(); if (inner.NodeType == XmlNodeType.Text)
                                    {
                                        string value = inner.Value;
                                        await inner.ReadAsync();
                                        switch (elementName)
                                        {
                                            case "Id":
                                                train.Id = uint.Parse(value);
                                                break;
                                            case "Number":
                                                train.Number = int.Parse(value);
                                                break;
                                            case "DepartureStation":
                                                train.DepartureStation = value;
                                                break;
                                            case "ArrivalStation":
                                                train.ArrivalStation = value;
                                                break;
                                            case "DepartureTime":
                                                train.DepartureTime = DateTime.Parse(value);
                                                break;
                                            case "ArrivalTime":
                                                train.ArrivalTime = DateTime.Parse(value);
                                                break;
                                        }
                                    }
                                }
                            }
                        }

                        trains.Add(train);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new XmlException($"Couldn't read the xml fille: {ex.Message}");
        }

        return trains;
    }

    private static async Task SaveFileViaDilagueWindow(XmlDocument xmlDoc)
    {
        try
        {
            using var stream = new MemoryStream();
            xmlDoc.Save(stream);
            stream.Position = 0;
            var fileSaverResult = await FileSaver.Default.SaveAsync(
    "trains.xml",
    stream,
    new CancellationTokenSource().Token);
        }
        catch (Exception ex)
        {
            throw new XmlException($"Couldn't write the xml file: {ex.Message}");
        }
    }

    private static async Task<XmlReader> LoadFileViaDialogueWindow()
    {
        try
        {
            var options = new PickOptions
            {
                FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.WinUI, new[] { ".xml" } }
                })
            };

            var result = await FilePicker.Default.PickAsync(options);

            if (result != null)
            {
                var stream = await result.OpenReadAsync();

                var xmlReader = XmlReader.Create(stream, new XmlReaderSettings
                {
                    Async = true,
                    IgnoreComments = true,
                    IgnoreWhitespace = true
                });

                return xmlReader;
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            throw new XmlException($"Couldn't load the xml file: {ex.Message}");
        }
    }
}
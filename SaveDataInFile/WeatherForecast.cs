namespace SaveDataInFile
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public static class MokData
    {
        public static List<Item> FakeData()
        {
            var items = new List<Item>
                                    {
                                        new Item { Id = 1, Name = "John", Address = "123 Main St" },
                                        new Item { Id = 2, Name = "Alice", Address = "456 Elm St" },
                                        new Item { Id = 3, Name = "Bob", Address = "789 Oak St" }
                                        // Add more items as needed
                                     };
            return items;
        }
    }
}
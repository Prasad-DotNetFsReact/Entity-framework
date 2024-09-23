namespace Models
{
    public class Batch
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime DateOfEnd { get; set; }
        public int Capacity { get; set; }
        public string Trainer { get; set; }
    }

}

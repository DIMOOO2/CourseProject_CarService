using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Maui.Graphics;


namespace CarService.Models.Entities
{
    public class Order
    {
        [Key]
        public long OrderId { get; set; }
        public Guid ArticulGuid { get; set; }
        public DateTime OrderDate { get; set; }
        public bool OrderStatus { get; set; }
        public Client Client { get; set; } = null!;


        [NotMapped]
        public string ArticulNumber
        {
            get
            {
                byte[] data = ArticulGuid.ToByteArray();
                return Math.Abs(BitConverter.ToInt32(data, 0)).ToString();
            }
        }

        [NotMapped]
        public string GetStatus
        {
            get
            {
                if (OrderStatus) return "Статус: Завершен";
                else return "Статус: Не завершен";
            }
        }

        [NotMapped]
        public Color ColorStatus
        {
            get
            {
                if (OrderStatus) return Color.FromArgb("#32cd32");
                else return Color.FromArgb("#ff1f1f");
            }
        }

        [NotMapped] 
        public string GetDate
        {
            get
            {
                return OrderDate.ToLongDateString().ToString();
            }
        }
    }
}

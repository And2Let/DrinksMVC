using DrinksMVC.Data;
using DrinksMVC.Data.Base;

namespace DrinksMVC.Entities
{
    public class Drink : EntityBase<int>
    {
        //public Guid Id { get; set; }
        /// <summary>
        /// Наименование товара
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// Описание товара
        /// </summary>
        public string Description { get; set; } = "";

        /// <summary>
        /// Ссылка на фото
        /// </summary>
        public string PhotoUrl { get; set; } = "";

        /// <summary>
        /// Цена товара
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Количество товара
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Доступность товара
        /// </summary>
        public bool isAvailable { get; set; }

        public virtual WendingMachine WendingMachine { get; set; }
    }
}

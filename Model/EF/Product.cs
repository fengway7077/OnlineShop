namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public long ID { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }

        [StringLength(10)]
        [Display(Name = "Mã sản phẩm")]
        public string Code { get; set; }

        [StringLength(250)]
        [Display(Name = "Tiêu đề Seo")]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        [Display(Name = "Diễn giải  Seo")]
        public string Description { get; set; }

        [StringLength(250)]
        [Display(Name = "Hình")]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        [Display(Name = "Nhiều hình")]
        public string MoreImages { get; set; }
        [Display(Name = "Giá")]
        public decimal? Price { get; set; }
        [Display(Name = "Khuyến mãi")]
        public decimal? PromotionPrice { get; set; }
        [Display(Name = "Vat")]
        public bool? IncludedVAT { get; set; }

        [Display(Name = "Số lượng")]
        public int? Quantity { get; set; }

        [Display(Name = "Doanh mục")]
        public long? CategoryID { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Chi tiết")]
        public string Detail { get; set; }
        [Display(Name = "Warranty")]
        public int? Warranty { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? ModifieDate { get; set; }

        [StringLength(50)]
        public string ModifineBy { get; set; }

        [StringLength(250)]
        [Display(Name="Từ khóa")]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        [Display(Name = "Diễn giải")]
        public string MetaDiscriptions { get; set; }
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
        [Display(Name = "Ngày hot")]
        public DateTime? TopHot { get; set; }
        [Display(Name = "Số lược xem")]
        public int? ViewCount { get; set; }//sua lai
    }
}

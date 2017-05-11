namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [StringLength(250)]
        [Display(Name = "Category_Name",ResourceType = typeof(StaticResource.Resources))] // ngon ngu hien ten
        [Required(ErrorMessageResourceName = "Category_RequiredName",ErrorMessageResourceType = typeof(StaticResource.Resources))] //thao bao resources
        public string Name { get; set; }

        [StringLength(250)]
        [Display(Name = "Category_MetaTitle", ResourceType = typeof(StaticResource.Resources))] // ngon ngu
        public string MetaTitle { get; set; }

        [Display(Name = "Category_ParenID", ResourceType = typeof(StaticResource.Resources))] // ngon ngu
        public long? ParenID { get; set; }

        [Display(Name = "Category_DisplayOrder", ResourceType = typeof(StaticResource.Resources))] // ngon ngu
        public int? DisplayOrder { get; set; }

        [StringLength(250)]
        [Display(Name = "Category_SeoTitle", ResourceType = typeof(StaticResource.Resources))] // ngon ngu
        public string SeoTitle { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? ModifieDate { get; set; }

        [StringLength(50)]
        public string ModifineBy { get; set; }

        [StringLength(250)]
        [Display(Name = "Category_MetaKeywords", ResourceType = typeof(StaticResource.Resources))] // ngon ngu
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        [Display(Name = "Category_MetaDiscriptions", ResourceType = typeof(StaticResource.Resources))] // ngon ngu
        public string MetaDiscriptions { get; set; }

        [Display(Name = "Category_Status", ResourceType = typeof(StaticResource.Resources))] // ngon ngu
        public bool? Status { get; set; }

        [Display(Name = "Category_ShowOnHome", ResourceType = typeof(StaticResource.Resources))] // ngon ngu
        public bool? ShowOnHome { get; set; }

        public string Language { set; get; }
    }
}
